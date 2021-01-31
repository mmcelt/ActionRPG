using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] GameObject _deathEffect;
	[SerializeField] int _currentHealth;

	EnemyController _theController;
	AreaActivator _areaActivator;

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
		}
		_theController.KnockBack(PlayerController.Instance.transform.position);
	}
	#endregion

	#region Private Methods


	#endregion
}
