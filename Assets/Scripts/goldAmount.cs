using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goldAmount : MonoBehaviour
{
    public Text Goldentext ;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Goldentext.text = PlayerPrefs.GetFloat("Gold" , 0 ).ToString("#.00");; 
    }
}
