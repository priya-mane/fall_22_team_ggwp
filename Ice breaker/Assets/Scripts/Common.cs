using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Common
{
  public static Color[] COLORS = 
  {
    new Color(149f/255f,73f/255f,62f/255f,1), 
    new Color(60f/255f,75f/255f,161f/255f,1), 
    new Color(178f/255f,150f/255f,53f/255f,1)
  };
  
  public static bool IsSameColor(Color a, Color b)
  {
    return a.r == b.r && a.g == b.g && a.b == b.b;
  }
}