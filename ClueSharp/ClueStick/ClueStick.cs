using System;
using System.Collections.Generic;
using ClueSharp;

namespace ClueStick
{
  public class ClueStick : IClueAI
  {
    public ClueStick()
    {
    }

    public void Reset(int n, int i, IEnumerable<Suspect> suspects, IEnumerable<Weapon> weapons, IEnumerable<Room> rooms)
    {
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
      throw new NotImplementedException();
    }

    public Card Disprove(int player, MurderSet suggestion)
    {
      throw new NotImplementedException();
    }
  }
}
