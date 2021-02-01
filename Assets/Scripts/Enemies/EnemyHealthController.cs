using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] GameObject _deathEffect;
	[SerializeField] int _currentHealth;

	EnemyController _theController;
	AreaActivator _areaActivator; //used for removing killed enemies from the List

	[Header("Health Drop")]
	[SerializeField] GameObject _healthDropPrefab;
	[SerializeField] float _healthDropChance;

	[Header("Coin Drop")]
	[SerializeField] GameObject _coinDropPrefab;
	[SerializeField] float _coinDropChance;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start() 
	{
		_theController = GetComponent<EnemyController>();
		_areaActivator = GetComponent<EnemyController>()._area.GetComponent<AreaActivator>();
	}
	#endregion

	#region Public Methods

	public void TakeDamage(int damageAmount)
	{
		_currentHealth -= damageAmount;

		if (_currentHealth <= 0)
		{
			Instantiate(_deathEffect, transform.position, Quaternion.identity);

			_areaActivator._clonedEnemies.Remove(gameObject);	//remove enemy from area List

			Destroy(gameObject);

			if (Random.Range(0f, 100f) < _healthDropChance && _healthDropPrefab != null)
			{
				Instantiate(_healthDropPrefab, transform.position, Quaternion.identity);
			}

			if (Random.Range(0f, 100f) < _coinDropChance && _coinDropPrefab != null)
			{
				Instantiate(_coinDropPrefab, transform.position, Quaternion.identity);
			}
		}
		_theController.KnockBack(PlayerController.Instance.transform.position);
	}
	#endregion

	#region Private Methods


	#endregion
}
