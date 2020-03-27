using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;

public class Select : MonoBehaviour {

    public GameObject option1, option2;
    string[] dirs = Directory.GetFiles("Assets\\Config\\", "*.txt");
    void Start() {
        setOption();
    }
    
    void setOption() {
        option1 = GameObject.Find("Option_1_Button");
        option2 = GameObject.Find("Option_2_Button");
        string path1 = "",path2 = "";

        foreach (string file in dirs) {
            if(file.Contains("1_")) {
                path1=file;
            } else path2 = file;
        }

        //////////////////Temática 1//////////////////
        string filename1 = Path.GetFileName(path1);
        int index1 = filename1.IndexOf('.');
        if (index1 > 0) {
            option1.GetComponentInChildren<TextMeshProUGUI>().text = filename1.Substring(filename1.IndexOf('_')+1, index1-2);
        }

        //////////////////Temática 1//////////////////
        string filename2 = Path.GetFileName(path2);
        int index2 = filename2.IndexOf('.');
        if (index2 > 0) {
            option2.GetComponentInChildren<TextMeshProUGUI>().text = filename2.Substring(filename2.IndexOf('_')+1, index2-2);
        }
    }

    // Se podría pasar los parametros de la temática seleccionada
    public void Play() { 
        SceneManager.LoadScene("Demo");
    }

    public void goBack() {
        SceneManager.LoadScene("Menu");
    }
}  
