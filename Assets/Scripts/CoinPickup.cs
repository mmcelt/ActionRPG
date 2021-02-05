using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] int _coinValue;
	[SerializeField] float _waitToPickup = 0.5f;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Update()
	{
		if (_waitToPickup > 0)
			_waitToPickup -= Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player") && _waitToPickup <= 0)
		{
			GameManager.Instance.GetCoins(_coinValue);
			AudioManager.Instance.PlaySFX(3);
			Destroy(gameObject);
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
