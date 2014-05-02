namespace ClueSharp
{
  public class Card
  {
    private readonly Suspect m_s;
    private readonly Weapon m_w;
    private readonly Room m_r;

    public Card(object o)
      : this(o is Suspect ? (Suspect) o : Suspect.None,
             o is Weapon ? (Weapon) o : Weapon.None,
             o is Room ? (Room) o : Room.None)
    {
    }

    private Card(Suspect s, Weapon w, Room r)
    {
      m_s = s;
      m_w = w;
      m_r = r;
    }
  }
}