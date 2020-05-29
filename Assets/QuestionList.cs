using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionList : MonoBehaviour
{
    // Update is called once per frame
    public void GoBack()
    {
        SceneManager.LoadScene("InputThematic");
    }

    public void AddQuestion()
    {
        SceneManager.LoadScene("InputQuestions");
    }

    public void SaveQuestions() 
    {
        // SceneManager.
        GameManager.WriteFile();
        SceneManager.LoadScene("Settings");
    }
}
