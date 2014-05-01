using System.Linq;
using System.Net.Sockets;
using System.Text;
using ClueSharp;

namespace ClueBot
{
  class ClueClient
  {
    private readonly NetworkStream m_stream;
    
    public ClueClient(NetworkStream stream)
    {
      m_stream = stream;
    }

    internal bool ProcessMessage(IClueAI ai)
    {
      var data = new byte[256];
      m_stream.Read(data, 0, 256);
      var s = Encoding.ASCII.GetString(data);
      return ProcessMessageString(ai, s);
    }

    internal bool ProcessMessageString(IClueAI ai, string s)
    {
      var trimmed = s.Replace("\0", "");
      string[] pieces = trimmed.Split(' ');
      var opcode = pieces[0];

      switch (opcode)
      {
        case "done":
          return true;
        case "reset":
          var cards = Parser.ParseCards(pieces.Skip(3));
          ai.Reset(Parser.ParseInt(pieces[1]), Parser.ParseInt(pieces[2]), cards.Suspects, cards.Weapons, cards.Rooms);
          SendOK();
          break;
        case "suggestion":
          {
            var suggester = Parser.ParseInt(pieces[1]);
            var murderSet = Parser.ParseSet(pieces.Skip(2).Take(3));
            var disprover = Parser.ParseIntMaybe(pieces[5]);
            var disproof = (pieces.Length == 7) ? Parser.ParseCard(pieces[6]) : null;
            ai.Suggestion(suggester, murderSet, disprover, disproof);
            SendOK();
            break;
          }
        case "accusation":
          {
            var accuser = Parser.ParseInt(pieces[1]);
            var murderSet = Parser.ParseSet(pieces.Skip(2).Take(3));
            var won = Parser.ParseBool(pieces[5]);
            ai.Accusation(accuser, murderSet, won);
            SendOK();
            break;
          }
      }
      return false;
    }

    protected virtual void SendOK()
    {
      Send("ok");
    }

    private void Send(string msg)
    {
      var data = StringToByteArray(msg);
      m_stream.Write(data, 0, data.Length);
    }

    internal void Handshake(string identifier)
    {
      Send(identifier + " alive");
    }

    private static byte[] StringToByteArray(string s)
    {
      return Encoding.ASCII.GetBytes(s);
    }
  }
}