using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClueSharp;
using NUnit.Framework;

namespace ClueBot.tests
{
  [TestFixture]
  class ParserTest
  {

    [Test]
    public void TestParseOneCard()
    {
      Assert.AreEqual(Room.BilliardsRoom, Parser.ParseOneCard("Bi"));
      Assert.AreEqual(Room.BallRoom, Parser.ParseOneCard("Ba"));

      Assert.AreEqual(Suspect.MrsWhite, Parser.ParseOneCard("Wh"));

      Assert.AreEqual(Weapon.MonkeyWrench, Parser.ParseOneCard("Wr"));

      Assert.Throws<ArgumentException>(() => Parser.ParseOneCard("Jw"));
    }

    [Test]
    public void TestParseCards()
    {
      var collection = Parser.ParseCards(new List<string>
        {
          "Ro",
          "Wr",
          "Sc"
        });
      Assert.AreEqual(1, collection.Suspects.Count());
      Assert.AreEqual(2, collection.Weapons.Count());
      Assert.AreEqual(0, collection.Rooms.Count());

      collection = Parser.ParseCards(new List<string>
        {
          "Ro",
          "Lo",
          "Ba",
          "Ki"
        });
      Assert.AreEqual(0, collection.Suspects.Count());
      Assert.AreEqual(1, collection.Weapons.Count());
      Assert.AreEqual(3, collection.Rooms.Count());
    }

    [Test]
    public void TestParseSetValid()
    {
      var s = new[] {"Sc", "Pi", "Di"};
      var set = Parser.ParseSet(s);
      Assert.AreEqual(Suspect.MissScarlet, set.Suspect);
      Assert.AreEqual(Weapon.LeadPipe, set.Weapon);
      Assert.AreEqual(Room.DiningRoom, set.Room);
    }
  }
}
