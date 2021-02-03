using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
	#region Fields & Properties

	public static DialogManager Instance;

	public GameObject _dialogPanel;
	[SerializeField] TMP_Text _dialogText;

	[SerializeField] string[] _dialogLines;
	[SerializeField] int _currentLine;

	bool _justStarted;

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

	void Update() 
	{
		if (_dialogPanel.activeInHierarchy)
		{
			if (Input.GetMouseButtonUp(0))
			{
				if (!_justStarted)
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
				else
				{
					_justStarted = false;
				}
			}
		}
	}
	#endregion

	#region Public Methods

	public void ShowDialog(string[] newLines)
	{
		_dialogLines = newLines;
		_currentLine = 0;
		_dialogText.text = _dialogLines[_currentLine];
		_dialogPanel.SetActive(true);
		_justStarted = true;
	}
	#endregion

	#region Private Methods


	#endregion
}
