using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
	#region Fields & Properties

	[TextArea] [SerializeField] string _description;
	[SerializeField] int _itemCost;

	bool _itemActive;

	#endregion

	#region Getters


	#endregion

	#region Unity Methods

	void Start() 
	{
		
	}
	
	void Update() 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			_itemActive = true;
			DialogManager.Instance._dialogPanel.SetActive(true);
			DialogManager.Instance._dialogText.text = _description;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			_itemActive = false;
			DialogManager.Instance._dialogPanel.SetActive(false);
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
