using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplyQuestion : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1)) {
            Debug.Log("Esta es");
        }
        if (Input.GetKeyDown(KeyCode.Keypad2)) {
            Debug.Log("Esta no es");
        }
        if (Input.GetKeyDown(KeyCode.Keypad3)) {
            Debug.Log("Esta tampoco");
        }
    }
}
