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
    

    private void Start()
    {
        
        
    }

    public void Save()
    {
        //Crear archivo
        //.GetComponent<TextMeshProUGUI>().text;
        string name = thematic.text;
        string path = "Assets/config/" + name + ".txt";
        GameManager.SetGameThematic(name);
        AssetDatabase.ImportAsset(path);
        StreamWriter writer = new StreamWriter(path, true);
        writer.Close();
        GameManager.UpdateFiles();
        SceneManager.LoadScene("InputQuestions");
    }
}
