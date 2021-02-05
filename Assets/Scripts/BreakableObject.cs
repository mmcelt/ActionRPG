using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] GameObject[] _itemsToDrop;
	[Range(0f,100f)] [SerializeField] float _chanceToDrop;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start() 
	{
		
	}
	#endregion

	#region Public Methods

	public void Break()
	{
		if (Random.Range(0f, 100f) <= _chanceToDrop)
		{
			if (_itemsToDrop.Length > 0)
			{
				Instantiate(_itemsToDrop[Random.Range(0, _itemsToDrop.Length)], transform.position, Quaternion.identity);
			}
		}
		Destroy(gameObject);
		AudioManager.Instance.PlaySFX(2);
	}
	#endregion

	#region Private Methods


	#endregion
}
