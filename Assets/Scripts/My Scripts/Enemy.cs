using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {
    Rigidbody2D key;
    Vector3 currentPosition; 
    Vector3 initialPosition;
    [SerializeField] LayerMask layerMaskKey, layerMaskPlayer;
    [SerializeField] int distanceToRotate = 10;
    private Rigidbody2D rigidbody2D;
    private int direction;
    public float speed;
    Scene scene;
    
    void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        key = GameObject.Find("Key").GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        currentPosition = new Vector3 ();
        scene = SceneManager.GetActiveScene();
    }

    void Update () {


        currentPosition = transform.position;

        ChangeDirection();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Mathf.Log(layerMaskKey.value, 2))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == Mathf.Log(layerMaskPlayer.value, 2))
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(scene.name);
        }
    }

    private void ChangeDirection() {
        float distance = Vector3.Distance(transform.position, initialPosition);

        if (distance > distanceToRotate) {

        }
    }
}