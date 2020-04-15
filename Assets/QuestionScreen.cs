using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;

public class QuestionScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI enunciado;
    System.Random rand = new System.Random();
    int questionIndex;
    // Start is called before the first frame update
    void Start()
    {
        //Se obtienen las preguntas
        questionIndex = rand.Next(GameManager.GetQuestions().Length - 1);
        ShowQuestion();
        GameManager.FormatQuestions();
    }


    void ShowQuestion()
    {
        //Inicializar pregunta
        Debug.Log("Question Index" + questionIndex);
        Debug.Log("Pregunta: " + GameManager.GetQuestions()[questionIndex]);
        enunciado.text = GameManager.GetQuestions()[questionIndex].ToString();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
