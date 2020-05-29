using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CreateQuestion : MonoBehaviour
{
    [SerializeField] GameObject objKey;
    [SerializeField] Text propText;
    [SerializeField] TextMeshProUGUI score;

    Scene scene;

    void Start() {
        //questions = GameManager.GetQuestions();
        scene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        RenderQuestions();
        score.text = string.Format(score.text, GameManager.GetCurrentScore());
    }

    public void RenderQuestions() {
        if(this.objKey == null)
        {
            GameManager.lastLvl = scene.name;
            SceneManager.LoadScene("QuestionScreen");
        }
    }
}
