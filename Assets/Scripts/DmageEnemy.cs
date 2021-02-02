using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmageEnemy : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] GameObject _hitEffect;
	[SerializeField] int _damageToDeal;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			other.GetComponent<EnemyHealthController>().TakeDamage(_damageToDeal);

			Instantiate(_hitEffect, transform.position, Quaternion.identity);
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
