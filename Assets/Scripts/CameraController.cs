using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] BoxCollider2D _areaBox;

	Transform _target;
	Camera _theCam;

	float _halfWidth, _halfHeight;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start() 
	{
		_theCam = GetComponent<Camera>();
		_target = PlayerController.Instance.transform;

		_halfHeight = _theCam.orthographicSize;
		_halfWidth = _theCam.orthographicSize * _theCam.aspect;
	}
	
	void LateUpdate() 
	{
		transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y, transform.position.z);

		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, _areaBox.bounds.min.x + _halfWidth, _areaBox.bounds.max.x - _halfWidth), 
			Mathf.Clamp(transform.position.y, _areaBox.bounds.min.y + _halfHeight, _areaBox.bounds.max.y - _halfHeight), 
			transform.position.z);
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
