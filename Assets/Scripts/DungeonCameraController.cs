using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCameraController : MonoBehaviour
{
	#region Fields & Properties

	public static DungeonCameraController Instance;

	public Vector3 _targetPoint;

	[SerializeField] float _moveSpeed;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			//DontDestroyOnLoad(gameObject);
		}
		else if (Instance != this)
			Destroy(gameObject);
	}

	void Start() 
	{
		_targetPoint.z = transform.position.z;
	}
	
	void LateUpdate() 
	{
		transform.position = Vector3.MoveTowards(transform.position, _targetPoint, _moveSpeed * Time.deltaTime);
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
