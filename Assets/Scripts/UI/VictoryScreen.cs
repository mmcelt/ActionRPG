using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] string _mainMenuScene;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start() 
	{
		if (GameManager.Instance != null)
		{
			Destroy(GameManager.Instance.gameObject);
			GameManager.Instance = null;
		}
		if (PlayerController.Instance != null)
		{
			Destroy(PlayerController.Instance.gameObject);
			PlayerController.Instance = null;
		}

		SaveManager.Instance._activeSave.HasBegun = false;
	}

	void Update() 
	{
		
	}
	#endregion

	#region Public Methods

	public void ReturnToMainMenu()
	{
		SceneManager.LoadScene(_mainMenuScene);
	}
	#endregion

	#region Private Methods


	#endregion
}
