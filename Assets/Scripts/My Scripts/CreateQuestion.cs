using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CreateQuestion : MonoBehaviour
{
    [SerializeField] GameObject objKey;
    [SerializeField] Text propText;

    //Scene scene;
    //private QuestionClass[] questions;
    //private bool questionRendered = false;
    //private const float TEXT_TYPING_DELAY_TIME = 0.05f;
    //private int userIndexInput = -1;

    void Start() {
        //questions = GameManager.GetQuestions();
        //scene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        RenderQuestions();
    }

    public void RenderQuestions() {
        if(this.objKey == null)
        {
            SceneManager.LoadScene("QuestionScreen");
        }
        {/* COMO SE VERIFICA LA ENTRADA
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
            //if (this.questionRendered) return;
            //if (this.objKey == null) {
            //    StartCoroutine(TypeText(questions[lvl].ToString()));
            //    this.questionRendered = true;
            //}
            //this.HandleUserInput();
         }
    }
}
