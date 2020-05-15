using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionList : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void GoBack()
    {
        SceneManager.LoadScene("InputThematic");
    }

    public void AddQuestion()
    {
        SceneManager.LoadScene("InputQuestions");
    }
}
