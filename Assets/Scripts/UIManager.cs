using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager: MonoBehaviour
{
	#region Fields & Properties

	public static UIManager Instance;

	public Slider _healthSlider;
	public TMP_Text _healthText;

	public Slider _staminaSlider;
	public TMP_Text _staminaText;

	public TMP_Text _coinText;

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

		//DontDestroyOnLoad(gameObject);
	}

	void Start() 
	{
		
	}
	#endregion

	#region Public Methods

	public void UpdateHealth()
	{
		//health
		_healthSlider.maxValue = PlayerHealthController.Instance._maxHealth;
		_healthSlider.value = PlayerHealthController.Instance._currentHealth;
		_healthText.text = $"HEALTH: {PlayerHealthController.Instance._currentHealth}/{PlayerHealthController.Instance._maxHealth}";
	}

	public void UpdateStamina(int stamina)
	{
		//stamina
		_staminaSlider.maxValue = PlayerController.Instance._totalStamina;
		_staminaSlider.value = stamina;
		_staminaText.text = $"STAMINA: {stamina}/{PlayerController.Instance._totalStamina}";
	}

	public void UpdateCoins()
	{
		_coinText.text = $"COINS: {GameManager.Instance._currentCoins}";
	}
	#endregion

	#region Private Methods


	#endregion
}
