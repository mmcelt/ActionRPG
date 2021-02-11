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
	public bool _canMove;

	[HideInInspector] public Rigidbody2D _theRB;

	Animator _theAnim;

	[Header("Damaged")]
	[SerializeField] float _knockBackTime;
	[SerializeField] float _knockBackForce;
	[SerializeField] GameObject _hitEffectPrefab;

	bool _isKnockingBack;
	float _knockBackCounter;
	Vector2 _knockBackDirection;

	[Header("Dashing")]
	[SerializeField] float _dashSpeed;
	[SerializeField] float _dashLength;
	[SerializeField] float _dashStaminaCost;

	float _dashCounter, _activeMoveSpeed;

	[Header("Stamina System")]
	public float _totalStamina;
	[SerializeField] float _staminaRefillSpeed;

	[HideInInspector] public float _currentStamina;

	[Header("Spin Attack")]
	[SerializeField] float _spinCost;
	[SerializeField] float _spinCooldown;

	float _spinCounter;
	bool _isSpinning;

	[Header("Sword Upgrades")]
	[SerializeField] SpriteRenderer _swordSR;
	[SerializeField] Sprite[] _allSwords;
	[SerializeField] DamageEnemy _swordDamage;
	[SerializeField] int _currentSword;

	Vector3 _respawnPos;

	#endregion

	#region Getters

	#endregion

	#region Unity Methods

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (Instance != this)
			Destroy(gameObject);
	}

	void Start() 
	{
		transform.position = SaveManager.Instance._activeSave._sceneStartPosition;
		_currentSword = SaveManager.Instance._activeSave._currentSword;
		_swordSR.sprite = _allSwords[_currentSword];
		_swordDamage._damageToDeal = SaveManager.Instance._activeSave._swordDamage;
		_totalStamina = SaveManager.Instance._activeSave._maxStamina;

		_theRB = GetComponent<Rigidbody2D>();
		_theAnim = GetComponent<Animator>();
		_activeMoveSpeed = _moveSpeed;
		_currentStamina = _totalStamina;
		UIManager.Instance.UpdateStamina(Mathf.RoundToInt(_currentStamina));
		_canMove = true;
	}
	
	void Update() 
	{
		if (_canMove && !GameManager.Instance._dialogActive)
		{
			if (!_isKnockingBack)
			{
				//Moving...
				Movement();
				//Attacking...
				Attacking();
				//Dashing...
				Dashing();
				//Spin Attack...
				SpinAttack();
				//Stamina...
				Stamina();
			}
			else
			{
				_knockBackCounter -= Time.deltaTime;
				_theRB.velocity = _knockBackDirection * _knockBackForce;

				if (_knockBackCounter <= 0)
				{
					_isKnockingBack = false;
				}
			}
		}
		else
		{
			_theRB.velocity = Vector2.zero;
			_theAnim.SetFloat("Speed", 0f);
		}
	}
	#endregion

	#region Public Methods

	public void KnockBack(Vector3 knockerPosition)
	{
		_knockBackCounter = _knockBackTime;
		_isKnockingBack = true;

		_knockBackDirection = transform.position - knockerPosition;
		_knockBackDirection.Normalize();
		Instantiate(_hitEffectPrefab, transform.position, Quaternion.identity);
	}

	public void DoAtLevelStart()
	{
		_canMove = true;
		_respawnPos = transform.position;
		UIManager.Instance.UpdateHealth();
	}

	public void RestoreStamina(int staminaToRestore)
	{
		_currentStamina = Mathf.Min(_currentStamina + staminaToRestore, _totalStamina);
		UIManager.Instance.UpdateStamina(Mathf.RoundToInt(_currentStamina));
	}

	public void UpgradeSword(int newDamage, int newSwordRef)
	{
		_swordDamage._damageToDeal = newDamage;
		_currentSword = newSwordRef;
		_swordSR.sprite = _allSwords[_currentSword];
		SaveManager.Instance._activeSave._swordDamage = newDamage;
		SaveManager.Instance._activeSave._currentSword = newSwordRef;
	}

	public void ResetOnRespawn()
	{
		transform.position = _respawnPos;
		_canMove = false;
		gameObject.SetActive(true);
		_currentStamina = _totalStamina;
		_knockBackCounter = 0f;
		PlayerHealthController.Instance._currentHealth = PlayerHealthController.Instance._maxHealth;

		UIManager.Instance.UpdateHealth();
		UIManager.Instance.UpdateStamina(_totalStamina);
	}
	#endregion

	#region Private Methods

	void Movement()
	{
		//transform.position = new Vector3(transform.position.x + Input.GetAxisRaw("Horizontal") * _moveSpeed * Time.deltaTime, transform.position.y + Input.GetAxisRaw("Vertical") * _moveSpeed * Time.deltaTime);

		_theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * _activeMoveSpeed;

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
	}

	void Attacking()
	{
		if (Input.GetMouseButtonDown(0) && !_isSpinning)
		{
			_weaponAnim.SetTrigger("Attack");
			AudioManager.Instance.PlaySFX(0);
		}
	}

	void Dashing()
	{
		if (_dashCounter <= 0)
		{
			if (Input.GetKeyDown(KeyCode.Space) && _currentStamina >= _dashStaminaCost)
			{
				_activeMoveSpeed = _dashSpeed;
				_dashCounter = _dashLength;
				_currentStamina -= _dashStaminaCost;
			}
		}
		else
		{
			_dashCounter -= Time.deltaTime;

			if (_dashCounter <= 0)
			{
				_activeMoveSpeed = _moveSpeed;
			}
		}
	}

	void SpinAttack()
	{
		if (_spinCounter <= 0)
		{
			if (Input.GetMouseButtonDown(1) && _currentStamina >= _spinCost)
			{
				_weaponAnim.SetTrigger("SpinAttack");
				_currentStamina -= _spinCost;
				_spinCounter = _spinCooldown;
				_isSpinning = true;
				AudioManager.Instance.PlaySFX(0);
			}
		}
		else
		{
			_spinCounter -= Time.deltaTime;

			if (_spinCounter <= 0)
			{
				_isSpinning = false;
			}
		}
	}

	void Stamina()
	{
		_currentStamina = Mathf.Min(_currentStamina + _staminaRefillSpeed * Time.deltaTime, _totalStamina);
		UIManager.Instance.UpdateStamina(Mathf.RoundToInt(_currentStamina));
	}
	#endregion
}
