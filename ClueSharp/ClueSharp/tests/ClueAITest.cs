﻿using NUnit.Framework;

namespace ClueSharp.tests
{
  [TestFixture]
  public abstract class ClueAITest<T> where T : IClueAI, new()
  {
    private T m_ai;

    [SetUp]
    public void Init()
    {
      m_ai = new T();
    }

    [Test]
    public void AccuseTest()
    {
      m_ai.Reset(4, 3, new[] { Suspect.MissScarlet }, new Weapon[0], new[] { Room.Kitchen, Room.Conservatory, Room.Lounge });
      m_ai.Accuse();
    }

    [Test]
    public void DisproveTest()
    {
      m_ai.Reset(4, 3, new[] { Suspect.MissScarlet }, new Weapon[0], new[] { Room.Kitchen, Room.Conservatory, Room.Lounge });
      var disproof = m_ai.Disprove(0, new MurderSet(Suspect.MrGreen, Weapon.LeadPipe, Room.Kitchen));
      Assert.AreEqual(new Card(Room.Kitchen), disproof);
    }

    [Test]
    public void DisproveNoneTest()
    {
      m_ai.Reset(4, 3, new[] { Suspect.MissScarlet }, new Weapon[0], new[] { Room.Kitchen, Room.Conservatory, Room.Lounge });
      var disproof = m_ai.Disprove(0, new MurderSet(Suspect.MrGreen, Weapon.LeadPipe, Room.BilliardsRoom));
      Assert.AreEqual(null, disproof);
    }

    [Test]
    public void DontSuggestTheSameThingTwiceTest()
    {
      m_ai.Reset(4, 3, new[] { Suspect.MissScarlet }, new Weapon[0], new[] { Room.Kitchen, Room.Conservatory, Room.Lounge });
      var suggestion1 = m_ai.Suggest();
      m_ai.Suggestion(3, suggestion1, 1, new Card(suggestion1.Suspect));
      var suggestion2 = m_ai.Suggest();
      Assert.AreNotEqual(suggestion1, suggestion2);
    }
  }

}
