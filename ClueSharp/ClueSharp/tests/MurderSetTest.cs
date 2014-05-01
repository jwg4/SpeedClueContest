using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ClueSharp.tests
{
  [TestFixture]
  class MurderSetTest
  {
    [Test]
    public void TestToString()
    {
      var set = new MurderSet(Suspect.ColMustard, Weapon.Revolver, Room.Lounge);
      Assert.AreEqual("Mu Re Lo", set.ToString());
    }
  }
}
