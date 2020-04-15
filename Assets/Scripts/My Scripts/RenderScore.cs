using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RenderScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI propText = null; 

    void Update()
    {
        propText.text = string.Format(propText.text, GameManager.GetCurrentScore());        
    }
}
