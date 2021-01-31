using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] int _healthToRestore;
	[SerializeField] float _lifeTime;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start() 
	{
		if (_lifeTime > 0f)
		{
			Destroy(gameObject, _lifeTime);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			PlayerHealthController.Instance.RestoreHealth(_healthToRestore);
			Destroy(gameObject);
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
