using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    Rigidbody2D key;
    Vector3 currentPosition; 
    Vector3 initialPosition;
    [SerializeField] LayerMask layerMaskKey, layerMaskPlayer;
    [SerializeField] int distanceToRotate = 10;
    private Rigidbody2D rigidbody2D;
    private int direction;
    public float speed;
    
    void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        key = GameObject.Find("Key").GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        currentPosition = new Vector3 ();
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
            //if (Math.Abs(key.velocity.x) > 2)
            //{
            //    Debug.Log(key.velocity.x);
            //}
            Destroy(collision.gameObject);
        }
    }

    private void ChangeDirection() {
        float distance = Vector3.Distance(transform.position, initialPosition);

        if (distance > distanceToRotate) {

        }
    }
}