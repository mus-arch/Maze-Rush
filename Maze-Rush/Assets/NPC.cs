using System.Collections;
using System.Collections.Generic;
using UnityEngine; // Dit laat ons Unity-functies gebruiken, zoals GameObject en Collider

public class NPC : MonoBehaviour // Dit script heet NPC en kan op een GameObject in Unity
{
    public Dialogue dialogue; // De dialoog die deze NPC heeft (we vullen de zinnen in de Unity Inspector in)
    private bool playerInRange = false; // Staat de speler dichtbij? (false = nee, true = ja)
    private DialogueManager dialogueManager; // De DialogueManager die de dialoog toont

    void Start() // Dit gebeurt als het spel begint
    {
        dialogueManager = FindObjectOfType<DialogueManager>(); // Zoek de DialogueManager in de scene en sla die op
    }

    void Update() // Dit gebeurt elke frame (continu terwijl het spel draait)
    {
        // Controleer of: 1) de speler dichtbij is, 2) de speler op "E" drukt, 3) er geen dialoog actief is
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !dialogueManager.IsDialogueActive())
        {
            dialogueManager.StartDialogue(dialogue); // Start de dialoog met de zinnen van deze NPC
        }
    }

    private void OnTriggerEnter(Collider other) // Dit gebeurt als iets de trigger-collider van de NPC raakt
    {
        if (other.CompareTag("Player")) // Controleer of het de speler is (door de tag "Player")
        {
            playerInRange = true; // Zet playerInRange op true (de speler is nu dichtbij)
        }
    }

    private void OnTriggerExit(Collider other) // Dit gebeurt als iets de trigger-collider van de NPC verlaat
    {
        if (other.CompareTag("Player")) // Controleer of het de speler is
        {
            playerInRange = false; // Zet playerInRange op false (de speler is niet meer dichtbij)
        }
    }
}