using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] BoxCollider2D _area;
	[SerializeField] Rigidbody2D _theRB;
	[SerializeField] Animator _theAnim;
	[SerializeField] float _moveSpeed, _waitTime, _moveTime;

	float _waitCounter, _moveCounter;

	Vector2 _moveDirection;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start() 
	{
		_waitCounter = Random.Range(_waitTime * 0.75f, _waitTime * 1.25f);
	}
	
	void Update() 
	{
		if (_waitCounter > 0)
		{
			_waitCounter -= Time.deltaTime;
			_theRB.velocity = Vector2.zero;

			if (_waitCounter <= 0)
			{
				_moveCounter = Random.Range(_moveTime * 0.75f, _moveTime * 1.25f);
				_theAnim.SetBool("Moving", true);

				_moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
				_moveDirection.Normalize();
			}
		}
		else
		{
			_moveCounter -= Time.deltaTime;
			_theRB.velocity = _moveDirection * _moveSpeed;

			if (_moveCounter <= 0)
			{
				_waitCounter = Random.Range(_waitTime * 0.75f, _moveTime * 1.25f);
				_theAnim.SetBool("Moving", false);
			}
		}
		//restrict the enemy to his home area...
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, _area.bounds.min.x + 1f, _area.bounds.max.x - 1f), 
			Mathf.Clamp(transform.position.y, _area.bounds.min.y + 1f, _area.bounds.max.y - 1f),
			transform.position.z);
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
