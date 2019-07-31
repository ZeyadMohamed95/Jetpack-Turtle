using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData  {
    public int Coins;
    public int Crystals;

    public int no_Magnets;
    public int no_Stars;
    public int no_Shrooms;
    [Range(0f, 1f)]
    public float Music, Effects;
    public GameData(MainGameController main)
    {
        Coins = main.TotalCoins;
        Crystals = main.TotalCrystals;
        no_Magnets = main.no_magnets;
        no_Stars = main.no_Stars;
        no_Shrooms = main.no_Shrooms;
        Music = main.MusicLevel;
        Effects = main.EffectsLevel;
    }
   
}
