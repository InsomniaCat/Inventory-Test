using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private InventoryData _data;

    private void Awake()
    {
        _data = InventoryHandler.Load();
    }

    public IEnumerable<string> GetItems()
    {
        return _data.items;
    }

    public void AddItem(string itemName)
    {
        _data.items.Add(itemName);
        InventoryHandler.Save(_data);
    }

    public void RemoveItem(Guid id)
    {
        throw new NotImplementedException("Пока не введено");
    }
}
