using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull : MonoBehaviour
{
    [SerializeField] private float force = 70;
    [SerializeField] private Rigidbody2D objectRigidbody;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) {
            Vector2 dir = objectRigidbody.position - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dir = dir.normalized;
        }
    }
}
