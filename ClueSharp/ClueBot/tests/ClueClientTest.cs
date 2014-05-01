using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClueSharp;
using NUnit.Framework;

namespace ClueBot.tests
{
  [TestFixture]
  class ClueClientTest
  {
    private ClueClient client;
    private DummyAI ai;

    class DummyAI : IClueAI
    {
      private readonly List<string> m_records;

      public DummyAI()
      {
        m_records = new List<string>();
      }

      public List<string> Records
      {
        get { return m_records; }
      }

      public void Reset(int n, int i, IEnumerable<Suspect> suspects, IEnumerable<Weapon> weapons, IEnumerable<Room> rooms)
      {
        Records.Add("reset");
      }

      public void Suggestion(int suggester, MurderSet suggestion, int? disprover, Card disproof)
      {
        Records.Add("suggestion");
      }

      public void Accusation(int accuser, MurderSet suggestion, bool won)
      {
        Records.Add("accusation");
      }

      public MurderSet Suggest()
      {
        Records.Add("suggest");
        return new MurderSet();
      }

      public MurderSet? Accuse()
      {
        Records.Add("accuse");
        return null;
      }

      public Card Disprove(int player, MurderSet suggestion)
      {
        Records.Add("disprove");
        return null;
      }
    }

    class DummyClient : ClueClient
    {
      public DummyClient()
        : base(null)
      {}

      protected override void Send(string msg)
      {
        // do nothing
      }
    }

    [SetUp]
    public void Init()
    {
      ai = new DummyAI();
      client = new DummyClient();
    }

    [Test]
    public void TestProcessMessageString()
    {
      var s = "reset 4 3 Gr Sc St Bi";
      client.ProcessMessageString(ai, s);
      Assert.AreEqual("reset", ai.Records[0]);

    }

    [Test]
    public void TestProcessMessageStringSuggest()
    {
      var s = "suggest";
      client.ProcessMessageString(ai, s);
      Assert.AreEqual("suggest", ai.Records[0]);
    }

    [Test]
    public void TestProcessMessageStringWithNulls()
    {
      var s = "reset 4 3 Gr Sc St Bi\0\0\0\0\0\0\0\0\0\0";
      client.ProcessMessageString(ai, s);
      Assert.AreEqual("reset", ai.Records[0]);
    }
  }
}
