using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RenderScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI propText = null; 

    void Start()
    {
        Debug.Log(GameManager.GetCurrentScore());
        propText.text = string.Format(propText.text, GameManager.GetCurrentScore());        
    }
}
