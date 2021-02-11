using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
	#region Fields & Properties

	public string _bossName;
	[SerializeField] int _bossMaxHealth, _bossHealth;
	[SerializeField] GameObject _deathEffect;
	[SerializeField] GameObject _theBossSprite, _door;
	[SerializeField] Transform[] _spawnPoints;
	[SerializeField] float _moveSpeed, _timeActive, _timeBetweenSpawns, _initalSpawnDelay;
	[SerializeField] AudioSource _levelBGM, _bossBattleBGMS;
	[SerializeField] GameObject _victoryObject;
	[SerializeField] string _progressToMark;

	Vector3 _moveTarget;
	float _activeCounter, _spawnCounter;

	[Header("Shooting")]
	[SerializeField] BossBullet _bossBulletPrefab;
	[SerializeField] Transform[] _firePoints;
	[SerializeField] Transform _fireCenter;
	[SerializeField] float _timeBetweenShots, _shotRotateSpeed, _shootTime;
	[SerializeField] int _stage2Threshold, _stage3Threshold;

	float _shotCounter, _shootingCounter;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start()
	{
		if (SaveManager.Instance.CheckProgress(_progressToMark))
		{
			gameObject.SetActive(false);
		}
		else
		{
			_bossHealth = _bossMaxHealth;
			_door.SetActive(true);
			_spawnCounter = _initalSpawnDelay;
			UIManager.Instance._bossHealthbar.SetActive(true);
			UIManager.Instance.UpdateBossHealthbar(_bossMaxHealth, _bossHealth, _bossName);
			_levelBGM.Stop();
			_bossBattleBGMS.Play();
		}
	}

	void Update()
	{
		if (SaveManager.Instance.CheckProgress(_progressToMark)) return;

		if (_bossHealth <= 0) return;

		if (_spawnCounter > 0)
		{
			_spawnCounter -= Time.deltaTime;

			if (_spawnCounter <= 0)
			{
				_activeCounter = _timeActive;
				_shootingCounter = _shootTime;

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
			//shooting...
			if (_shootingCounter > 0)
			{
				_shootingCounter -= Time.deltaTime;

				_shotCounter -= Time.deltaTime;

				if (_shotCounter <= 0)
				{
					_shotCounter = _timeBetweenShots;

					if (_bossHealth > _stage2Threshold)
					{
						for (int i = 0; i < 4; i++)
						{
							Instantiate(_bossBulletPrefab, _firePoints[i].position, _firePoints[i].rotation).SetDirection(_fireCenter.position);
						}
					}
					else
					{
						for (int i = 0; i < _firePoints.Length; i++)
						{
							Instantiate(_bossBulletPrefab, _firePoints[i].position, _firePoints[i].rotation).SetDirection(_fireCenter.position);
						}
					}
				}

				if (_bossHealth <= _stage3Threshold)
				{
					_fireCenter.transform.rotation = Quaternion.Euler(_fireCenter.transform.rotation.eulerAngles.x, _fireCenter.transform.rotation.eulerAngles.y, _fireCenter.transform.rotation.eulerAngles.z + (_shotRotateSpeed * Time.deltaTime));
				}
			}
		}
	}
	#endregion

	#region Public Methods

	public void TakeDamage(int damageToTake)
	{

		_bossHealth = Mathf.Max(_bossHealth - damageToTake, 0);

		UIManager.Instance.UpdateBossHealthbar(_bossMaxHealth, _bossHealth, _bossName);

		if (_bossHealth == 0)
		{
			Instantiate(_deathEffect, _theBossSprite.transform.position, Quaternion.identity);

			_theBossSprite.SetActive(false);
			//_door.SetActive(false);
			UIManager.Instance._bossHealthbar.SetActive(false);
			_bossBattleBGMS.Stop();
			_levelBGM.Play();

			_victoryObject.SetActive(true);

			SaveManager.Instance.MarkProgress(_progressToMark);
		}
	}
	#endregion

	#region Private Methods


	#endregion
}
