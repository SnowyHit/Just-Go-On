using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class marketplaceController : MonoBehaviour
{
    // Start is called before the first frame update
    Text previewText ;
    public Button[] Buttons ;
    public float UnlockPrice ;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      if(PlayerPrefs.GetInt("onUnlockYellow" , 0 ) == 1 ) Buttons[0].gameObject.SetActive(false) ;
      if(PlayerPrefs.GetInt("onUnlockBlue" , 0 ) == 1 ) Buttons[1].gameObject.SetActive(false) ;
      if(PlayerPrefs.GetInt("onUnlockCyan" , 0 ) == 1 ) Buttons[2].gameObject.SetActive(false) ;
      if(PlayerPrefs.GetInt("onUnlockGreen" , 0 ) == 1 ) Buttons[3].gameObject.SetActive(false) ;
      if(PlayerPrefs.GetInt("onUnlockGray" , 0 ) == 1 ) Buttons[4].gameObject.SetActive(false) ;
      if(PlayerPrefs.GetInt("onUnlockPurple" , 0 ) == 1 ) Buttons[5].gameObject.SetActive(false) ;
      if(PlayerPrefs.GetInt("onUnlockPink" , 0 ) == 1 ) Buttons[6].gameObject.SetActive(false) ;
      if(PlayerPrefs.GetInt("onUnlockRed" , 0 ) == 1 ) Buttons[7].gameObject.SetActive(false) ;

    }



    public void onUnlockYellow()
    {
      if(PlayerPrefs.GetFloat("Gold" , 0 ) >= UnlockPrice)
      {
        PlayerPrefs.SetFloat("Gold" , (PlayerPrefs.GetFloat("Gold" , 0 ) - UnlockPrice ) ) ;
        PlayerPrefs.SetInt("onUnlockYellow" , 1 ) ;
      }
    }
    public void onUnlockGreen()
    {
      if(PlayerPrefs.GetFloat("Gold" , 0 ) >= UnlockPrice)
      {
        PlayerPrefs.SetFloat("Gold" , (PlayerPrefs.GetFloat("Gold" , 0 ) - UnlockPrice ) ) ;
        PlayerPrefs.SetInt("onUnlockGreen" , 1 ) ;
      }
    }public void onUnlockGray()
    {
      if(PlayerPrefs.GetFloat("Gold" , 0 ) >= UnlockPrice)
      {
        PlayerPrefs.SetFloat("Gold" , (PlayerPrefs.GetFloat("Gold" , 0 ) - UnlockPrice ) ) ;
        PlayerPrefs.SetInt("onUnlockGray" , 1 ) ;
      }
    }public void onUnlockCyan()
    {
      if(PlayerPrefs.GetFloat("Gold" , 0 ) >= UnlockPrice)
      {
        PlayerPrefs.SetFloat("Gold" , (PlayerPrefs.GetFloat("Gold" , 0 ) - UnlockPrice ) ) ;
        PlayerPrefs.SetInt("onUnlockCyan" , 1 ) ;
      }
    }public void onUnlockBlue()
    {
      if(PlayerPrefs.GetFloat("Gold" , 0 ) >= UnlockPrice)
      {
        PlayerPrefs.SetFloat("Gold" , (PlayerPrefs.GetFloat("Gold" , 0 ) - UnlockPrice ) ) ;
        PlayerPrefs.SetInt("onUnlockBlue" , 1 ) ;
      }
    }public void onUnlockPurple()
    {
      if(PlayerPrefs.GetFloat("Gold" , 0 ) >= UnlockPrice)
      {
        PlayerPrefs.SetFloat("Gold" , (PlayerPrefs.GetFloat("Gold" , 0 ) - UnlockPrice ) ) ;
        PlayerPrefs.SetInt("onUnlockPurple" , 1 ) ;
      }
    }public void onUnlockPink()
    {
      if(PlayerPrefs.GetFloat("Gold" , 0 ) >= UnlockPrice)
      {
        PlayerPrefs.SetFloat("Gold" , (PlayerPrefs.GetFloat("Gold" , 0 ) - UnlockPrice ) ) ;
        PlayerPrefs.SetInt("onUnlockPink" , 1 ) ;
      }
    }public void onUnlockRed()
    {
      if(PlayerPrefs.GetFloat("Gold" , 0 ) >= UnlockPrice)
      {
        PlayerPrefs.SetFloat("Gold" , (PlayerPrefs.GetFloat("Gold" , 0 ) - UnlockPrice ) ) ;
        PlayerPrefs.SetInt("onUnlockRed" , 1 ) ;
      }
    }

    public void onClickYellow()
    {
      setColor(250f , 255f , 99f);
    }
    public void onClickGreen()
    {
      setColor(133f , 255f , 92f);
    }
    public void onClickGray()
    {
      setColor(89f , 89f , 89f);
    }
    public void onClickCyan()
    {
      setColor(93f , 233f , 255f);
    }
    public void onClickBlue()
    {
      setColor(0f , 47f , 255f);
    }
    public void onClickPurple()
    {
      setColor(128f , 0f , 111f);
    }
    public void onClickPink()
    {
      setColor(255f , 172f , 243f);
    }
    public void onClickPink2()
    {
      setColor(255f , 255f ,255f);
    }
    public void onClickRed()
    {
      setColor(255f , 0f ,0f);
    }

    public void setColor(float r ,float g ,float b)
    {
      PlayerPrefs.SetFloat("colorR" , r) ;
      PlayerPrefs.SetFloat("colorG" , g) ;
      PlayerPrefs.SetFloat("colorB" , b) ;
      Debug.Log("Set Float !");

    }
}
