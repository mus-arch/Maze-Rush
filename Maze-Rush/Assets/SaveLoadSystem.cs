using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Zorg dat dit erbij staat

public class SaveLoadSystem : MonoBehaviour
{
    public Button saveButton;
    public Button continueButton;
    public Button newGameButton;

    void Start()
    {
        transform.position = new Vector3(
            PlayerPrefs.GetFloat("X", 0),
            PlayerPrefs.GetFloat("Y", 0),
            PlayerPrefs.GetFloat("Z", 0)
        );

        saveButton.onClick.AddListener(Save);
        continueButton.onClick.AddListener(Continue);
        newGameButton.onClick.AddListener(NewGame);
    }

    void Save()
    {
        PlayerPrefs.SetFloat("X", transform.position.x);
        PlayerPrefs.SetFloat("Y", transform.position.y);
        PlayerPrefs.SetFloat("Z", transform.position.z);
        PlayerPrefs.Save();
        // Geen scène-wissel, blijf in huidige scène
    }

    void Continue()
    {
        // Laad "GameScene" als je naar een andere scène wilt
        SceneManager.LoadScene("GAME");
    }

    void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("GAME"); // Start nieuwe game in "GameScene"
    }
}