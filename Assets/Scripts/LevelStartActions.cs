using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
