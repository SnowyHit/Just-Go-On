using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMov : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem ps;
    public Rigidbody2D player ;
    public Color playerColor ;
    private SpriteRenderer m_Renderer;

    void Start()
    {
      this.m_Renderer = this.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        var main = ps.main;
        playerColor = new Color(PlayerPrefs.GetFloat("colorR" , 255f )/255f , PlayerPrefs.GetFloat("colorG" , 255f )/255f ,PlayerPrefs.GetFloat("colorB" , 255f )/255f,255) ;
        Debug.Log(playerColor) ;
        main.startColor = playerColor ;
        this.m_Renderer.color = playerColor ;
        Vector3 random  = new Vector3(Random.Range(-0.3f, 0.3f),Random.Range(-0.3f, 0.3f), 0 );
        player.AddForce(random , ForceMode2D.Impulse) ;
        if(Input.GetMouseButtonUp(0))
        {
          MoveToMouse();
        }
    }
    void MoveToMouse()
    {
      ps.Clear();
      ps.Play();
      Vector3 mousePosition = Input.mousePosition;
      mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
      Vector2 direction = new Vector2( mousePosition.x - transform.position.x , mousePosition.y - transform.position.y);
      transform.up = direction;
      player.AddForce(direction*5 , ForceMode2D.Impulse) ;
    }

}
