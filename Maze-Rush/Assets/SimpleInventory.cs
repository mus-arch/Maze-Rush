using System.Collections.Generic;
using UnityEngine;

public class SimpleInventory : MonoBehaviour
{
    // Dit is de lijst waar alle items in zitten
    public List<InventoryItem> inventory = new List<InventoryItem>();

    // Plaatjes voor de items (zet deze in de Unity Inspector)
    public Sprite collectble1Sprite;  // Plaatjes voor Items
    public Sprite collectble2Sprite; 
    public Sprite collectble3Sprite;   

    // Variabele om te bepalen of de inventaris getoond wordt
    private bool showInventory = false;

    // Start wordt uitgevoerd als het spel begint
    void Start()
    {
        // Voeg een paar testitems toe om te beginnen
        AddItem("collectble1", collectble1Sprite);
        AddItem("collectble2", collectble2Sprite);
        AddItem("collectble3", collectble3Sprite);
    }

    // Update wordt elke frame uitgevoerd
    void Update()
    {
        // Als je op de 'I'-toets drukt, toon of verberg de inventaris
        if (Input.GetKeyDown(KeyCode.I))
        {
            showInventory = !showInventory; // Wisselt tussen true en false
        }
    }

    // Functie om een item toe te voegen aan de inventaris
    public void AddItem(string name, Sprite picture)
    {
        // Kijk of het item al in de inventaris zit
        foreach (InventoryItem item in inventory)
        {
            if (item.itemName == name) // Als de naam hetzelfde is
            {
                item.amount += 1; // Voeg 1 toe aan de hoeveelheid
                return;           // Stop de functie, we zijn klaar
            }
        }

        // Als het item nog niet bestaat, maak een nieuw item en voeg het toe
        InventoryItem newItem = new InventoryItem(name, picture);
        inventory.Add(newItem);
    }

    // Functie om een item te verwijderen
    public void RemoveItem(string name)
    {
        // Loop door de lijst van items
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemName == name) // Als we het item vinden
            {
                inventory[i].amount -= 1; // Haal 1 van de hoeveelheid af
                if (inventory[i].amount <= 0) // Als er geen meer over zijn
                {
                    inventory.RemoveAt(i); // Verwijder het item uit de lijst
                }
                return; // Stop de functie
            }
        }
    }

    // Dit tekent de inventaris op het scherm
    void OnGUI()
    {
        // Als showInventory false is, doe niets
        if (!showInventory) return;

        // Maak een achtergrondvak voor de inventaris
        GUI.Box(new Rect(10, 10, 250, 300), "Inventaris");

        // Beginpositie voor de items op het scherm
        int yPosition = 40;

        // Loop door alle items en toon ze
        for (int i = 0; i < inventory.Count; i++)
        {
            // Toon het plaatje van het item als het bestaat
            if (inventory[i].icon != null)
            {
                GUI.DrawTexture(new Rect(20, yPosition, 32, 32), inventory[i].icon.texture);
            }

            // Toon de naam en hoeveelheid (bijv. "Zwaard x2")
            GUI.Label(new Rect(60, yPosition + 8, 150, 20),
                inventory[i].itemName + " x" + inventory[i].amount);

            // Maak een knop om het item te verwijderen
            if (GUI.Button(new Rect(180, yPosition, 60, 20), "Weg"))
            {
                RemoveItem(inventory[i].itemName);
            }

            // Verhoog de positie voor het volgende item
            yPosition += 35;
        }

        // Knoppen om items toe te voegen (onder de lijst)
        if (GUI.Button(new Rect(20, yPosition + 20, 100, 20), "Voeg collectble1"))
        {
            AddItem("collectble1", collectble1Sprite);
        }
        if (GUI.Button(new Rect(130, yPosition + 20, 100, 20), "Voeg collectble2"))
        {
            AddItem("collectble2", collectble2Sprite);
        }
    }
}