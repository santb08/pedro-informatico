using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame() {
        SceneManager.LoadScene("Demo");
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void SettingsOfTheGame() {
        SceneManager.LoadScene("Settings");
    }
}
