using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    // Reference to the UI Text for displaying player's money
    public Text moneyText;

    // Optional: References for item details if you're reusing this HUD for items
    public Text itemNameText;
    public Text itemPriceText;
	string itemName;

    // This method updates the player's money display
    public void SetPlayerMoney(int money)
    {
        // Ensure that a Text component is assigned
        if(moneyText != null)
        {
            moneyText.text = "Money: " + money.ToString();
        }
        else
        {
            Debug.LogWarning("moneyText is not assigned in the inspector.");
        }
    }

    // This method sets the item details in the HUD, if you're also using it for the shop's item display.
    public void SetItemDetails(string itemName, int price)
    {
		itemName = name;
        if(itemNameText != null && itemPriceText != null)
        {
            itemNameText.text = itemName;
            itemPriceText.text = "Price: " + price.ToString();
        }
        else
        {
            Debug.LogWarning("itemNameText and/or itemPriceText are not assigned in the inspector.");
        }
    }

	public string GetItemName()
    {
        return itemName;
    }
}
