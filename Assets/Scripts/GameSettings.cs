using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Settings", menuName = "SO/GameSettings", order = 1)]
public class GameSettings : ScriptableObject
{
    [Range(1,10)]
    [SerializeField] private int _fieldSizeX;
    [Range(1,10)]
    [SerializeField] private int _fieldSizeY;
    [Range(0,50)]
    [SerializeField] private int _itemsInScene;
    [Tooltip("Насколько далеко от края игровой зоны спавнятся итемы")]
    [SerializeField] private float _boundsOffset;

    public int SizeX => _fieldSizeX;
    public int SizeY => _fieldSizeY;
    public int ItemsInScene => _itemsInScene;
    public float BoundsOffset => _boundsOffset;
}
