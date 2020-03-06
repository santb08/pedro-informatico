using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraplingHook : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField] private LayerMask layerMaskKeyValue;
    [SerializeField] private float maxDistance = 15;
    [SerializeField] private float pullForce = 50;
    [SerializeField] private float speed = 75;
    [SerializeField] private float target_pull = 30;
    private EdgeCollider2D collider;
    private LineRenderer line;
    private Rigidbody2D rigidbody2D;
    private Rigidbody2D target;
    private Vector2 offset;
    private Vector3 velocity;
    private bool update = false;
    private bool pulling = false;
    private float mass;
    public Material mat;
    public Rigidbody2D origin;
    private float DelayAirTime = 2f;

    void Start() {
        line = GetComponent<LineRenderer>();
        collider = GetComponent<EdgeCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void setStart(Vector2 targetPos) {
        Vector2 dir = targetPos - origin.position;
        dir = dir.normalized;
        velocity = dir * speed;
        transform.position = origin.position + dir;
        update = true;
        pulling = false;
    }

    void Update() {
        if (!update) {
            return;
        }

        if (pulling) {
            PullToGraplingHookDirection();
        } else {
            if (Input.GetKeyUp(KeyCode.Mouse0)) {
                this.ResetGraplingHook();
                return;
            }

            rigidbody2D.MovePosition((Vector2)rigidbody2D.position + (Vector2)velocity * Time.deltaTime);
            float distance = Vector2.Distance(transform.position, origin.position);

            if (distance > maxDistance) {
                this.ResetGraplingHook();
                return;
            }
        }
        SetGraplingHookPositions(transform.position, origin.position);
        FixColliderShape();
    }

    void FixColliderShape() {
        Vector2[] colliderPoints = collider.points;
        colliderPoints[0] = Vector2.zero;
        colliderPoints[1] = Vector2.zero + new Vector2(0.01f, 0);
        collider.points = colliderPoints;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer != Mathf.Log(layerMaskKeyValue, 2)){
            return;
        }
        pulling = true;
    }

    void SetGraplingHookPositions(Vector2 pos1, Vector2 pos2) {
        line.SetPosition(0, pos1);
        line.SetPosition(1, pos2);
    }

    void ResetGraplingHook() {
        this.SetGraplingHookPositions(Vector2.zero, Vector2.zero);
        pulling = false;
        update = false;
    }

    void PullToGraplingHookDirection() {
        Vector2 dir = (Vector2)transform.position - origin.position;
        dir = dir.normalized * 0.25f + dir * 0.75f;
        origin.AddForce(dir * pullForce * Time.deltaTime * 1000);
    }
}