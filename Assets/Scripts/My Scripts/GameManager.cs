using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

public class GameManager : MonoBehaviour
{
    private static int currentScore = 0;
    public static int CurrentLevel = 1;
    public static string directory = @"Assets\\Config\\";
    public static string GameThematic = "​";
    // private string thematic;
    private static AssetBundle myAssetBundle;
    public static string[] scenePaths;
    public static string[] files;
    private static string[] questionsFile;
    private static List<QuestionClass> questions = new List<QuestionClass>();
    
    static GameManager() {
        files = Directory.GetFiles("Assets\\Config\\", "*.txt");
        if (GameThematic != "")
        {
            FormatQuestions();
        }
    }

    public static string GetGameThematic()
    {
        return GameThematic;
    }

    public static List<QuestionClass> GetQuestions()
    {
        return questions;
    }

    public static void SetGameThematic(string newThematic)
    {
        GameThematic = newThematic;
    }

    public static void UpdateFiles()
    {
        files = Directory.GetFiles("Assets\\Config\\", "*.txt");
    }

    public static void FormatQuestions() 
    {
        //Obtener archivo que contiene las preguntas
        var match = files.FirstOrDefault(stringToCheck => stringToCheck.Contains(GameThematic));
        //Se guarda en un array cada linea del archivo
        questions.Clear();
        if (match != null)
        {
            questionsFile = File.ReadAllLines(match);
            for (int i = 0; i < questionsFile.Length; i++)
            {
                questions.Add(new QuestionClass(
                    i,
                    questionsFile[i].Substring(0, questionsFile[i].IndexOf("%%")),
                    //Array de respuestas
                    Format(questionsFile[i].Substring(questionsFile[i].IndexOf("%%"))),
                    //Respuesta correcta
                    1));
            }
        }
    }
 
    private static string[] Format(string stringLine) {
        //Formatear cada respuesta
		return stringLine.Split("%%%%".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
    }

    public static int GetCurrentScore() {
        return currentScore;
    }

    public static void IncreaseScore() {
        currentScore++; 
    }
}
