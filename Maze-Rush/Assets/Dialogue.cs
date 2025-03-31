using System.Collections;
using System.Collections.Generic;
using UnityEngine; // Dit laat ons Unity-functies gebruiken, zoals [System.Serializable]

[System.Serializable] // Dit zorgt ervoor dat we dit in de Unity Inspector kunnen invullen
public class Dialogue // Dit is de naam van ons script, het heet "Dialogue"
{
    public string[] sentences; // Dit is een lijst van zinnen die de NPC zal zeggen, zoals "Hoi!" of "Hoe gaat het?"
 
}
