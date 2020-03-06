using System.Collections;
using System.Collections.Generic;

public class QuestionClass
{
    private string FORMAT_QUESTION = "Pregunta #{0}: \n {1} \n {2}";
    private string FORMAT_ANSWER = "{0} - {1} \n";

    private int correctAnswerIndex;
    private int id;
    private string questionContent;
    private string[] answers;

    public QuestionClass(int id, string question, string[] answers, int correctAnswerIndex) {
        this.id = id;
        this.questionContent = question;
        this.answers = answers;
        this.correctAnswerIndex = correctAnswerIndex;
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
            question += string.Format(this.FORMAT_ANSWER, i, answers[i]);
        }

        return string.Format(this.FORMAT_QUESTION, this.id, this.questionContent, question);
    }
}
