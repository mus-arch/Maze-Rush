using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public Sprite icon;
    public int amount;

    public InventoryItem(string name, Sprite sprite)
    {
        itemName = name;
        icon = sprite;
        amount = 1;
    }
}