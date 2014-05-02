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
  }
}