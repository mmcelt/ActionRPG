using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonRoomActivator : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] GameObject[] _allEnemies;

	List<GameObject> _clonedEnemies;

	#endregion

	#region Getters

	
	#endregion

	#region Unity Methods

	void Start() 
	{
		foreach (GameObject enemy in _allEnemies)
			enemy.SetActive(false);

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			DungeonCameraController.Instance._targetPoint = new Vector3(transform.position.x, transform.position.y, DungeonCameraController.Instance._targetPoint.z);
			SpawnEnemies();
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
