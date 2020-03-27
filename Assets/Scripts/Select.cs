using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour {

    // Se podría pasar los parametros de la temática seleccionada
    public void Play() { 
        SceneManager.LoadScene("Demo");
    }
}  
