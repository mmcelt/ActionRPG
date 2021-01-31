using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaActivator : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] GameObject[] _allEnemies;
	public List<GameObject> _clonedEnemies;	//TODO: MAKE PRIVATE AFTER TESTING

	BoxCollider2D _areaBox;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start() 
	{
		_areaBox = GetComponent<BoxCollider2D>();
		_clonedEnemies = new List<GameObject>();

		foreach (GameObject enemy in _allEnemies)
			enemy.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			CameraController.Instance._areaBox = _areaBox;
			SpawnEnemies();
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{

		if (other.CompareTag("Player"))
		{
			if(PlayerHealthController.Instance._currentHealth > 0)
				DespawnEnemies();
		}
	}
	#endregion

	#region Public Methods


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
