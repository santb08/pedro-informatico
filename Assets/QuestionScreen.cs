using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;
using Unity.UIWidgets.ui;
using UnityEngine.SceneManagement;

public class QuestionScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI enunciado;
    System.Random rand = new System.Random();
    int questionIndex, userIndexInput = -1;
    QuestionClass question;
    private UnityEngine.SceneManagement.Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        //Se obtienen las preguntas
        if (GameManager.GetQuestions().Count == 1)
        {
            questionIndex = 0;
        } else
        {
            Debug.Log("OEEE");
            Debug.Log(GameManager.GetQuestions().Count);
            questionIndex = rand.Next(GameManager.GetQuestions().Count - 1);
        }
        ShowQuestion();
        GameManager.FormatQuestions();
    }

    void ShowQuestion()
    {
        //Inicializar pregunta        
        question = GameManager.GetQuestions()[questionIndex];
        if (GameManager.GetQuestions()[questionIndex] != null)
        {
            enunciado.text = GameManager.GetQuestions()[questionIndex].ToString();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        HandleUserInput();
        if (userIndexInput > 0)
        {
            CheckAnswer();
        }
    }

    private void HandleUserInput()
    {
        if (Input.GetKey(KeyCode.Keypad1) || Input.GetKey(KeyCode.Alpha1))
        {
            userIndexInput = 0;
        }
        if (Input.GetKey(KeyCode.Keypad2) || Input.GetKey(KeyCode.Alpha2))
        {
            userIndexInput = 1;
        }
        if (Input.GetKey(KeyCode.Keypad3) || Input.GetKey(KeyCode.Alpha3))
        {
            userIndexInput = 2;
        }
    }

    void CheckAnswer()
    {
        if (userIndexInput == question.correctAnswerIndex)
        {
            //Sumar Puntos
            Debug.Log("Correcta");
            CheckLevelToPass();
        } else
        {
            //Reiniciar nivel
            Debug.Log("Incorrecta");
            ResetForFail();
        }
        /* COMO SE VERIFICA LA ENTRADA
        if (userIndexInput > 0) {
            if (userIndexInput == questions[lvl].correctAnswerIndex) {
                GameManager.IncreaseScore();
            }
            if (scene.buildIndex < 7)
            {
                int tempIndex = scene.buildIndex + 1;
                SceneManager.LoadScene("QuestionScreen");
            }
            if (GameManager.CurrentLevel < 3) GameManager.CurrentLevel++;
        } else {
            //Debug.Log("NOOOo");
        }
        */
    }

    //Actualiza el numero del nivel y pasa al siguiente nivel
    void CheckLevelToPass()
    {
        switch (GameManager.lastLvl)
        {
            case "Level_1":
                SceneManager.LoadScene("Level_2");
                break;
            case "Level_2":
                SceneManager.LoadScene("Level_3");
                break;
            case "Level_3":
                SceneManager.LoadScene("GameOver");
                break;
            default:
                break;
        }
    }

    // Reinicia el nivel si falla al responder la pregunta
    void ResetForFail()
    {
        switch (GameManager.lastLvl)
        {
            case "Level_1":
                SceneManager.LoadScene("Level_1");
                break;
            case "Level_2":
                SceneManager.LoadScene("Level_2");
                break;
            case "Level_3":
                SceneManager.LoadScene("Level_3");
                break;
            default:
                break;
        }
    }
}