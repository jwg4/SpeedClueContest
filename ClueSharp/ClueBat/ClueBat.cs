using System;
using System.Collections.Generic;
using System.Linq;
using ClueSharp;
using ClueSharp.tests;

namespace ClueBat
{
  public class ClueBat : IClueAI
  {
    private List<Suspect> m_suspects;
    private List<Weapon> m_weapons;
    private List<Room> m_rooms;
    private IEnumerator<MurderSet> m_suggestions;
    private MurderSet? m_accusation;
    private bool m_firstMove;
    private int m_identity;

    public void Reset(int n, int i, IEnumerable<Suspect> suspects, IEnumerable<Weapon> weapons, IEnumerable<Room> rooms)
    {
      m_identity = i;
      m_suspects = suspects.ToList();
      m_weapons = weapons.ToList();
      m_rooms = rooms.ToList();
      m_accusation = null;
      m_firstMove = true;
      m_suggestions = MurderSet.AllSuggestions.GetEnumerator();
    }

    public void Suggestion(int suggester, MurderSet suggestion, int? disprover, Card disproof)
    {
      if (disprover == null && suggester != m_identity)
      {
        m_accusation = suggestion;
      }
    }

    public void Accusation(int accuser, MurderSet suggestion, bool won)
    {
    }

    public MurderSet Suggest()
    {
      // This takes advantage of the flaw in ClueStick to usually beat that AT
      // 
      if (m_firstMove)
      {
        if (m_suspects.Any() && m_weapons.Any() && m_rooms.Any())
        {
          return new MurderSet(m_suspects.First(), m_weapons.First(), m_rooms.First());
        }
        m_firstMove = false;
      }

      if (!m_suggestions.MoveNext())
      {
        throw new Exception("Run out of suggestions");
      }
      return m_suggestions.Current;
    }

    public MurderSet? Accuse()
    {
      return m_accusation;
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

    public class ClueStickTest : ClueAITest<ClueBat>
    {
    }
  }
}