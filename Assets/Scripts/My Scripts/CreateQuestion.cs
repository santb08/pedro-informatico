using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System;
public class CreateQuestion : MonoBehaviour
{
    [SerializeField] GameObject objKey;
    [SerializeField] Text propText;
    public int nivel;
    private const float TEXT_TYPING_DELAY_TIME = 0.05f;
    private bool questionRendered = false;
    //Se obtiene el nombre de la temática para obtener las preguntas del archivo
    string thematic;
    string[] files = Directory.GetFiles("Assets\\Config\\", "*.txt");
    string[] questionsFile;
    QuestionClass[] questions = new QuestionClass[3];

    int mockCorrectAnswer = 1;

    ////////////MOCK////////////
    // int mockId = -1;
    // string mockQuestionContent = "Que dice el primer verso del himno nacional Colombiano?";
    // string[] mockAnswers = {
    //     "Oh Gloria inmarsecible",
    //     "Oh Gloria y marcesible",
    //     "Ambas respuestas estan correctas",
    //     "A y C"
    // };
    


    void Start() {
        thematic = PlayerPrefs.GetString("thematic");
        FormatQuestions();
    }

    void Update()
    {
        //Cañas pls parametrizame esto jeje
        setQuestions(0);
    }

    IEnumerator TypeText(string message) {
		foreach (char letter in message.ToCharArray()) {
            propText.text += letter;
			yield return new WaitForSeconds (TEXT_TYPING_DELAY_TIME);
		}
	}

    private void FormatQuestions() {
        //Obtener archivo que contiene las preguntas
        var match = files.FirstOrDefault(stringToCheck => stringToCheck.Contains(thematic));
        //Se guarda en un array cada linea del archivo
        questionsFile = File.ReadAllLines(match);
        for (int i = 0; i < 3; i++)
        {
            questions[i] = new QuestionClass(
                nivel,
                questionsFile[i].Substring(0, questionsFile[i].IndexOf("%%")),
                //Array de respuestas
                Format(questionsFile[i].Substring(questionsFile[i].IndexOf("%%"))),
                //Respuesta correcta
                mockCorrectAnswer);
        }
    }

    public void setQuestions(int lvl) {
        if (this.questionRendered) return;
        if (this.objKey == null) {
            var match = files.FirstOrDefault(stringToCheck => stringToCheck.Contains(thematic));
            string[] questionsFile = File.ReadAllLines(match);  
            // // TODO: Create Question though an API call
            StartCoroutine(TypeText(questions[lvl].ToString()));
            this.questionRendered = true;
        }
    }

    public string[] Format(string stringLine) {
        //Formatear cada respuesta
		return stringLine.Split("%%%%".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
    }
}
