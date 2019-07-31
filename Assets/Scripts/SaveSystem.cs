using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public static class SaveSystem  {
    public static void SavePlayer(MainGameController main)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Resources.dat");
        GameData data = new GameData(main);
        bf.Serialize(file, data);
        file.Close();
    }
    public static GameData LoadPlayer()
    {
        if (File.Exists(Application.persistentDataPath + "/Resources.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Resources.dat", FileMode.Open);
            GameData data = (GameData)bf.Deserialize(file) as GameData;
         
            file.Close();
            return data;

        }
        else
        {
            Debug.LogError("save file not found ");
            return null;
        }
    }

}
