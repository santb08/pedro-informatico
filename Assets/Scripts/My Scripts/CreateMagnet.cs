using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMagnet : MonoBehaviour
{
    [SerializeField] private GameObject magnetPrefab;
    private GameObject magnetObject;
    private const KeyCode keyMagnet = KeyCode.J;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyMagnet) && magnetObject == null)
        {
            magnetObject = Instantiate(magnetPrefab, transform);
        }
        if (Input.GetKeyUp(keyMagnet) && magnetObject != null)
        {
            Destroy(magnetObject);
        }
    }
}
