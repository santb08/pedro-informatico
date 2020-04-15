using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderTutorial : MonoBehaviour
{
    public LayerMask layerPlayer;
    public Text txtTutorial;
    public string hint;

    private void Start()
    {
        //txtTutorial.fontSize = 28;
    }
    void OnTriggerEnter2D(Collider2D collision) {
        txtTutorial.text = hint; 
        txtTutorial.resizeTextForBestFit = true;
    }
    
    void OnTriggerExit2D(Collider2D collision) {
        txtTutorial.text = "";
    }
}
