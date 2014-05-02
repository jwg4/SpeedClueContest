using System;
using System.Collections.Generic;
using System.Linq;
using ClueSharp;
using ClueSharp.tests;
using NUnit.Framework;

namespace ClueStick
{
  public class ClueStick : IClueAI
  {
    private List<Suspect> m_suspects;
    private List<Weapon> m_weapons;
    private List<Room> m_rooms;

    public ClueStick()
    {
    }

    public void Reset(int n, int i, IEnumerable<Suspect> suspects, IEnumerable<Weapon> weapons, IEnumerable<Room> rooms)
    {
      m_suspects = suspects.ToList();
      m_weapons = weapons.ToList();
      m_rooms = rooms.ToList();
    }

    public void Suggestion(int suggester, MurderSet suggestion, int? disprover, Card disproof)
    {
    }

    public void Accusation(int accuser, MurderSet suggestion, bool won)
    {
      throw new NotImplementedException();
    }

    public MurderSet Suggest()
    {
      return new MurderSet(Suspect.MrGreen, Weapon.Candlestick, Room.BallRoom);
    }

    public MurderSet? Accuse()
    {
      return null;
    }

    public Card Disprove(int player, MurderSet suggestion)
    {
      if (m_suspects.IndexOf(suggestion.Suspect) != -1)
      {
        return new Card(suggestion.Suspect);
      }
      if (m_weapons.IndexOf(suggestion.Weapon) != -1)
      {
        return new Card(suggestion.Weapon);
      }
      if (m_rooms.IndexOf(suggestion.Room) != -1)
      {
        return new Card(suggestion.Room);
      }
      return null;
    }
  }

  public class ClueStickTest : ClueAITest<ClueStick>
  {}
}
