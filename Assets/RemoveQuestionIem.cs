using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RemoveQuestionIem : MonoBehaviour
{
    public void OnRemove() {
        string text = transform.GetChild(0).gameObject.GetComponent<Text>().text;

        for (int i = 0; i < GameManager.newThematicQuestions.Count; i++) {
            string question = GameManager.newThematicQuestions[i];
            if (question.Contains(text)) {
                GameManager.indexQuestionEdit = i;
                SceneManager.LoadScene("EditQuestion");
                // GameManager.newThematicQuestions.RemoveAt(i);
                // Destroy(gameObject);
                break;
            }
        }
    }
}
