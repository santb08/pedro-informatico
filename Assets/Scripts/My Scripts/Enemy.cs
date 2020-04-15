using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {
    Vector3 initialPosition;
    [SerializeField] LayerMask layerMaskKey, layerMaskPlayer, platformsLayerMask;
    [SerializeField] int distanceToRotate = 10;
    private BoxCollider2D boxCollider2d;
    private GameObject player;
    private Rigidbody2D rigidbody2D;
    public float speed = 3;
    public float direction = 1;
    private Scene scene;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody2D = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        initialPosition = transform.position;
        scene = SceneManager.GetActiveScene();
    }

    void Update () {
        rigidbody2D.velocity = new Vector2(speed * direction, rigidbody2D.velocity.y);
        transform.rotation = Quaternion.identity;

        if (player != null)
        {
            ChangeDirection();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Mathf.Log(layerMaskKey.value, 2))
        {
            Destroy(gameObject);
            GameManager.IncreaseScore();
        }
        if (collision.gameObject.layer == Mathf.Log(layerMaskPlayer.value, 2))
        {
            Destroy(collision.gameObject);
            if (GameManager.GetCurrentScore() > 0)
            {
                GameManager.DecreaseScore();
            }
            SceneManager.LoadScene(scene.name);
        }
    }

    private void ChangeDirection() {
        direction = (player.transform.position - transform.position).normalized.x;
    }

    private bool DidHitWall() 
    {
        RaycastHit2D rightRaycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.right, .1f, platformsLayerMask);
        RaycastHit2D leftRaycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.left, .1f, platformsLayerMask);
        return rightRaycastHit2d.collider != null || leftRaycastHit2d.collider != null;
    }
}