using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMagnet : MonoBehaviour
{
    [SerializeField] private GameObject magnetPrefab;
    private GameObject magnetObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && magnetObject == null)
        {
            magnetObject = Instantiate(magnetPrefab, transform);
        }
        if (Input.GetKeyUp(KeyCode.J) && magnetObject != null)
        {
            Destroy(magnetObject);
        }
    }
}
