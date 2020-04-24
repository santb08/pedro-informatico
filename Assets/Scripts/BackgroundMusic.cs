using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    void Awake() {
        if (!GameManager.isMusicPlaying) {
            DontDestroyOnLoad(transform.gameObject);
            GameManager.isMusicPlaying = true;
        } else {
            Destroy(transform.gameObject);
        }
    }
}
