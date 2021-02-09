using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy: MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] GameObject _hitEffect;
	public int _damageToDeal;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			other.GetComponent<EnemyHealthController>().TakeDamage(_damageToDeal);
			SpawnHitEffect();
		}
		if (other.CompareTag("Breakable"))
		{
			other.GetComponent<BreakableObject>().Break();
			SpawnHitEffect();
		}
		if (other.CompareTag("Boss"))
		{
			other.GetComponentInParent<BossController>().TakeDamage(_damageToDeal);
			SpawnHitEffect();
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods

	void SpawnHitEffect()
	{
		Instantiate(_hitEffect, transform.position, Quaternion.identity);
	}
	#endregion
}
