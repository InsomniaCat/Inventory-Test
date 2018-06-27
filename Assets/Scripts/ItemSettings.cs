using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Settings", menuName = "SO/ItemSettings", order = 2)]
public class ItemSettings : ScriptableObject
{
    [SerializeField] private List<ItemData> _items;
    public List<ItemData> Items => _items;
}
