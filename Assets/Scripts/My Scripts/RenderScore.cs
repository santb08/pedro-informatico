using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderScore : MonoBehaviour
{
    [SerializeField] Text propText = null; 

    void Start()
    {
        Debug.Log("HOLA");
        Debug.Log(GameManager.GetCurrentScore());
        propText.text = string.Format(propText.text, GameManager.GetCurrentScore());        
    }
}
