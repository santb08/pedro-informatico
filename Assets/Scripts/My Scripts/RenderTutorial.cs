using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderTutorial : MonoBehaviour
{
    public LayerMask layerPlayer;
    public Text txtTutorial;
    public string hint;

    void OnTriggerEnter2D(Collider2D collision) {
        txtTutorial.text = hint;
    }
    
    void OnTriggerExit2D(Collider2D collision) {
        txtTutorial.text = "";
    }
}
