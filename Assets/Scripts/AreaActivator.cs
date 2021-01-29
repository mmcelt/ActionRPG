using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaActivator : MonoBehaviour
{
	#region Fields & Properties

	BoxCollider2D _areaBox;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start() 
	{
		_areaBox = GetComponent<BoxCollider2D>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			CameraController.Instance._areaBox = _areaBox;
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
