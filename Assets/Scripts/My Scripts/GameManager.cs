using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

public class GameManager : MonoBehaviour
{
    // @constants

    private static int CurrentLevel = 1;
    private static string GameThematic = "1_Temática Primera​";
    // private string thematic;
    private static string[] files = Directory.GetFiles("Assets\\Config\\", "*.txt");
    private static string[] questionsFile;
    private static string thematic;
    private static QuestionClass[] questions = new QuestionClass[3];
    
    static GameManager() {
        thematic = PlayerPrefs.GetString("thematic");
        FormatQuestions();
    }

    public static string GetGameThematic()
    {
        return GameThematic;
    }

    public static QuestionClass[] GetQuestions()
    {
        return questions;
    }

    public static void SetGameThematic(string newThematic)
    {
        GameThematic = newThematic;
    }

    public static void FormatQuestions() 
    {
        //Obtener archivo que contiene las preguntas
        var match = files.FirstOrDefault(stringToCheck => stringToCheck.Contains(thematic));
        //Se guarda en un array cada linea del archivo
        questionsFile = File.ReadAllLines(match);
        for (int i = 0; i < 3; i++)
        {
            questions[i] = new QuestionClass(
                i,
                questionsFile[i].Substring(0, questionsFile[i].IndexOf("%%")),
                //Array de respuestas
                Format(questionsFile[i].Substring(questionsFile[i].IndexOf("%%"))),
                //Respuesta correcta
                1);
        }
    }
    
 
    private static string[] Format(string stringLine) {
        //Formatear cada respuesta
		return stringLine.Split("%%%%".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
    }
}
