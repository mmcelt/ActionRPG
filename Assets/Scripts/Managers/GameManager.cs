using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	#region Fields & Properties

	public static GameManager Instance;

	public int _currentCoins;
	public bool _dialogActive;

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
		UIManager.Instance.UpdateCoins();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			PauseUnPause();
		}
	}
	#endregion

	#region Public Methods

	public void GetCoins(int coinsToAdd)
	{
		_currentCoins += coinsToAdd;
		UIManager.Instance.UpdateCoins();
	}

	public void PauseUnPause()
	{
		if (!UIManager.Instance._pauseScreen.activeInHierarchy)
		{
			UIManager.Instance._pauseScreen.SetActive(true);
			Time.timeScale = 0f;
			PlayerController.Instance._canMove = false;
		}
		else
		{
			UIManager.Instance._pauseScreen.SetActive(false);
			Time.timeScale = 1f;
			PlayerController.Instance._canMove = true;
		}
	}
	#endregion

	#region Private Methods


	#endregion
}
