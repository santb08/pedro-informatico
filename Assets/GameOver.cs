using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    private string ans = "";
    private void Start()
    {
        GameManager.CurrentLevel = 1;
        foreach (var question in GameManager.GetQuestions())
        {
            ans += "- "+question.Answers[question.correctAnswerIndex] + "\n";
        }
        score.text = "Puntuación: "+GameManager.GetCurrentScore() + "\n Respuestas correctas: \n" + ans;
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
