using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class QuestionFR : MonoBehaviour
{
    private const string QUESTION_FORMAT = "{1}{0}{2}{0}{3}{0}{4}";
    private const string SEPARATOR = "%%%%";

    public GameObject thematic;

    public GameObject q1;
    public GameObject q1r1;
    public GameObject q1r2;
    public GameObject q1r3;

    public GameObject q2;
    public GameObject q2r1;
    public GameObject q2r2;
    public GameObject q2r3;

    public GameObject q3;
    public GameObject q3r1;
    public GameObject q3r2;
    public GameObject q3r3;

    string[] dirs = Directory.GetFiles("Assets\\Config\\", "*.txt");

    public void WriteFile()
    {
        string name = thematic.GetComponent<TextMeshProUGUI>().text;
        string path = "Assets/config/" + name + ".txt";
        string[] questions = GetQuestions();
        StreamWriter writer = new StreamWriter(path, true);

        foreach (string question in questions) {
            writer.WriteLine(question);
        }

        writer.Close();

        AssetDatabase.ImportAsset(path);

        SceneManager.LoadScene("Select");
    }

    string[] GetQuestions()
    {
        string[] questions = new string[] {
            FormatQuestion(
                q1.GetComponent<TextMeshProUGUI>().text,
                q1r1.GetComponent<TextMeshProUGUI>().text,
                q1r2.GetComponent<TextMeshProUGUI>().text,
                q1r3.GetComponent<TextMeshProUGUI>().text
            ),
            FormatQuestion(
                q2.GetComponent<TextMeshProUGUI>().text,
                q2r1.GetComponent<TextMeshProUGUI>().text,
                q2r2.GetComponent<TextMeshProUGUI>().text,
                q2r3.GetComponent<TextMeshProUGUI>().text
            ),
            FormatQuestion(
                q3.GetComponent<TextMeshProUGUI>().text,
                q3r1.GetComponent<TextMeshProUGUI>().text,
                q3r2.GetComponent<TextMeshProUGUI>().text,
                q3r3.GetComponent<TextMeshProUGUI>().text
            )
        };

        return questions;
    }

    string FormatQuestion(string q, string r1, string r2, string r3)
    {
        return string.Format(QUESTION_FORMAT, SEPARATOR, q, r1, r2, r3);
    }
}
// int playerScore = 80;
// And we want to save playerScore:

// Save the score in the OnDisable function

// void OnDisable()
// {
//     PlayerPrefs.SetInt("score", playerScore);
// }
// Load it in the OnEnable function

// void OnEnable()
// {
//     playerScore  =  PlayerPrefs.GetInt("score");
// }