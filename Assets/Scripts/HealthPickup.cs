using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] int _healthToRestore;
	[SerializeField] float _lifeTime;
	[SerializeField] float _waitToPickup = 0.5f;

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

	void Update()
	{
		if (_waitToPickup > 0)
			_waitToPickup -= Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player") && _waitToPickup <= 0)
		{
			PlayerHealthController.Instance.RestoreHealth(_healthToRestore);
			AudioManager.Instance.PlaySFX(6);
			Destroy(gameObject);
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
