using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public GameObject[] hearts;

    void Update() {

        if(GameManager.lives < 1) {
            Destroy(hearts[0].gameObject);
        } else if(GameManager.lives < 2) {
            Destroy(hearts[1].gameObject);
        } else if(GameManager.lives < 3) {
            Destroy(hearts[2].gameObject);
        }
    }
}
