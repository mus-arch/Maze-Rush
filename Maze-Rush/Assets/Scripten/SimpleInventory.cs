using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class SimpleInventory : MonoBehaviour
{
    [SerializeField] private List<InventoryItem> inventory = new List<InventoryItem>();
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject inventorySlotPrefab;
    [SerializeField] private Transform slotsParent;

    [SerializeField] private Sprite collectble1Sprite;
    [SerializeField] private Sprite collectble2Sprite;
    [SerializeField] private Sprite collectble3Sprite;

    private bool isInventoryVisible = false;
    private List<GameObject> currentSlots = new List<GameObject>();

    void Start()
    {
        inventory.Clear();
        inventoryPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    public bool AddItem(string itemName)
    {
        Sprite sprite = GetSpriteForItem(itemName);
        if (sprite == null) return false;

        InventoryItem existingItem = inventory.Find(item => item.itemName == itemName);
        if (existingItem != null)
        {
            existingItem.amount++;
            UpdateUI();
            return true;
        }
        else if (inventory.Count < 3)
        {
            inventory.Add(new InventoryItem(itemName, sprite));
            UpdateUI();
            return true;
        }
        return false; // Inventory vol
    }

    public void RemoveItem(string itemName)
    {
        InventoryItem item = inventory.Find(i => i.itemName == itemName);
        if (item != null)
        {
            item.amount--;
            if (item.amount <= 0)
            {
                inventory.Remove(item);
            }
            UpdateUI();
        }
    }

    private void ToggleInventory()
    {
        isInventoryVisible = !isInventoryVisible;
        inventoryPanel.SetActive(isInventoryVisible);
        if (isInventoryVisible)
        {
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        foreach (GameObject slot in currentSlots)
        {
            Destroy(slot);
        }
        currentSlots.Clear();

        foreach (InventoryItem item in inventory)
        {
            GameObject slot = Instantiate(inventorySlotPrefab, slotsParent);
            currentSlots.Add(slot);

            slot.transform.Find("ItemIcon").GetComponent<Image>().sprite = item.icon;
            slot.transform.Find("ItemName").GetComponent<Text>().text = item.itemName;
            slot.transform.Find("ItemCount").GetComponent<Text>().text = "x" + item.amount;
            Button removeButton = slot.transform.Find("RemoveButton").GetComponent<Button>();
            removeButton.onClick.AddListener(() => RemoveItem(item.itemName));
        }
    }

    public Sprite GetSpriteForItem(string itemName)
    {
        switch (itemName)
        {
            case "collectble1": return collectble1Sprite;
            case "collectble2": return collectble2Sprite;
            case "collectble3": return collectble3Sprite;
            default: return null;
        }
    }

    [System.Serializable]
    private class SaveData
    {
        public List<InventorySaveItem> items = new List<InventorySaveItem>();
    }

    [System.Serializable]
    private class InventorySaveItem
    {
        public string itemName;
        public int amount;
    }

    public string SaveInventory()
    {
        SaveData data = new SaveData();
        foreach (InventoryItem item in inventory)
        {
            data.items.Add(new InventorySaveItem
            {
                itemName = item.itemName,
                amount = item.amount
            });
        }
        return JsonUtility.ToJson(data);
    }

    public void LoadInventory(string jsonData)
    {
        inventory.Clear();
        SaveData data = JsonUtility.FromJson<SaveData>(jsonData);
        foreach (InventorySaveItem savedItem in data.items)
        {
            Sprite sprite = GetSpriteForItem(savedItem.itemName);
            if (sprite != null)
            {
                InventoryItem item = new InventoryItem(savedItem.itemName, sprite);
                item.amount = savedItem.amount;
                inventory.Add(item);
            }
        }
        UpdateUI();
    }
}