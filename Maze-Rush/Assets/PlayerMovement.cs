using System.Collections;
using System.Collections.Generic;
using UnityEngine; // Dit laat ons Unity-functies gebruiken, zoals Vector3 en Input

public class PlayerMovement : MonoBehaviour // Dit script heet PlayerMovement en kan op een GameObject in Unity
{
    public float speed = 5f; // De snelheid van de speler (hoe snel hij beweegt, we kunnen dit in Unity aanpassen)

    void Update() // Dit gebeurt elke frame (continu terwijl het spel draait)
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // Kijk of de speler A/D of pijltjes links/rechts indrukt (-1 = links, 0 = niets, 1 = rechts)
        float moveZ = Input.GetAxisRaw("Vertical"); // Kijk of de speler W/S of pijltjes omhoog/omlaag indrukt (-1 = achter, 0 = niets, 1 = voor)
        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized * speed * Time.deltaTime; // Maak een beweging: X voor links/rechts, Y is 0, Z voor voor/achter
        transform.Translate(movement); // Beweeg de speler in de richting die we hebben berekend
    }
}