using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
		//if (UIManager.Instance._loadingScreen.GetComponent<Image>().color.a > 0f)
		//{
		//	UIManager.Instance._loadingScreen.SetActive(false);
		//}

		Invoke(nameof(TurnOffLoadingScreen), 0.1f);
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods

	void TurnOffLoadingScreen()
	{
		UIManager.Instance._loadingScreen.SetActive(false);
	}
	#endregion
}
