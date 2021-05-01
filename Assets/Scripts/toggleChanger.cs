using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleChanger : MonoBehaviour
{
    public Toggle sound ;
    public Toggle effect ;

    // Start is called before the first frame update
    void Start()
    {
      if(PlayerPrefs.GetFloat("soundVolume" , 0.1f) == 0.1f) sound.isOn = true ;
      else sound.isOn = false ;
      if(PlayerPrefs.GetInt("effectVolume" , 1) == 1) effect.isOn = true ;
      else effect.isOn = false ;

    }


}
