using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform Player;
    public int Xaxis = 3 ; 
    public int Yaxis = 2  ;
        // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      Vector3 goTo = new Vector3(Player.position.x+Xaxis , Player.position.y+Yaxis , -10 ) ;
      transform.position = goTo ;
    }
}
