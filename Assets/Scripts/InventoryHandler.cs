using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.AI;

public static class InventoryHandler
{
    private const string fileName = "progress.json";
    
    public static InventoryData Load()
    {
        
        if (File.Exists(GetPath()))
        {
            var emptyInventory = new InventoryData(new List<string>());
            var dataToLoad = File.ReadAllText(GetPath());
            
            Debug.Log(dataToLoad);

            return dataToLoad == "" ? emptyInventory : JsonUtility.FromJson<InventoryData>(dataToLoad);
        }

        else
        {
            throw new Exception("File not exist");
        }
    }

    public static void Save(InventoryData inventory)
    {
            var dataToSave = JsonUtility.ToJson (inventory);
            File.WriteAllText (GetPath(), dataToSave);
    }

   private static string GetPath()
    {
       return Path.Combine (Application.streamingAssetsPath, fileName);
    }
}
