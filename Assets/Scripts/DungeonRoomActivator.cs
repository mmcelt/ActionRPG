using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonRoomActivator : MonoBehaviour
{	
	#region Fields & Properties

	
	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start() 
	{
		
	}
	
	void Update() 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			DungeonCameraController.Instance._targetPoint = new Vector3(transform.position.x, transform.position.y, DungeonCameraController.Instance._targetPoint.z);
		}
	}

	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
