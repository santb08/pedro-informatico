using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {
    Vector3 initialPosition;
    [SerializeField] LayerMask layerMaskKey, layerMaskPlayer;
    [SerializeField] int distanceToRotate = 10;
    private Rigidbody2D rigidbody2D;
    Scene scene;
    private int direction = 1;
    public float speed = 3;
    
    void Start() {
        rigidbody2D = transform.GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        scene = SceneManager.GetActiveScene();
    }

    void Update () {
        rigidbody2D.velocity = new Vector2(speed * direction, rigidbody2D.velocity.y);

        transform.rotation = Quaternion.identity;
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