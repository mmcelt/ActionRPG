using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] float _moveSpeed;
	[SerializeField] int _damageToDo;

	Vector3 _moveDir;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start() 
	{
		_moveDir = PlayerController.Instance.transform.position - transform.position;
		_moveDir.Normalize();
	}
	
	void Update() 
	{
		transform.position += _moveDir * _moveSpeed * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			PlayerHealthController.Instance.DamagePlayer(_damageToDo);
			Destroy(gameObject);
		}
		Destroy(gameObject);
	}

	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
