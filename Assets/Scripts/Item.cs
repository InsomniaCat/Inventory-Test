using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour, IPickupable
{    
    public void Pickup()
    {
        Destroy(gameObject);
        Debug.Log($"item {gameObject.name} was picked up!");
    }
}
