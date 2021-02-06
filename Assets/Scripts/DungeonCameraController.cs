using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCameraController : MonoBehaviour
{
	#region Fields & Properties

	public static DungeonCameraController Instance;

	public Vector3 _targetPoint;

	[SerializeField] float _moveSpeed;

	[Header("Boss Room")]
	public bool _inBossRoom;

	Vector3 _limitUpper, _limitLower;

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
		if (_inBossRoom)
		{
			_targetPoint.y = Mathf.Clamp(PlayerController.Instance.transform.position.y, _limitLower.y, _limitUpper.y);
		}
		transform.position = Vector3.MoveTowards(transform.position, _targetPoint, _moveSpeed * Time.deltaTime);
	}
	#endregion

	#region Public Methods

	public void ActivateBossRoom(Vector3 upper, Vector3 lower)
	{
		_inBossRoom = true;
		_limitUpper = upper;
		_limitLower = lower;
	}
	#endregion

	#region Private Methods


	#endregion
}
