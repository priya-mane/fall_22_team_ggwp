using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        TMPro.TextMeshProUGUI txtMy = this.GetComponent<TMPro.TextMeshProUGUI>();
        txtMy.text = "" + GameManager.lives + " X";
    }
}
