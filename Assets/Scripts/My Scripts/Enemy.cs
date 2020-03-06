using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float visionRadiius;
    public float speed;

    GameObject player;


    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player");

         initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
     Vector3 target = initialPosition;

     float dist = Vector3.Distance(player.transform.position, transform.position);
     if(dist < visionRadiius) target = player.transform.position;

     float fixedSpeed = speed*Time.deltaTime;
     transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

     float d = Vector3.Distance(player.transform.position, transform.position);

     if(d <= 0.2 ) Destroy(player);
     Debug.DrawLine(transform.position, target, Color.green);
    }

    void onDrawGizmos(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadiius);
    }
}
