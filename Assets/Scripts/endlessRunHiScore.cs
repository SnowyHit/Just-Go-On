using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endlessRunHiScore : MonoBehaviour
{

    public Text HiScore;
    // Start is called before the first frame update
    void Start()
    {
      HiScore.text = PlayerPrefs.GetFloat("14" , 0 ).ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
