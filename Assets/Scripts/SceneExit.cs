using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] string _sceneToLoad;
	[SerializeField] Vector3 _exitLocation;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			PlayerController.Instance.transform.position = _exitLocation;
			PlayerController.Instance._theRB.velocity = Vector2.zero;
			PlayerController.Instance._canMove = false;

			SceneManager.LoadScene(_sceneToLoad);
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
