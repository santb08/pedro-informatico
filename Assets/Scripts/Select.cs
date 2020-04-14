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

    private int fileIndex;
    private string fileName;
    void Start() {
        fileIndex = 0;
    }

    private void Update()
    {
        SetOption();
    }

    void SetOption() {
        option1 = GameObject.Find("Option_1_Button");
        //Se optiene el nombre del archivo
        if (GameManager.files.Length > 0)
        {
            fileName = Path.GetFileName(GameManager.files[fileIndex]);
            //Se asigna la temática del juego
            GameManager.SetGameThematic(fileName.Substring(0,fileName.IndexOf(".txt")));
            GameManager.FormatQuestions();
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
        if (fileIndex + 1 < GameManager.files.Length)
        {
            fileIndex++;
        } else
        {
            fileIndex = 0;
        }
    }
    public void DecreaseIndex() {
        if (fileIndex > 0) fileIndex--;
        else fileIndex = GameManager.files.Length - 1;
    }
    public void GoBack() {
        SceneManager.LoadScene("Menu");
    }
}  
