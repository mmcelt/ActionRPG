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
		UpdateHealth();
	}
	
	void Update() 
	{
		
	}
	#endregion

	#region Public Methods

	public void UpdateHealth()
	{
		_healthSlider.maxValue = PlayerHealthController.Instance._maxHealth;
		_healthSlider.value = PlayerHealthController.Instance._currentHealth;
		_healthText.text = $"HEALTH: {PlayerHealthController.Instance._currentHealth}/{PlayerHealthController.Instance._maxHealth}";
	}
	#endregion

	#region Private Methods


	#endregion
}
