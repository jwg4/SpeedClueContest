using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ClueSharp.tests
{
  [TestFixture]
  public class CardTest
  {
    [Test]
    public void EqualityTest()
    {
      Assert.AreEqual(new Card(Room.Kitchen), new Card(Room.Kitchen));
    }
  }
}
