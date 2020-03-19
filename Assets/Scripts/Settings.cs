using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public void GoBack() {
        SceneManager.LoadScene("Menu");
    }

    public void GoInput() { 
        SceneManager.LoadScene("Input");
    }
}
