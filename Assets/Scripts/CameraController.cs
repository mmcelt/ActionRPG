using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] Transform _target;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start() 
	{
		_target = PlayerController.Instance.transform;
	}
	
	void LateUpdate() 
	{
		transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y, transform.position.z);
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
