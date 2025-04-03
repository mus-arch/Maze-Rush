using UnityEngine;

[System.Serializable] // Dit maakt het item zichtbaar in de Unity Inspector
public class InventoryItem
{
    public string itemName; // De naam van het item, zoals "Zwaard"
    public int amount;      // Hoeveel je van dit item hebt
    public Sprite icon;     // Een plaatje voor het item in de inventaris

    // Dit is een constructor: het maakt een nieuw item aan
    public InventoryItem(string name, Sprite picture)
    {
        itemName = name;    // Zet de naam
        amount = 1;         // Begin met 1 item
        icon = picture;     // Zet het plaatje
    }
}