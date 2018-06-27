using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory _inventory;

    private void Start()
    {
        _inventory = transform.GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Item>())
        {
            var item = other.GetComponent<Item>();
            
            item.Pickup();
            _inventory.AddItem(item.gameObject.name);
        }
    }
}
