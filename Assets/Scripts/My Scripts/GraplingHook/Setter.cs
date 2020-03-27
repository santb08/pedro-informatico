using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setter : MonoBehaviour
{
    [SerializeField] private GraplingHook graplingHook;

    private bool setted = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            graplingHook.setStart(worldPos);
            setted = !setted;
        }
        if (Input.GetKeyDown(KeyCode.W) && setted)
        {
            graplingHook.ResetGraplingHook();
        }
    }
}