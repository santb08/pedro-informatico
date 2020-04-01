using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float walkSpeed;

    private bool killPlayer = false; //Se indica si se esta siguiendo al juagador
    private bool square; //Indica si se llego a una esquina
    Vector3 currentPosition; //Indica la posisción actualizada del enemigo

    Vector3 f; //Ojetivo derecha
    Vector3 h; //Objetivo izquierda

    GameObject player; //Referencia al jugador
    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start () {
        player = GameObject.FindGameObjectWithTag ("Player"); //Se le da un tag para que sepa a quien debe buscar
        initialPosition = transform.position;
        currentPosition = new Vector3 ();
        square = false;
    }

    // Update is called once per frame
    void Update () {
        if (killPlayer == false) {
            walk (walkSpeed);
        }

        float dX = player.transform.position[0] - this.transform.position[0];
        float dY = player.transform.position[1];

        if (dX < 0) {
            dX = -dX;
        }

        if ((dX >= 2.9 && dX <= 7.2) && (dY <= 0.1 && dY >= -3.2)) {
            Destroy (player);
        }
        currentPosition = transform.position;
        changeDirection ();
    }

    private void walk (float speedEnemy) {
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

    private void changeDirection () {
        float current = this.currentPosition[0];
        if (current > 14.1 && square == false) {
            square = true;
        }

        if (current < -3.0 && square == true) {
            square = false;
        }
    }
}