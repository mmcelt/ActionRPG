using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] GameObject _objectToSwitchOff;
	[SerializeField] Sprite _offSprite, _onSprite;

	bool _inRange, _isOn;

	SpriteRenderer _theSprite;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start()
	{
		_theSprite = GetComponent<SpriteRenderer>();
		_theSprite.sprite = _offSprite;
	}

	void Update()
	{
		if (_inRange)
		{
			if (Input.GetMouseButtonDown(0))
			{
				_isOn = !_isOn;
				_objectToSwitchOff.SetActive(!_isOn);
				if (_isOn)
					_theSprite.sprite = _onSprite;
				else
					_theSprite.sprite = _offSprite;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			_inRange = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			_inRange = false;
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}


