//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class InventorySystem : MonoBehaviour
//{
//    // Inventory Item class to define item properties
//    [System.Serializable]
//    public class InventoryItem
//    {
//        public string itemName;
//        public int quantity;
//        public int maxStack;
//        public Sprite icon;

//        public InventoryItem(string name, int max, Sprite sprite)
//        {
//            itemName = name;
//            quantity = 1;
//            maxStack = max;
//            icon = sprite;
//        }
//    }

//    // Inventory variables
//    public List<InventoryItem> inventory = new List<InventoryItem>();
//    public int maxSlots = 20;
//    private bool showInventory = false;

//    // Example item sprites (assign in Inspector)
//    public Sprite swordSprite;
//    public Sprite potionSprite;
//    public Sprite coinSprite;

//    void Start()
//    {
//        // Add some test items
//        AddItem("Sword", 1, swordSprite);
//        AddItem("Potion", 10, potionSprite);
//        AddItem("Coin", 99, coinSprite);
//    }

//    void Update()
//    {
//        // Toggle inventory with 'I' key
//        if (Input.GetKeyDown(KeyCode.I))
//        {
//            showInventory = !showInventory;
//        }
//    }

//    // Add item to inventory
//    public bool AddItem(string itemName, int amount, Sprite icon)
//    {
//        // Check if item already exists and can be stacked
//        foreach (InventoryItem item in inventory)
//        {
//            if (item.itemName == itemName && item.quantity < item.maxStack)
//            {
//                int spaceLeft = item.maxStack - item.quantity;
//                item.quantity += Mathf.Min(amount, spaceLeft);
//                return true;
//            }
//        }

//        // If inventory isn't full, add new item
//        if (inventory.Count < maxSlots)
//        {
//            inventory.Add(new InventoryItem(itemName, amount, icon));
//            return true;
//        }

//        Debug.Log("Inventory full!");
//        return false;
//    }

//    // Remove item from inventory
//    public void RemoveItem(string itemName, int amount)
//    {
//        for (int i = inventory.Count - 1; i >= 0; i--)
//        {
//            if (inventory[i].itemName == itemName)
//            {
//                inventory[i].quantity -= amount;
//                if (inventory[i].quantity <= 0)
//                {
//                    inventory.RemoveAt(i);
//                }
//                return;
//            }
//        }
//    }

//    // Draw inventory UI
//    void OnGUI()
//    {
//        if (!showInventory) return;

//        // Inventory window
//        GUI.Box(new Rect(10, 10, 300, 400), "Inventory");

//        // Display items
//        int yPos = 40;
//        for (int i = 0; i < inventory.Count; i++)
//        {
//            // Item icon
//            if (inventory[i].icon != null)
//            {
//                GUI.DrawTexture(new Rect(20, yPos, 32, 32), inventory[i].icon.texture);
//            }

//            // Item name and quantity
//            GUI.Label(new Rect(60, yPos + 8, 200, 20),
//                $"{inventory[i].itemName} x{inventory[i].quantity}");

//            // Remove button
//            if (GUI.Button(new Rect(220, yPos + 4, 70, 20), "Remove"))
//            {
//                RemoveItem(inventory[i].itemName, 1);
//            }

//            yPos += 35;
//        }

//        // Add item test buttons
//        yPos += 20;
//        if (GUI.Button(new Rect(20, yPos, 100, 20), "Add Sword"))
//        {
//            AddItem("Sword", 1, swordSprite);
//        }
//        if (GUI.Button(new Rect(130, yPos, 100, 20), "Add Potion"))
//        {
//            AddItem("Potion", 1, potionSprite);
//        }
//        if (GUI.Button(new Rect(240, yPos, 100, 20), "Add Coin"))
//        {
//            AddItem("Coin", 1, coinSprite);
//        }
//    }

//    // Check if item exists in inventory
//    public bool HasItem(string itemName, int amount = 1)
//    {
//        foreach (InventoryItem item in inventory)
//        {
//            if (item.itemName == itemName && item.quantity >= amount)
//            {
//                return true;
//            }
//        }
//        return false;
//    }

//    // Get total quantity of an item
//    public int GetItemCount(string itemName)
//    {
//        foreach (InventoryItem item in inventory)
//        {
//            if (item.itemName == itemName)
//            {
//                return item.quantity;
//            }
//        }
//        return 0;
//    }
//}
