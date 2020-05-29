using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FillQuestions : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
        Fill();
    }

    void Fill()
    {
        if (GameManager.newThematicQuestions.Count > 0) {
            GameObject newObj;
            foreach (var textQuestion in GameManager.newThematicQuestions) {
                string[] questionData = textQuestion.Split("%%%%".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                newObj = Instantiate(prefab, transform);
                newObj.transform.GetChild(0).gameObject.GetComponent<Text>().text = questionData[0];
            }
        }
    }
}
