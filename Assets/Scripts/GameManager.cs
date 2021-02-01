using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	#region Fields & Properties

	public static GameManager Instance;

	public int _currentCoins;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy(gameObject);

		//DontDestroyOnLoad(gameObject);
	}

	void Start() 
	{
		UIManager.Instance.UpdateCoins();
	}
	#endregion

	#region Public Methods

	public void GetCoins(int coinsToAdd)
	{
		_currentCoins += coinsToAdd;
		UIManager.Instance.UpdateCoins();
	}
	#endregion

	#region Private Methods


	#endregion
}
