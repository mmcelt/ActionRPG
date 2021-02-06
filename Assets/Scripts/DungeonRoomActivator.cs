using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonRoomActivator : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] GameObject[] _allEnemies;

	List<GameObject> _clonedEnemies;

	[SerializeField] bool _lockDoors;
	[SerializeField] GameObject[] _doors;

	bool _doorsLocked, _dontRespawnEnemies;

	[Header("Boss Room")]
	[SerializeField] bool _isBossRoom;
	public Transform _bossCamPointUpr, _bossCamPointLwr;
	[SerializeField] GameObject _theBoss;
	bool _dontReactivateBoss;

	#endregion

	#region Getters

	
	#endregion

	#region Unity Methods

	void Start() 
	{
		_clonedEnemies = new List<GameObject>();

		foreach (GameObject enemy in _allEnemies)
			enemy.SetActive(false);

	}

	void Update()
	{
		if (_doorsLocked)
		{
			bool enemyFound = false;
			//DIFFERENT FROM COURSE CODE DUE TO THE FACT I REMOVE DEAD ENEMIES FROM THE
			//CLONEDPLAYERS LIST AS THEY GET KILLED...
			if (_clonedEnemies.Count > 0) enemyFound = true;

			if (!enemyFound)
			{
				foreach (GameObject door in _doors)
					door.SetActive(false);

				_doorsLocked = false;
				_lockDoors = false;
				_dontRespawnEnemies = true;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			DungeonCameraController.Instance._targetPoint = new Vector3(transform.position.x, transform.position.y, DungeonCameraController.Instance._targetPoint.z);
			SpawnEnemies();

			if (_lockDoors)
			{
				foreach (GameObject door in _doors)
					door.SetActive(true);

				_doorsLocked = true;
			}

			if (_isBossRoom)
			{
				DungeonCameraController.Instance.ActivateBossRoom(_bossCamPointUpr.position, _bossCamPointLwr.position);

				if (!_dontReactivateBoss)
				{
					_theBoss.SetActive(true);
					_dontReactivateBoss = true;
				}
			}
			else
			{
				DungeonCameraController.Instance._inBossRoom = false;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{

		if (other.CompareTag("Player"))
		{
			if (PlayerHealthController.Instance._currentHealth > 0)
				DespawnEnemies();
		}
	}
	#endregion

	#region Public Methods

	public void RemoveEnemy(GameObject enemy)
	{
		_clonedEnemies.Remove(enemy);
	}
	#endregion

	#region Private Methods

	void SpawnEnemies()
	{
		if (_dontRespawnEnemies) return;

		foreach (GameObject enemy in _allEnemies)
		{
			GameObject newEnemy = Instantiate(enemy, enemy.transform.position, Quaternion.identity);
			newEnemy.SetActive(true);
			_clonedEnemies.Add(newEnemy);
		}
	}

	void DespawnEnemies()
	{
		foreach (GameObject enemy in _clonedEnemies)
			Destroy(enemy);

		_clonedEnemies.Clear();
	}
	#endregion
}
