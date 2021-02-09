using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	#region Fields & Properties

	public static GameManager Instance;

	public int _currentCoins;
	public bool _dialogActive;
	public float _waitForDeathScreen = 1f, _waitForRespawn = 2;

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

	public void Respawn()
	{
		StartCoroutine(RespawnRoutine());
	}
	#endregion

	#region Private Methods

	IEnumerator RespawnRoutine()
	{
		yield return new WaitForSeconds(_waitForDeathScreen);
		UIManager.Instance._deathScreen.SetActive(true);
		yield return new WaitForSeconds(_waitForRespawn);
		//UIManager.Instance._deathScreen.SetActive(false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		UIManager.Instance._loadingScreen.SetActive(true);
		PlayerController.Instance.ResetOnRespawn();
	}
	#endregion
}
