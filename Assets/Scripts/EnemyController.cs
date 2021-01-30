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

	[Header("Chasing")]
	[SerializeField] bool _shouldChase;
	[SerializeField] float _chaseSpeed, _rangeToChase, _waitAfterHitting;

	bool _isChasing;

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
		if (!_isChasing)
		{
			if (_waitCounter > 0)
			{
				//waiting phase...
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
				//movement phase...
				_moveCounter -= Time.deltaTime;
				_theRB.velocity = _moveDirection * _moveSpeed;

				if (_moveCounter <= 0)
				{
					_waitCounter = Random.Range(_waitTime * 0.75f, _moveTime * 1.25f);
					_theAnim.SetBool("Moving", false);
				}

				if (_shouldChase)
				{
					if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < _rangeToChase)
					{
						_isChasing = true;
					}
				}
			}
		}
		else
		{
			//chasing player...
			if (_waitCounter > 0)
			{
				_waitCounter -= Time.deltaTime;
				_theRB.velocity = Vector2.zero;

				if (_waitCounter <= 0)
				{
					_theAnim.SetBool("Moving", true);
				}
			}
			else
			{
				_moveDirection = PlayerController.Instance.transform.position - transform.position;
				_moveDirection.Normalize();
				_theRB.velocity = _moveDirection * _chaseSpeed;
			}

			if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) > _rangeToChase)
			{
				_isChasing = false;
				_waitCounter= Random.Range(_waitTime * 0.75f, _moveTime * 1.25f);
				_theAnim.SetBool("Moving", false);
			}
		}

		//restrict the enemy to his home area...
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, _area.bounds.min.x + 1f, _area.bounds.max.x - 1f), 
			Mathf.Clamp(transform.position.y, _area.bounds.min.y + 1f, _area.bounds.max.y - 1f),
			transform.position.z);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (_isChasing)
			{
				_waitCounter = _waitAfterHitting;
				_theAnim.SetBool("Moving", false);

				PlayerController.Instance.KnockBack(transform.position);
			}
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
