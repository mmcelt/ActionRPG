using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] string[] _dialogLines;

	bool _canActivate;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start()
	{
		
	}

	void Update()
	{
		if (_canActivate && Input.GetMouseButtonDown(0) && !DialogManager.Instance._dialogPanel.activeInHierarchy)
		{
			DialogManager.Instance.ShowDialog(_dialogLines, true);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			_canActivate = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			_canActivate = false;
		}
	}
		#endregion

		#region Public Methods


		#endregion

		#region Private Methods


		#endregion
	
}
