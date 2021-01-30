using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] GameObject _deathEffect;
	[SerializeField] int _currentHealth;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start() 
	{
		
	}
	
	void Update() 
	{
		
	}
	#endregion

	#region Public Methods

	public void TakeDamage(int damageAmount)
	{
		_currentHealth -= damageAmount;

		if (_currentHealth <= 0)
		{
			Instantiate(_deathEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
	#endregion

	#region Private Methods


	#endregion
}
