using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameRoot : MonoBehaviour
{
	private const float PlaneSizeDifference = 10f;
	
	[SerializeField] private GameSettings _gameSettings;
	[SerializeField] private ItemSettings _itemSettings;
	[SerializeField] private GameObject _plane;

	public GameSettings GameSettings => _gameSettings;
	public ItemSettings ItemSettings => _itemSettings;

	public static GameRoot singleton;

	private void Awake()
	{
		if (singleton == null) singleton = this;
	}

	private void Start()
	{
		var x = _gameSettings.SizeX;
		var y = _gameSettings.SizeY;

		_plane.transform.localScale = new Vector3(x, 1, y);
		_plane.GetComponent<Renderer>().material.mainTextureScale = new Vector2(x, y);
		SpawnItems(x, y);
	}

	private void SpawnItems(int boundX, int boundY)
	{
		var offset = _gameSettings.BoundsOffset;
		if (offset < 0) throw new Exception("Значение offset не может быть меньше 0");
		
		for (var i = 0; i < _gameSettings.ItemsInScene; i++)
		{
			var posX = Random.Range(boundX / 2 - offset, -boundX / 2 + offset) * PlaneSizeDifference;
			var posY = Random.Range(boundY / 2 - offset, -boundY / 2 + offset) * PlaneSizeDifference;

			var itemToSpawn = _itemSettings.Items[Random.Range(0, _itemSettings.Items.Count)].prefab;

			var item = Instantiate(itemToSpawn, new Vector3(posX, 0.5f, posY), Quaternion.identity);
			if (!item.GetComponent<Item>()) item.AddComponent<Item>();

			item.name = itemToSpawn.name;
		}
	}
}