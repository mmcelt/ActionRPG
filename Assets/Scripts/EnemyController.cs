using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	#region Fields & Properties

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
		_waitCounter = _waitTime;
	}
	
	void Update() 
	{
		if (_waitCounter > 0)
		{
			_waitCounter -= Time.deltaTime;
			_theRB.velocity = Vector2.zero;

			if (_waitCounter <= 0)
			{
				_moveCounter = _moveTime;
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
				_waitCounter = _waitTime;
				_theAnim.SetBool("Moving", false);
			}
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
