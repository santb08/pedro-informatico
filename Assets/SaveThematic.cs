using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveThematic : MonoBehaviour
{
    [SerializeField] TMP_InputField thematic;
    

    public void GoBack()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Save()
    {
        //Crear archivo
        //.GetComponent<TextMeshProUGUI>().text;
        string name = thematic.text;
        string path = GameManager.directory + name + ".txt";
        Debug.Log(string.Format("SAVING AT {0}", path));
        GameManager.SetGameThematic(name);
        StreamWriter writer = new StreamWriter(path, true);
        writer.Close();
        GameManager.UpdateFiles();
        SceneManager.LoadScene("QTL");
    }
}
