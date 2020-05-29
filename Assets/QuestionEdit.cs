using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuestionEdit : MonoBehaviour
{
    private const string QUESTION_FORMAT = "{1}{0}{2}{0}{3}{0}{4}";
    private const string SEPARATOR = "%%%%";

    [SerializeField] TMP_InputField enunciado, correcta, incorrecta1, incorrecta2;

    string[] dirs = Directory.GetFiles(GameManager.directory, "*.txt");

    void Start() {
        string[] questionData = GameManager.newThematicQuestions[GameManager.indexQuestionEdit]
            .Split("%%%%".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        enunciado.text = questionData[0];
        correcta.text = questionData[1];
        incorrecta1.text = questionData[2];
        incorrecta2.text = questionData[3];
    }

    //Guardar y Salir
    public void SaveAndQuit()
    {
        if (enunciado.text != "" && correcta.text != "" && incorrecta1.text != "" && incorrecta2.text != "")
        {
            string question = FormatQuestion(enunciado.text,correcta.text,incorrecta1.text,incorrecta2.text);
            GameManager.newThematicQuestions.RemoveAt(GameManager.indexQuestionEdit);
            GameManager.newThematicQuestions.Add(question);
        }
        SceneManager.LoadScene("QTL");
    }

    public void RemoveQuestion(int index) {

    }

    string FormatQuestion(string q, string r1, string r2, string r3)
    {
        return string.Format(QUESTION_FORMAT, SEPARATOR, q, r1, r2, r3);
    }
}