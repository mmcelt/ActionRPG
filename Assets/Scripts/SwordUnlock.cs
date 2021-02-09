using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordUnlock : MonoBehaviour
{
	#region Fields & Properties

	[SerializeField] GameObject _exitDoor;
	public int _newSwordDamage, _swordSpriteRef;
	[SerializeField] string[] _pickupDialog;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start() 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			gameObject.SetActive(false);

			if(_exitDoor != null)
				_exitDoor.SetActive(false);
		}
		PlayerController.Instance.UpgradeSword(_newSwordDamage, _swordSpriteRef);

		if (_pickupDialog.Length > 0)
		{
			DialogManager.Instance.ShowDialog(_pickupDialog, false);
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
