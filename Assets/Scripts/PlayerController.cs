using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	#region Fields & Properties

	public static PlayerController Instance;

	[SerializeField] float _moveSpeed;
	[SerializeField] SpriteRenderer _theSR;
	[SerializeField] Sprite[] _playerDirectionSprites;
	[SerializeField] Animator _weaponAnim;

	Rigidbody2D _theRB;
	Animator _theAnim;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
	}

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
					_weaponAnim.SetFloat("dirX", -1f);
					_weaponAnim.SetFloat("dirY", 0f);
				}
				else
				{
					_theSR.flipX = false;
					_weaponAnim.SetFloat("dirX", 1f);
					_weaponAnim.SetFloat("dirY", 0f);
				}
			}
			else
			{
				if (Input.GetAxisRaw("Vertical") < 0)
				{
					_theSR.sprite = _playerDirectionSprites[0];
					_weaponAnim.SetFloat("dirX", 0f);
					_weaponAnim.SetFloat("dirY", -1f);
				}
				else
				{
					_theSR.sprite = _playerDirectionSprites[2];
					_weaponAnim.SetFloat("dirX", 0f);
					_weaponAnim.SetFloat("dirY", 1f);
				}
			}
		}

		if (Input.GetMouseButtonDown(0))
		{
			_weaponAnim.SetTrigger("Attack");
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
