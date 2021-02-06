using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] float _moveSpeed, _rotationSpeed;
	[SerializeField] int _damageToDo;

	Vector3 _moveDir;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start()
	{

	}

	void Update()
	{
		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + (_rotationSpeed * Time.deltaTime));
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

	public void SetDirection(Vector3 spawnerPosition)
	{
		_moveDir = transform.position - spawnerPosition;
	}
	#endregion

	#region Private Methods


	#endregion
}
