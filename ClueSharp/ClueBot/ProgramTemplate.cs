using System;
using System.Net.Sockets;
using ClueSharp;

namespace ClueBot
{
  public abstract class ProgramTemplate<T> where T : IClueAI, new() 
  {
    protected internal ClueClient m_clueClient;

    public void DoMain(string[] args)
    {
      string identifier = args[0];
      int port = Int32.Parse(args[1]);
      var client = new TcpClient("localhost", port);
      if (!client.Connected)
      {
        throw new Exception();
      }
      m_clueClient = new ClueClient(client.GetStream());
      
      m_clueClient.Handshake(identifier);

      bool end = false;
      var ai = new T();
      while (!end)
      {
        end = m_clueClient.ProcessMessage(ai);
      }

    }
  }
}
