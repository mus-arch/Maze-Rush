using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadSystem : MonoBehaviour
{
    public Transform player; // Speler-object

    public void Save()
    {
        // Spelerpositie opslaan
        PlayerPrefs.SetFloat("X", player.position.x);
        PlayerPrefs.SetFloat("Y", player.position.y);
        PlayerPrefs.SetFloat("Z", player.position.z);
        PlayerPrefs.Save();

        // Ga naar het hoofdmenu
        SceneManager.LoadScene("Main Menu");
    }

    public void Continue()
    {
        // Ga naar de game-scene
        SceneManager.LoadScene("GAME");
    }

    public void NewGame()
    {
        // Wis alle opgeslagen data en start opnieuw
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("GAME");
    }

    void Start()
    {
        // Alleen laden als er een opgeslagen positie is
        if (PlayerPrefs.HasKey("X"))
        {
            player.position = new Vector3(
                PlayerPrefs.GetFloat("X"),
                PlayerPrefs.GetFloat("Y"),
                PlayerPrefs.GetFloat("Z")
            );
        }
    }
}
