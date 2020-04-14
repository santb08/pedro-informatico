using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float walkSpeed;
    Rigidbody2D key;
    [SerializeField] LayerMask layerMaskKey, layerMaskPlayer;
    [SerializeField] bool isObstacle;
    private bool killPlayer = false; //Se indica si se esta siguiendo al juagador
    private bool square; //Indica si se llego a una esquina
    Vector3 currentPosition; //Indica la posisción actualizada del enemigo

    Vector3 f; //Ojetivo derecha
    Vector3 h; //Objetivo izquierda

    GameObject player, enemy; 
    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player"); //Se le da un tag para que sepa a quien debe buscar
        key = GameObject.Find("Key").GetComponent<Rigidbody2D>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        initialPosition = transform.position;
        currentPosition = new Vector3 ();
        square = false;
    }

    // Update is called once per frame
    void Update () {
        if (killPlayer == false && isObstacle == false) {
            Walk (walkSpeed);
        }

        //float dX = player.transform.position[0] - this.transform.position[0];
        //float dY = player.transform.position[1];

        //if (dX < 0) {
        //    dX = -dX;
        //}

        //if ((dX >= 2.9 && dX <= 7.2) && (dY <= 0.1 && dY >= -3.2)) {
        //    Destroy (player);
        //}
        currentPosition = transform.position;
        ChangeDirection ();
    }

    private void Walk (float speedEnemy) {
        float fixedSpeed = speedEnemy * Time.deltaTime;
        Vector3 target;
        if (square == true) {
            f = new Vector3 (-3.1f, this.transform.position[1], 0.0f);
            target = f;
            transform.position = Vector3.MoveTowards (transform.position, target, fixedSpeed);
        } else {
            h = new Vector3 (14.2f, this.transform.position[1], 0.0f);
            target = h;
            transform.position = Vector3.MoveTowards (transform.position, target, fixedSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Mathf.Log(layerMaskKey.value, 2))
        {
            if (Math.Abs(key.velocity.x) > 2)
            {
                Debug.Log(key.velocity.x);
            }
            Destroy(enemy);
        }
        if (collision.gameObject.layer == Mathf.Log(layerMaskPlayer.value, 2))
        {
            if (Math.Abs(key.velocity.x) > 2)
            {
                Debug.Log(key.velocity.x);
            }
            Destroy(collision.gameObject);
        }
    }

    private void ChangeDirection () {
        float current = this.currentPosition[0];
        if (current > 14.1 && square == false) {
            square = true;
        }

        if (current < -3.0 && square == true) {
            square = false;
        }
    }
}