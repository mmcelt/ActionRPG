using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
	#region Fields & Properties

	public static PlayerHealthController Instance;

	[SerializeField] GameObject _deathEffect;
	public int _currentHealth, _maxHealth;
	[SerializeField] float _invincibilityLength = 1f;

	float _invincibilityCounter;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			//DontDestroyOnLoad(gameObject);
		}
		else if (Instance != this)
			Destroy(gameObject);
	}

	void Start() 
	{
		_currentHealth = _maxHealth;
		//_currentHealth = 20;	//TESTING
		UIManager.Instance.UpdateHealth();
	}
	
	void Update() 
	{
		if (_invincibilityCounter > 0)
		{
			_invincibilityCounter -= Time.deltaTime;
		}
	}
	#endregion

	#region Public Methods

	public void DamagePlayer(int damageAmount)
	{
		if (_invincibilityCounter > 0) return;

		//clamp _currentHealth to 0 or more
		_currentHealth = Mathf.Max(_currentHealth - damageAmount, 0);
		_invincibilityCounter = _invincibilityLength;
		AudioManager.Instance.PlaySFX(7);

		if (_currentHealth == 0)
		{
			gameObject.SetActive(false);
			Instantiate(_deathEffect, transform.position, Quaternion.identity);
			AudioManager.Instance.PlaySFX(4);
			GameManager.Instance.Respawn();
		}

		UIManager.Instance.UpdateHealth();
	}

	public void RestoreHealth(int healthToRestore)
	{
		_currentHealth = Mathf.Min(_currentHealth + healthToRestore, _maxHealth);
		UIManager.Instance.UpdateHealth();
	}
	#endregion

	#region Private Methods


	#endregion
}
