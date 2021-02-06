using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
	#region Fields & Properties

	public string _bossName;
	[SerializeField] int _bossHealth;
	[SerializeField] GameObject _deathEffect;
	[SerializeField] GameObject _theBossSprite, _door;
	[SerializeField] Transform[] _spawnPoints;
	[SerializeField] float _moveSpeed, _timeActive, _timeBetweenSpawns, _initalSpawnDelay;

	Vector3 _moveTarget;
	float _activeCounter, _spawnCounter;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start() 
	{
		_door.SetActive(true);
		_spawnCounter = _initalSpawnDelay;
	}
	
	void Update() 
	{
		if (_bossHealth <= 0) return;

		if (_spawnCounter > 0)
		{
			_spawnCounter -= Time.deltaTime;

			if (_spawnCounter <= 0)
			{
				_activeCounter = _timeActive;

				_theBossSprite.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;

				_moveTarget = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;

				while (_moveTarget == _theBossSprite.transform.position)
				{
					_moveTarget = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
				}

				_theBossSprite.SetActive(true);
			}
		}
		else
		{
			_activeCounter -= Time.deltaTime;

			if (_activeCounter <= 0)
			{
				_spawnCounter = _timeBetweenSpawns;
				_theBossSprite.SetActive(false);
			}

			_theBossSprite.transform.position = Vector3.MoveTowards(_theBossSprite.transform.position, _moveTarget, _moveSpeed * Time.deltaTime);
		}
	}
	#endregion

	#region Public Methods

	public void TakeDamage(int damageToTake)
	{

		_bossHealth = Mathf.Max(_bossHealth - damageToTake, 0);

		if (_bossHealth == 0)
		{
			Instantiate(_deathEffect, _theBossSprite.transform.position, Quaternion.identity);

			_theBossSprite.SetActive(false);
			_door.SetActive(false);
		}
	}
	#endregion

	#region Private Methods


	#endregion
}
