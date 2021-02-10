using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class SaveManager: MonoBehaviour
{
	#region Fields & Properties

	public static SaveManager Instance;

	public SaveData _activeSave;

	string _dataPath;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (Instance != this)
			Destroy(gameObject);
	}

	void Start()
	{
		_dataPath = Application.persistentDataPath;
	}
	#endregion

	#region Public Methods

	public void LoadData()
	{

	}

	public void SaveData()
	{
		
	}
	#endregion

	#region Private Methods


	#endregion
}

[System.Serializable]
public class SaveData
{
	public bool _hasBegun;
	public Vector3 _sceneStartPosition;
	public string _currentScene;
	public int _maxHealth, _currentSword, _swordDamage, _currentCoins;
	public float _maxStamina;
}
