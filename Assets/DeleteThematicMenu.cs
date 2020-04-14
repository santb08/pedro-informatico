using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class DeleteThematicMenu : MonoBehaviour
{
    public GameObject thematicButton;
    public Button nextThematicBtn;
    private string thematicToDelete;
    string fileName;
    private int file_index;

    void Start()
    {
        file_index = 0;
    }

    private void Update()
    {
        SetOption();
    }

    void SetOption()
    {
        thematicButton = GameObject.Find("Delete_Thematic_Button");
        //Se optiene el nombre del archivo
        if (GameManager.files.Length > 0)
        {
            fileName = Path.GetFileName(GameManager.files[file_index]);
            thematicToDelete = fileName.Substring(0, fileName.IndexOf(".txt"));
            //Se asigna el texto al botón de eliminar temática
            thematicButton.GetComponentInChildren<TextMeshProUGUI>().text = thematicToDelete;
        } else thematicButton.GetComponentInChildren<TextMeshProUGUI>().text = "Sin Temáticas";
    }

    public void DeleteThematic()
    {
        File.Delete(Path.Combine(GameManager.directory, fileName));
        GameManager.UpdateFiles();
    }

    public void IncreaseIndex()
    {
        if (file_index + 1 < GameManager.files.Length) file_index++;
    }
    public void DecreaseIndex()
    {
        if (file_index > 0) file_index--;
    }
    public void GoBack()
    {
        SceneManager.LoadScene("Settings");
    }
}
