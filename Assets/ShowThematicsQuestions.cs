using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowThematicsQuestions : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI thematic, questions;
    string text = "";
    void Start()
    {
        thematic.text = GameManager.GameThematic;
        GameManager.FormatQuestions();
        Debug.Log(GameManager.GetQuestions().Count);
        for (int i = 0; i < GameManager.GetQuestions().Count; i++)
        {
            text += GameManager.GetQuestions()[i].QuestionContent + "\n";
        }
        questions.text = text;
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Thematics");
    }
}
