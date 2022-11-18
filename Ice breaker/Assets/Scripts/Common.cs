using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Common
{
  public static bool IsSameColor(Color a, Color b)
  {
    return a.r == b.r && a.g == b.g && a.b == b.b;
  }
}