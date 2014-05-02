namespace ClueSharp
{
  public class Card
  {
    private readonly Suspect m_suspect;
    private readonly Weapon m_weapon;
    private readonly Room m_room;

    public Card(object o)
      : this(o is Suspect ? (Suspect) o : Suspect.None,
             o is Weapon ? (Weapon) o : Weapon.None,
             o is Room ? (Room) o : Room.None)
    {
    }

    private Card(Suspect suspect, Weapon weapon, Room room)
    {
      m_suspect = suspect;
      m_weapon = weapon;
      m_room = room;
    }

    public override int GetHashCode()
    {
      return m_suspect.GetHashCode() + 99 * m_weapon.GetHashCode() + 99 * 99 * m_room.GetHashCode();
    }

    public override bool Equals(object obj)
    {
      // todo: use GetHashCode() ?
      var card = obj as Card;
      if (card == null) return false;
      return (m_suspect == card.m_suspect
              && m_weapon == card.m_weapon
              && m_room == card.m_room);
    }
  }
}