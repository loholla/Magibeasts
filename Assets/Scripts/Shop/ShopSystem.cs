using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This script implements a basic shop system that allows the player to purchase a shop item.
// In this example, we assume the shop sells a "Health Potion" with a static price of 10 coins.
public class ShopSystem : MonoBehaviour
{
    // The price of the shop item (static value)
    public int itemPrice = 10;

    // UI Text component for displaying shop dialogue/messages to the player
    public Text dialogueText;

    // Re-purposed HUD for the shop:
    // - 'itemHUD' (formerly EnemyBattleHud) will display item details (like name and price)
    //   and can be selected to highlight the item.
    // - 'playerHUD' (formerly PlayerBattleHud) will display the player's available money.
    public BattleHUD itemHUD;
    public BattleHUD playerHUD;

    // The player's available money (for example, starting at 50 coins)
    private int playerMoney = 50;

	private Button selectedItemButton;
	private Color originalColor;
	public Color selectedColor = Color.blue; // You can tweak this in the Inspector

	public Text levelText; // Assign this in the inspector

	public Inventory playerInventory;


    // Start is called before the first frame update
    void Start()
    {
        // Find the button by name ("buybutton") and attach the OnBuyButton listener.
        Button buyButton = GameObject.Find("buybutton").GetComponent<Button>();
        buyButton.onClick.AddListener(OnBuyButton);
		Button nextButton = GameObject.Find("NextButton").GetComponent<Button>();
		nextButton.onClick.AddListener(OnNextButton);

		// Make sure the player GameObject has this script
		playerInventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();

        // Initialize the shop display.
        SetupShop();
        
        // Assume itemHUD's GameObject has a Button component to register a click for selection.
        Button itemHUDButton = itemHUD.GetComponent<Button>();
        if (itemHUDButton != null)
        {
            itemHUDButton.onClick.AddListener(OnItemHUDSelected);
        }

		
    }

	void SetupShop()
	{
		if (itemHUD != null)
		{
			itemHUD.SetItemDetails("Health Potion", itemPrice);
		}

		// Set the dialogue panel text to include player money
		UpdateDialogueText();

		if (playerHUD != null)
		{
			playerHUD.SetPlayerMoney(playerMoney);
		}

	    if (levelText != null)
		{
			levelText.text = "Price: 10";
		}


	}

	void UpdateDialogueText()
	{
		dialogueText.text = $"Select an Item to Buy: Money = {playerMoney}";
	}

	public void OnItemButtonSelected(Button itemButton)
	{
		Debug.Log($"Item selected: {itemButton.name}");
		
		// Existing logic
		if (selectedItemButton != null)
			selectedItemButton.image.color = originalColor;

		selectedItemButton = itemButton;
		originalColor = itemButton.image.color;
		selectedItemButton.image.color = selectedColor;
	}

	public void OnBuyButton()
	{
		if (selectedItemButton == null)
		{
			dialogueText.text = "Please select an item to buy first!";
			Invoke(nameof(UpdateDialogueText), 2f);
			return;
		}

		if (playerMoney >= itemPrice)
		{
			playerMoney -= itemPrice;
			dialogueText.text = "You bought a Health Potion!";
			playerHUD?.SetPlayerMoney(playerMoney);

			Text itemText = selectedItemButton.GetComponentInChildren<Text>();
			string itemName = itemText.text;


			// ✅ Add to inventory
			playerInventory?.AddItem(itemName);
			playerInventory?.PrintInventory();

			// Reset selection
			selectedItemButton.image.color = originalColor;
			selectedItemButton = null;

			Invoke(nameof(UpdateDialogueText), 2f);
		}
		else
		{
			dialogueText.text = "Not enough coins!";
			Invoke(nameof(UpdateDialogueText), 2f);
		}
	}

	public void OnNextButton(){
		SceneManager.LoadScene("BattleScene");
	}

    // Called when the itemHUD is selected (clicked).
    void OnItemHUDSelected()
    {
        // Change the itemHUD's background color to blue.
        Image img = itemHUD.GetComponent<Image>();
        if (img != null)
        {
            img.color = Color.blue;
        }
        
        // Optionally update the dialogue text to indicate the selection.
        dialogueText.text = "Health Potion selected!";
    }
}
