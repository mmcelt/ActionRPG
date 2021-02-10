using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LevelStartActions : MonoBehaviour
{	
	#region Fields & Properties

	
	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start() 
	{
		PlayerController.Instance.DoAtLevelStart();

		Invoke(nameof(TurnOffLoadingScreen), 0.1f);

		SaveManager.Instance._activeSave._currentScene = SceneManager.GetActiveScene().name;
		SaveManager.Instance._activeSave._sceneStartPosition = PlayerController.Instance.transform.position;

		SaveManager.Instance.SaveData();	//save data to disk...
	}
	#endregion

	#region Private Methods

	void TurnOffLoadingScreen()
	{
		UIManager.Instance._loadingScreen.SetActive(false);
	}
	#endregion
}
