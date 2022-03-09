using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    int combo;
    public void ComboUpdate()
    {
        combo++;
        print($"Combo : {combo}!");
    }
    public void ComboReset()
    {
        combo = 0;
        print($"Combo : End!");
    }
    public int ComboGet()
    {
        return combo;
    }
}