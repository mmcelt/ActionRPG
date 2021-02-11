using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;

public class SaveManager: MonoBehaviour
{
	#region Fields & Properties

	public static SaveManager Instance;

	public SaveData _activeSave;

	SaveData _defaultData;

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
			_defaultData = _activeSave;
			LoadData();
		}
		else if (Instance != this)
			Destroy(gameObject);
	}

	void Start()
	{
		//_dataPath = Application.persistentDataPath;
	}

	void OnApplicationQuit()
	{
		UpdateAllData();
		SaveData();
	}
	#endregion

	#region Public Methods

	public void LoadData()
	{
		string _dataPath = Application.persistentDataPath;
		if (File.Exists(_dataPath + "/save.data"))
		{
			var serializer = new XmlSerializer(typeof(SaveData));
			var stream = new FileStream(_dataPath + "/save.data", FileMode.Open);
			_activeSave = serializer.Deserialize(stream) as SaveData;
			stream.Close();

			Debug.Log("Data Loaded");
		}
	}

	public void SaveData()
	{
		string _dataPath = Application.persistentDataPath;
		var serializer = new XmlSerializer(typeof(SaveData));
		var stream = new FileStream(_dataPath + "/save.data", FileMode.Create);
		serializer.Serialize(stream, _activeSave);
		stream.Close();

		Debug.Log("Data Saved");
	}

	public void ResetSave()
	{
		_activeSave = _defaultData;
	}

	public void UpdateAllData()
	{
		_activeSave._sceneStartPosition = PlayerController.Instance.transform.position;
		_activeSave._currentHealth = PlayerHealthController.Instance._currentHealth;
	}

	public void MarkProgress(string progressToMark)
	{
		bool found = false;

		foreach(var progress in _activeSave.Progress)
		{
			if (progress.Name == progressToMark)
			{
				progress.IsMarked = true;
				found = true;
				break;
			}
		}
		if (!found)
			Debug.LogError($"Progress entry not found for: {progressToMark}!");
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
	public int _currentHealth, _maxHealth, _currentSword, _swordDamage, _currentCoins;
	public float _maxStamina;
	public List<ProgressItem> Progress = new List<ProgressItem>();
}

[System.Serializable]
public class ProgressItem
{
	public string Name;
	public bool IsMarked;
}
