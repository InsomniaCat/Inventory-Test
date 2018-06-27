using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct InventoryData
{
    public List<string> items;

    public InventoryData(List<string> data)
    {
        items = data;
    }
}
