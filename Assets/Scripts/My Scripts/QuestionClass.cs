using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionClass
{
    private string FORMAT_QUESTION = "Pregunta: \n {0} \n{1}";
    private string FORMAT_ANSWER = "{0} - {1} \n";

    public int correctAnswerIndex;
    private int id;
    private string questionContent;
    private string[] answers;

    public QuestionClass(int id, string question, string[] answers, int correctAnswerIndex) {
        this.id = id;
        this.questionContent = question;
        this.answers = this.RandomizeAnswers(answers);
    }

    string[] RandomizeAnswers(string[] answers)
    {
        string correctAnswer = answers[0];
        for (int t = 0; t < 3; t++)
        {
            string tmp = answers[t];
            int r = UnityEngine.Random.Range(t, answers.Length);
            //Debug.Log(r + " and index: " +answers.Length);
            answers[t] = answers[r];
            answers[r] = tmp;
        }

        for (int t = 0; t < answers.Length; t++)
        {
            if (correctAnswer == answers[t]) {
                correctAnswerIndex = t;
                //Debug.Log("Correcta: "+ correctAnswer);
            }
        }

        return answers;
    }

    public int Id {
        get { return id; }
    }

    public string QuestionContent {
        get { return questionContent; }
    }

    public string[] Answers {
        get { return answers; }
    }

    public int CorrectAnswerIndex {
        get { return correctAnswerIndex; }
    }

    public override string ToString() {
        string question = "";

        for (int i = 0; i < answers.Length; i++) {
            question += string.Format(this.FORMAT_ANSWER, i+1, answers[i]);
        }

        return string.Format(this.FORMAT_QUESTION, this.questionContent, question);
    }
}
