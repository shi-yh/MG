using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global 
{
    public static int curLevel;

    public static int maxLevel = 0;

    public static float audioValue = 1;

    public static void Save()
    {
        PlayerPrefs.SetInt("Level", maxLevel);
    }


    public static void Load()
    {
        maxLevel = PlayerPrefs.GetInt("Level");
    }

    public static void Clear()
    {
        maxLevel = 0;

        PlayerPrefs.DeleteAll();
    }

    public static void AddMaxLevel()
    {
        maxLevel++;

        if (maxLevel>=4)
        {
            maxLevel = 4;
        }

        Save();
    }


}
