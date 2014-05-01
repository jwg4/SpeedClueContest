using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ClueSharp;

namespace ClueBot
{
  class Parser
  {
    private static Dictionary<string, object> lookup; 
    
    static Parser()
    {
      lookup = new Dictionary<string, object>();

      AddValues<Suspect>();
      AddValues<Weapon>();
      AddValues<Room>();
    }

    private static void AddValues<T>()
    {
      var enumType = typeof (T);
      foreach (Enum val in Enum.GetValues(enumType))
      {
        FieldInfo fi = enumType.GetField(val.ToString());
        var attributes = (CodeAttribute[]) fi.GetCustomAttributes(
          typeof (CodeAttribute), false);
        CodeAttribute attr = attributes[0];
        lookup[attr.Code] = (T)(object)val;
      }
    }

    internal static CardCollection ParseCards(IEnumerable<string> strings)
    {
      return new CardCollection(strings.Select(ParseOneCard).ToList());
    }

    internal static object ParseOneCard(string s)
    {
      if (!lookup.ContainsKey(s))
      throw new ArgumentException();
      return lookup[s];
    }

    internal static int ParseInt(string s)
    {
      return Int32.Parse(s);
    }

    public static MurderSet ParseSet(IEnumerable<string> cards)
    {
      throw new NotImplementedException();
    }

    public static Card ParseCard(string s)
    {
      throw new NotImplementedException();
    }

    public static int? ParseIntMaybe(string s)
    {
      if (s == "-")
      {
        return null;
      }
      return ParseInt(s);
    }

    public static bool ParseBool(string s)
    {
      if (s == "-")
      {
        return false;
      }
      if (s == "+")
      {
        return true;
      }
      throw new Exception();
    }
  }
}