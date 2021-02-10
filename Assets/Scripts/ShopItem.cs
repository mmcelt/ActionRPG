using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
	#region Fields & Properties

	[TextArea] [SerializeField] string _description;
	[SerializeField] int _itemCost;
	[SerializeField] bool _isHealthUpgrade, _isStaminaUpgrade, _removeAfterPurchase;
	[SerializeField] int _amountToAdd;

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
		if (_itemActive)
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (GameManager.Instance._currentCoins >= _itemCost)
				{
					GameManager.Instance._currentCoins -= _itemCost;
					SaveManager.Instance._activeSave._currentCoins = GameManager.Instance._currentCoins;

					UIManager.Instance.UpdateCoins();

					if (_isHealthUpgrade)
					{
						PlayerHealthController.Instance._maxHealth += _amountToAdd;
						PlayerHealthController.Instance._currentHealth = PlayerHealthController.Instance._maxHealth;
						SaveManager.Instance._activeSave._maxHealth = PlayerHealthController.Instance._maxHealth;
						UIManager.Instance.UpdateHealth();
					}
					if (_isStaminaUpgrade)
					{
						PlayerController.Instance._totalStamina += _amountToAdd;
						SaveManager.Instance._activeSave._maxStamina = PlayerController.Instance._totalStamina;
						UIManager.Instance.UpdateStamina(PlayerController.Instance._totalStamina);
					}
					if (_removeAfterPurchase)
					{
						gameObject.SetActive(false);
					}
					DialogManager.Instance._dialogPanel.SetActive(false);
					_itemActive = false;
				}
				else
				{
					DialogManager.Instance._dialogText.text = "<b><color=red>You are gold challenged!</color></b>";
				}
			}
		}
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
