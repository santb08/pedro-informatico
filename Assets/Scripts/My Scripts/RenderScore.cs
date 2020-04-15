using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RenderScore : MonoBehaviour
{
    string SCORE_FORMAT = "Puntuación: {0}";
    [SerializeField] TextMeshProUGUI propText = null; 

    void Update()
    {
        propText.text = string.Format(SCORE_FORMAT, GameManager.GetCurrentScore());        
    }
}
