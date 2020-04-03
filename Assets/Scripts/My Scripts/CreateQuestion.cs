using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateQuestion : MonoBehaviour
{
    [SerializeField] GameObject objKey;
    [SerializeField] Text propText;
    private QuestionClass[] questions;
    private bool questionRendered = false;
    private const float TEXT_TYPING_DELAY_TIME = 0.05f;
    private int userIndexInput = -1;

    void Start() {
        questions = GameManager.GetQuestions(); 
    }

    void Update()
    {
        this.renderQuestions(0);
    }

    IEnumerator TypeText(string message) {
		foreach (char letter in message.ToCharArray()) {
            propText.text += letter;
			yield return new WaitForSeconds(TEXT_TYPING_DELAY_TIME);
		}

	}

    private void HandleUserInput() {
        if (Input.GetKey(KeyCode.Keypad1) || Input.GetKey(KeyCode.Alpha1)) {
            userIndexInput = 1;
        }
        if (Input.GetKey(KeyCode.Keypad2) || Input.GetKey(KeyCode.Alpha2)) {
            userIndexInput = 2;
        }
        if (Input.GetKey(KeyCode.Keypad3) || Input.GetKey(KeyCode.Alpha3)) {
            userIndexInput = 3;
        }
    }

    public void renderQuestions(int lvl) {
        this.HandleUserInput();

        if (userIndexInput > 0 && userIndexInput == questions[lvl].correctAnswerIndex) {
            Debug.Log("melooo");
        } else {
            Debug.Log("NOOOo");
        }

        if (this.questionRendered) return;
        if (this.objKey == null) {
            StartCoroutine(TypeText(questions[lvl].ToString()));
            this.questionRendered = true;
        }
    }

}
