using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateQuestion : MonoBehaviour
{
    [SerializeField] GameObject objKey;
    [SerializeField] Text propText;
    private const float TEXT_TYPING_DELAY_TIME = 0.05f;
    private bool questionRendered = false;

    int mockId = -1;
    string mockQuestionContent = "Que dice el primer verso del himno nacional Colombiano?";
    string[] mockAnswers = {
        "Oh Gloria inmarsecible",
        "Oh Gloria y marcesible",
        "Ambas respuestas estan correctas",
        "A y C"
    };
    int mockCorrectAnswer = 1;

    void Update()
    {
        if (this.questionRendered) return;
        if (this.objKey == null) {
            // TODO: Create Question though an API call
            QuestionClass question = new QuestionClass(
                mockId,
                mockQuestionContent,
                mockAnswers,
                mockCorrectAnswer);

            StartCoroutine(TypeText(question.ToString()));
            this.questionRendered = true;
        }
    }

    IEnumerator TypeText(string message) {
		foreach (char letter in message.ToCharArray()) {
            propText.text += letter;
			yield return new WaitForSeconds (TEXT_TYPING_DELAY_TIME);
		}
	}
}
