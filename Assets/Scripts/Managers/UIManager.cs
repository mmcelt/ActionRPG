using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager: MonoBehaviour
{
	#region Fields & Properties

	public static UIManager Instance;

	[SerializeField] Slider _healthSlider;
	[SerializeField] TMP_Text _healthText;

	[SerializeField] Slider _staminaSlider;
	[SerializeField] TMP_Text _staminaText;
	[SerializeField] TMP_Text _coinText;

	public GameObject _pauseScreen;
	public GameObject _loadingScreen;
	public CanvasGroup _loadingScreenCG;
	public GameObject _deathScreen;

	[SerializeField] string _mainMenuScene;

	public GameObject _bossHealthbar;
	[SerializeField] Slider _bossHealthSlider;
	[SerializeField] TMP_Text _bossNameText;

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
		
	}
	#endregion

	#region UI Callbacks

	public void OnResumeButtonClickded()
	{
		GameManager.Instance.PauseUnPause();
	}

	public void OnMainMenuButtonClicked()
	{
		SceneManager.LoadScene(_mainMenuScene);
		Time.timeScale = 1f;
	}

	public void OnQuitButtonClicked()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
		Application.Quit();
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

	public void UpdateStamina(float stamina)
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
	public void UpdateBossHealthbar(int maxHealth, int currentHealth, string name)
	{
		_bossHealthSlider.maxValue = maxHealth;
		_bossHealthSlider.value = currentHealth;
		_bossNameText.text = name;
	}
	#endregion

	#region Private Methods


	#endregion
}
