using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // A dictionary to hold item names and quantities
    private Dictionary<string, int> items = new Dictionary<string, int>();

    // Add an item to the inventory
    public void AddItem(string itemName)
    {
        if (items.ContainsKey(itemName))
        {
            items[itemName]++;
        }
        else
        {
            items[itemName] = 1;
        }

        Debug.Log($"Added {itemName}. Now have {items[itemName]}.");
    }

    // Optional: Get the quantity of a specific item
    public int GetItemCount(string itemName)
    {
        return items.ContainsKey(itemName) ? items[itemName] : 0;
    }

    // Optional: Display the inventory
    public void PrintInventory()
    {
        Debug.Log("Inventory:");
        foreach (var kvp in items)
        {
            Debug.Log($"ASDF{kvp.Key}: {kvp.Value}");
        }
    }
}
