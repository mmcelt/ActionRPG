using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] string _startingScene;
	[SerializeField] GameObject _continueButton;

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

		if (SaveManager.Instance._activeSave.HasBegun)
			_continueButton.SetActive(true);
	}
	#endregion

	#region Public Methods

	public void StartGame()
	{
		SceneManager.LoadScene(_startingScene);
		SaveManager.Instance.ResetSave();
		SaveManager.Instance._activeSave.HasBegun = true;
	}

	public void QuitGame()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
		Application.Quit();
	}

	public void ContinueGame()
	{
		SceneManager.LoadScene(SaveManager.Instance._activeSave.CurrentScene);
	}
	#endregion

	#region Private Methods


	#endregion
}
