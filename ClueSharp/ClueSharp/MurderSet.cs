namespace ClueSharp
{
  public struct MurderSet
  {
    private readonly Suspect m_suspect;
    private readonly Weapon m_weapon;
    private readonly Room m_room;

    public MurderSet(object card1, object card2, object card3)
    {
      m_suspect = (Suspect) card1;
      m_weapon = (Weapon) card2;
      m_room = (Room) card3;
    }

    public Suspect Suspect
    {
      get { return m_suspect; }
    }

    public Weapon Weapon
    {
      get { return m_weapon; }
    }

    public Room Room
    {
      get { return m_room; }
    }
  }
}