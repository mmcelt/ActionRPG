using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressChecker : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] string _progressToCheck;
	[SerializeField] bool _deactivateIfMarked;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start() 
	{
		bool isMarked = SaveManager.Instance.CheckProgress(_progressToCheck);

		if(_deactivateIfMarked)
		{
			gameObject.SetActive(!isMarked);
		}
		else
		{
			gameObject.SetActive(isMarked);
		}
	}
	
	void Update() 
	{
		
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
