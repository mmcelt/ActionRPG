using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] float _moveSpeed;
	[SerializeField] SpriteRenderer _theSR;
	[SerializeField] Sprite[] _playerDirectionSprites;

	Rigidbody2D _theRB;
	Animator _theAnim;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start() 
	{
		_theRB = GetComponent<Rigidbody2D>();
		_theAnim = GetComponent<Animator>();
	}
	
	void Update() 
	{
		//transform.position = new Vector3(transform.position.x + Input.GetAxisRaw("Horizontal") * _moveSpeed * Time.deltaTime, transform.position.y + Input.GetAxisRaw("Vertical") * _moveSpeed * Time.deltaTime);

		_theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * _moveSpeed;

		_theAnim.SetFloat("Speed", _theRB.velocity.magnitude);

		if (_theRB.velocity != Vector2.zero)
		{
			if (Input.GetAxisRaw("Horizontal") != 0)
			{
				_theSR.sprite = _playerDirectionSprites[1];

				if (Input.GetAxisRaw("Horizontal") < 0)
				{
					_theSR.flipX = true;
				}
				else
				{
					_theSR.flipX = false;
				}
			}
			else
			{
				if (Input.GetAxisRaw("Vertical") < 0)
				{
					_theSR.sprite = _playerDirectionSprites[0];
				}
				else
				{
					_theSR.sprite = _playerDirectionSprites[2];
				}
			}
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
