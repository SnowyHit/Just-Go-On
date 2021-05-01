using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class EndlessEnd : MonoBehaviour
{
    // Start is called before the first frame update
    int Score ;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D (Collider2D other){
          if(other.gameObject.tag == "Player"){
              Score += 1   ;
              Debug.Log(Score) ;
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

          }

    }

}
