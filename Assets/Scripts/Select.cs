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
    public Button nextThematicBtn;

    private int file_index = 0;

    void Start() {
        
    }

    private void Update()
    {
        SetOption();
    }

    void SetOption() {
        option1 = GameObject.Find("Option_1_Button");
        nextThematicBtn = GameObject.Find("Next_Thematic_Button").GetComponent<Button>();
        //Se optiene el nombre del archivo
        string fileName = Path.GetFileName(GameManager.files[file_index]);
        //Se asigna la temática del juego
        GameManager.SetGameThematic(fileName.Substring(0,fileName.IndexOf(".txt")));
        //Se asigna el texto al botón de temática
        this.option1.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GameThematic;
    }

    public void Play()
    {
        SceneManager.LoadScene("Demo");
    }

    public void IncreaseIndex() {
        if (file_index < GameManager.files.Length - 1) file_index++;
    }
    public void DecreaseIndex() {
        if (file_index > 0) file_index--;
    }
    public void GoBack() {
        SceneManager.LoadScene("Menu");
    }
}  
