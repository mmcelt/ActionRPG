using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] float _moveSpeed;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start() 
	{
		
	}
	
	void Update() 
	{
		transform.position = new Vector3(transform.position.x + Input.GetAxisRaw("Horizontal") * _moveSpeed * Time.deltaTime, transform.position.y + Input.GetAxisRaw("Vertical") * _moveSpeed * Time.deltaTime);
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
