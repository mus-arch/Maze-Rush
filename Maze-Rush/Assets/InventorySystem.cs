using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Nodig voor Sprite en GUI-functionaliteit
// Nodig voor Sprite en GUI-functionaliteit

// Dit is een eenvoudige inventarisbeheerklasse in Unity, geschreven in C#.
// Het script beheert een lijst van items, hun hoeveelheden en een visuele weergave via een GUI.

public class InventorySystem : MonoBehaviour // MonoBehaviour maakt dit een Unity-component
{
    // Inventory Item class om eigenschappen van een item te definiëren
    [System.Serializable] // Maakt de klasse zichtbaar in de Unity Inspector
    public class InventoryItem
    {
        public string itemName; // Naam van het item (bijv. "Sword", "Potion")
        public int quantity;    // Huidige hoeveelheid van het item
        public int maxStack;    // Maximale stapelgrootte voor dit item
        public Sprite icon;     // Visueel icoon van het item voor de GUI

        // Constructor om een nieuw item te maken met basiswaarden
        public InventoryItem(string name, int max, Sprite sprite)
        {
            itemName = name;     // Stel de naam in
            quantity = 1;        // Begin met 1 item
            maxStack = max;      // Stel de maximale stapelgrootte in
            icon = sprite;       // Koppel het visuele icoon
        }
    }

    // Variabelen voor het inventarisbeheer
    public List<InventoryItem> inventory = new List<InventoryItem>(); // Lijst van items in de inventaris
    public int maxSlots = 20; // Maximum aantal slots in de inventaris
    private bool showInventory = false; // Boolean om te bepalen of de inventaris GUI getoond wordt

    // Voorbeeldsprites voor items (moeten worden toegewezen in de Unity Inspector)
    public Sprite swordSprite;  // Icoon voor het zwaard
    public Sprite potionSprite; // Icoon voor de potion
    public Sprite coinSprite;   // Icoon voor de munt

    // Start wordt aangeroepen bij het laden van het script in de scène
    void Start()
    {
        // Voeg testitems toe om de inventaris te initialiseren
        AddItem("Sword", 1, swordSprite);   // Voeg 1 zwaard toe
        AddItem("Potion", 10, potionSprite); // Voeg 10 potions toe (max stapel is 10)
        AddItem("Coin", 99, coinSprite);    // Voeg 99 munten toe (max stapel is 99)
    }

    // Update wordt elke frame aangeroepen
    void Update()
    {
        // Schakel de inventarisweergave aan/uit met de 'I'-toets
        if (Input.GetKeyDown(KeyCode.I))
        {
            showInventory = !showInventory; // Wissel de waarde van showInventory (true/false)
        }
    }

    // Functie om een item aan de inventaris toe te voegen
    public bool AddItem(string itemName, int amount, Sprite icon)
    {
        // Controleer eerst of het item al bestaat en gestapeld kan worden
        foreach (InventoryItem item in inventory)
        {
            if (item.itemName == itemName && item.quantity < item.maxStack) // Als naam overeenkomt en er ruimte is
            {
                int spaceLeft = item.maxStack - item.quantity; // Bereken hoeveel ruimte er nog is
                item.quantity += Mathf.Min(amount, spaceLeft); // Voeg toe, maar niet meer dan maxStack
                return true; // Item succesvol toegevoegd
            }
        }

        // Als het item niet gestapeld kan worden en er ruimte is, voeg een nieuw item toe
        if (inventory.Count < maxSlots)
        {
            inventory.Add(new InventoryItem(itemName, amount, icon)); // Maak en voeg nieuw item toe
            return true; // Item succesvol toegevoegd
        }

        Debug.Log("Inventory full!"); // Log een bericht als de inventaris vol is
        return false; // Toevoegen mislukt
    }

    // Functie om een item uit de inventaris te verwijderen
    public void RemoveItem(string itemName, int amount)
    {
        // Loop achterwaarts door de lijst om veilig te kunnen verwijderen
        for (int i = inventory.Count - 1; i >= 0; i--)
        {
            if (inventory[i].itemName == itemName) // Vind het item met de juiste naam
            {
                inventory[i].quantity -= amount; // Verminder de hoeveelheid
                if (inventory[i].quantity <= 0) // Als de hoeveelheid 0 of minder is
                {
                    inventory.RemoveAt(i); // Verwijder het item volledig uit de lijst
                }
                return; // Stop na het vinden en verwerken van het item
            }
        }
    }

    // Functie om de inventaris GUI te tekenen
    void OnGUI()
    {
        if (!showInventory) return; // Als showInventory false is, teken niets

        // Teken een achtergrondvak voor de inventaris
        GUI.Box(new Rect(10, 10, 300, 400), "Inventory");

        // Startpositie voor het weergeven van items
        int yPos = 40;

        // Loop door alle items en toon ze
        for (int i = 0; i < inventory.Count; i++)
        {
            // Teken het itemicoon als het bestaat
            if (inventory[i].icon != null)
            {
                GUI.DrawTexture(new Rect(20, yPos, 32, 32), inventory[i].icon.texture); // Teken het icoon
            }

            // Toon de naam en hoeveelheid van het item
            GUI.Label(new Rect(60, yPos + 8, 200, 20),
                $"{inventory[i].itemName} x{inventory[i].quantity}");

            // Voeg een verwijderknop toe voor elk item
            if (GUI.Button(new Rect(220, yPos + 4, 70, 20), "Remove"))
            {
                RemoveItem(inventory[i].itemName, 1); // Verwijder 1 van dit item bij klikken
            }

            yPos += 35; // Verhoog de verticale positie voor het volgende item
        }

        // Extra ruimte voor testknoppen
        yPos += 20;

        // Knop om een zwaard toe te voegen
        if (GUI.Button(new Rect(20, yPos, 100, 20), "Add Sword"))
        {
            AddItem("Sword", 1, swordSprite); // Voeg 1 zwaard toe bij klikken
        }

        // Knop om een potion toe te voegen
        if (GUI.Button(new Rect(130, yPos, 100, 20), "Add Potion"))
        {
            AddItem("Potion", 1, potionSprite); // Voeg 1 potion toe bij klikken
        }

        // Knop om een munt toe te voegen
        if (GUI.Button(new Rect(240, yPos, 100, 20), "Add Coin"))
        {
            AddItem("Coin", 1, coinSprite); // Voeg 1 munt toe bij klikken
        }
    }

    // Controleer of een item in de inventaris bestaat met een minimale hoeveelheid
    public bool HasItem(string itemName, int amount = 1)
    {
        foreach (InventoryItem item in inventory)
        {
            if (item.itemName == itemName && item.quantity >= amount) // Als naam en hoeveelheid kloppen
            {
                return true; // Item gevonden
            }
        }
        return false; // Item niet gevonden
    }

    // Haal de totale hoeveelheid van een specifiek item op
    public int GetItemCount(string itemName)
    {
        foreach (InventoryItem item in inventory)
        {
            if (item.itemName == itemName) // Als het item gevonden is
            {
                return item.quantity; // Geef de hoeveelheid terug
            }
        }
        return 0; // Item niet gevonden, geef 0 terug
    }
}
