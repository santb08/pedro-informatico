using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] LayerMask layerMaskKey;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == Mathf.Log(layerMaskKey.value, 2)) {
            Debug.Log("hola");  
            animator.SetBool("isOpen", true);
        }
    }
}
