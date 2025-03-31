using System.Collections;
using System.Collections.Generic;
using UnityEngine; // Dit laat ons Unity-functies gebruiken, zoals GameObject
using TMPro; // Dit laat ons TextMeshPro gebruiken, dat is de tekst in de UI

public class DialogueManager : MonoBehaviour // Dit script heet DialogueManager en kan op een GameObject in Unity
{
    // Deze variabelen koppelen we in de Unity Inspector
    public TextMeshProUGUI dialogueText; // De tekst in de UI waar de zinnen verschijnen
    public GameObject dialoguePanel; // Het panel dat de dialoog toont (de achtergrond van de tekst)
    public GameObject nextButton; // De "Volgende"-knop om naar de volgende zin te gaan

    // Deze variabelen gebruiken we in de code
    private string[] sentences; // De lijst van zinnen die we tonen
    private int currentSentenceIndex = 0; // Welke zin we nu tonen (0 is de eerste zin, 1 is de tweede, enz.)
    private bool isDialogueActive = false; // Is de dialoog nu actief? (true = ja, false = nee)

    void Start() // Dit gebeurt als het spel begint
    {
        dialoguePanel.SetActive(false); // Verberg het dialoogpanel bij de start, zodat het niet meteen verschijnt
    }

    public void StartDialogue(Dialogue dialogue) // Start een nieuwe dialoog
    {
        isDialogueActive = true; // Zet de dialoog aan (we zijn nu in een dialoog)
        dialoguePanel.SetActive(true); // Toon het dialoogpanel op het scherm
        sentences = dialogue.sentences; // Haal de zinnen uit het Dialogue-script en sla ze op
        currentSentenceIndex = 0; // Begin bij de eerste zin (index 0)
        ShowSentence(); // Toon de eerste zin
    }

    public void ShowNextSentence() // Ga naar de volgende zin
    {
        currentSentenceIndex++; // Ga naar de volgende zin (bijv. van 0 naar 1)
        if (currentSentenceIndex >= sentences.Length) // Als er geen zinnen meer zijn (bijv. als we bij zin 2 zijn en er zijn maar 2 zinnen)
        {
            EndDialogue(); // Sluit de dialoog
        }
        else // Als er nog zinnen zijn
        {
            ShowSentence(); // Toon de volgende zin
        }
    }

    void ShowSentence() // Toon de huidige zin
    {
        dialogueText.text = sentences[currentSentenceIndex]; // Zet de huidige zin in de UI-tekst (bijv. "Hoi!")
    }

    void EndDialogue() // Sluit de dialoog
    {
        dialoguePanel.SetActive(false); // Verberg het dialoogpanel
        isDialogueActive = false; // Zet de dialoog uit (we zijn klaar met de dialoog)
    }

    public bool IsDialogueActive() // Controleer of de dialoog actief is
    {
        return isDialogueActive; // Geef terug of de dialoog aan is (true) of uit (false)
    }
}