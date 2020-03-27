using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class Settings : MonoBehaviour
{
    public void GoBack() {
        SceneManager.LoadScene("Menu");
    }

    public void GoInput() { 
        SceneManager.LoadScene("Input");
    }

    public void DeleteAll() {
        System.IO.DirectoryInfo di = new DirectoryInfo("Assets\\Config\\");
        foreach (FileInfo file in di.EnumerateFiles())
        {
            file.Delete(); 
        }
        foreach (DirectoryInfo dir in di.EnumerateDirectories())
        {
            dir.Delete(true); 
        }
    }
}
