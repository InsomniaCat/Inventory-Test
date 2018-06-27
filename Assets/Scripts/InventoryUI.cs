using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryView;
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private GameObject _cell;
    [SerializeField] private Transform _grid;
    
    private List<GameObject> _itemIcons;
    private Inventory _inventory;

    private void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
        _openButton.onClick.AddListener(OpenInventoryView);
        _closeButton.onClick.AddListener(CloseInventoryView);

        _itemIcons = new List<GameObject>();
    }

    public void OpenInventoryView()
    {
        _inventoryView.SetActive(true);
        _openButton.gameObject.SetActive(false);

        foreach (var item in _inventory.GetItems())
        {
            var sprite = GameRoot.singleton.ItemSettings.Items.First(i => i.prefab.name == item).icon;
            var icon = Instantiate(_cell, _grid, false);
            icon.GetComponent<Image>().sprite = sprite;
            
            _itemIcons.Add(icon);
        }
    }

    public void CloseInventoryView()
    {
        _inventoryView.SetActive(false);
        _openButton.gameObject.SetActive(true);

        foreach (var icon in _itemIcons)
        {
            Destroy(icon);
        }
        
        _itemIcons.Clear();
        _itemIcons.Capacity = 0;
    }
}
