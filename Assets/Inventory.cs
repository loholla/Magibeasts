using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<string, int> items = new Dictionary<string, int>();

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

        Debug.Log($"Added {itemName}. Total: {items[itemName]}");
    }

    public int GetItemCount(string itemName)
    {
        return items.ContainsKey(itemName) ? items[itemName] : 0;
    }

    public void PrintInventory()
    {
        Debug.Log("Inventory Contents:");
        foreach (var item in items)
        {
            Debug.Log($"{item.Key}: {item.Value}");
        }
    }

        void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            PrintInventory();
        }
    }
}
