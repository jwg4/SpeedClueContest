namespace ClueSharp
{
  public enum Suspect
  {
    None = -1,
    [Code("Gr")] MrGreen,
    [Code("Mu")] ColMustard,
    [Code("Pe")] MrsPeacock,
    [Code("Pl")] ProfPlum,
    [Code("Sc")] MissScarlet,
    [Code("Wh")] MrsWhite
  }

  public enum Weapon
  {
    None = -1,
    [Code("Ca")] Candlestick,
    [Code("Kn")] Knife,
    [Code("Pi")] LeadPipe,
    [Code("Re")] Revolver,
    [Code("Ro")] Rope,
    [Code("Wr")] MonkeyWrench
  }

  public enum Room
  {
    None = -1,
    [Code("Ba")] BallRoom,
    [Code("Bi")] BilliardsRoom,
    [Code("Co")] Conservatory,
    [Code("Di")] DiningRoom,
    [Code("Ha")] Hall,
    [Code("Ki")] Kitchen,
    [Code("Li")] Library,
    [Code("Lo")] Lounge,
    [Code("St")] Study,
  }

}