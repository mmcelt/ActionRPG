using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	#region Fields & Properties

	public static AudioManager Instance;

	[SerializeField] AudioSource[] _soundFX;

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
		PlayerPrefs.SetInt("Screenmanager Is Fullscreen mode", 0);
		PlayerPrefs.SetInt("Screenmanager Resolution Height", 1080);
		PlayerPrefs.SetInt("Screenmanager Resolution Width", 1920);
	}
	#endregion

	#region Public Methods

	public void PlaySFX(int index)
	{
		_soundFX[index].Stop();
		_soundFX[index].Play();
	}
	#endregion

	#region Private Methods


	#endregion
}
