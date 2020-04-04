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

    public GameObject option1;

    private int file_index;
    private string fileName;
    void Start() {
        file_index = 0;
    }

    private void Update()
    {
        SetOption();
    }

    void SetOption() {
        option1 = GameObject.Find("Option_1_Button");
        //Se optiene el nombre del archivo
        Debug.Log(file_index);
        if (GameManager.files.Length > 0)
        {
            fileName = Path.GetFileName(GameManager.files[file_index]);
            //Se asigna la temática del juego
            GameManager.SetGameThematic(fileName.Substring(0,fileName.IndexOf(".txt")));
            //Se asigna el texto al botón de temática
            option1.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GameThematic;
        }
    }

    public void Play()
    {
        if (GameManager.files.Length > 0) SceneManager.LoadScene("Level_1");
        else SceneManager.LoadScene("Input");
    }

    public void IncreaseIndex() {
        if (file_index + 1 < GameManager.files.Length) file_index++;
    }
    public void DecreaseIndex() {
        if (file_index > 0) file_index--;
    }
    public void GoBack() {
        SceneManager.LoadScene("Menu");
    }
}  
