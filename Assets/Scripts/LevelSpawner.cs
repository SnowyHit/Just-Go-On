using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] middlechunks;
    public GameObject startchunk ;
    public GameObject endchunk  ;
    float random ;
    void Start()
    {
      random  = Random.Range(0,middlechunks.Length) ;
      if(random < 5)
      {
        random = 5 ;
      }
      if(random > 7)
      {
        random = 7 ;
      }

      Debug.Log(random);
      Instantiate(startchunk, new Vector3(0, 0, 0), Quaternion.identity);
      Instantiate(endchunk, new Vector3((random+1)*46,  0 , 0), Quaternion.identity);
      for (int i = 0; i < random; i++)
      {
              Instantiate(middlechunks[Random.Range(0,middlechunks.Length)], new Vector3((i+1)*46,  0 , 0), Quaternion.identity);
      }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
