using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] GameObject _dialogPanel;
	[SerializeField] TMP_Text _dialogText;

	[SerializeField] string[] _dialogLines;
	[SerializeField] int _currentLine;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start() 
	{
		
	}
	
	void Update() 
	{
		if (_dialogPanel.activeInHierarchy)
		{
			if (Input.GetMouseButtonUp(0))
			{
				_currentLine++;

				if (_currentLine >= _dialogLines.Length)
				{
					_dialogPanel.SetActive(false);
				}
				else
				{
					_dialogText.text = _dialogLines[_currentLine];
				}
			}
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
