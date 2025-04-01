using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    void Update()
    {
        // Saven met F5 (slaat positie op)
        if (Input.GetKeyDown(KeyCode.F5))
        {
            PlayerPrefs.SetFloat("PlayerX", transform.position.x);
            PlayerPrefs.SetFloat("PlayerY", transform.position.y);
            PlayerPrefs.SetFloat("PlayerZ", transform.position.z);
            PlayerPrefs.Save();
            Debug.Log("Game saved!");
        }

        // Laden met F9 (laadt positie)
        if (Input.GetKeyDown(KeyCode.F9))
        {
            float x = PlayerPrefs.GetFloat("PlayerX");
            float y = PlayerPrefs.GetFloat("PlayerY");
            float z = PlayerPrefs.GetFloat("PlayerZ");
            transform.position = new Vector3(x, y, z);
            Debug.Log("Game loaded!");
        }
    }
}