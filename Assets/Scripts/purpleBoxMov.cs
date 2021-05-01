using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class purpleBoxMov : MonoBehaviour
{
    // Start is called before the first frame update
    public float MoveSpeed ;
    public float right ;
    public float left ;
    public float top ;
    public float bottom ;
    float Xright ;
    float Xleft ;
    float Ytop ;
    float Ybottom ;
    Vector3 temp ;
    Vector3 startPos ;
    Vector3 randomx ;
    bool started  = true;
    public GameObject target ;
    // Start is called before the first frame update
    void Start()
    {

      startPos = transform.position ;
      Xright = transform.position.x + right ;
      Xleft = transform.position.x - left ;
      Ytop = transform.position.y + top ;
      Ybottom = transform.position.y - bottom ;

    }

    void FixedUpdate()
    {

      randomx = new Vector3(Random.Range(Xright, Xleft) ,Random.Range(Ytop, Ybottom), 0 ) ;
      if(started) {temp = randomx ;
        Instantiate(target , temp , Quaternion.identity) ;}
      transform.position = Vector2.MoveTowards(transform.position, temp , MoveSpeed/10);
      started = false ;
      if(transform.position == temp)
      {
        started = true ;
      }

    }
    void OnTriggerEnter2D (Collider2D other){

          if(other.gameObject.tag == "purpleBoxTarget"){
              Destroy(other.gameObject);
          }

    }
    void OnDrawGizmos()
    {
      Gizmos.color = Color.red ;
      Gizmos.DrawLine(new Vector3 (Xleft , Ytop , 0 ) , new Vector3 (Xleft , Ybottom , 0 )) ;
      Gizmos.DrawLine(new Vector3 (Xright , Ytop , 0 ) , new Vector3 (Xright , Ybottom , 0 )) ;
      Gizmos.DrawLine(new Vector3 (Xleft , Ytop , 0 ) , new Vector3 (Xright , Ytop , 0 )) ;
      Gizmos.DrawLine(new Vector3 (Xleft , Ybottom , 0 ) , new Vector3 (Xright , Ybottom , 0 )) ;


    }


}
