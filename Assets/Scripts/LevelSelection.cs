using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;
    public Text[] HiScores;

    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2); /* < Change this int value to whatever your build settings */

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 2 > levelAt)
                lvlButtons[i].interactable = false;
        }


        for (int i = 0; i < HiScores.Length; i++)
        {
              Debug.Log(PlayerPrefs.GetFloat( (i+2).ToString() , 0).ToString()) ;
              HiScores[i].text = PlayerPrefs.GetFloat( (i+2).ToString() , 0).ToString("#.00") ;
        }
    }
    void Update()
    {
      Camera.main.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("soundVolume" , 0.1f) ;
    }
    public void gotoLevel(int Level)
    {
      SceneManager.LoadScene(Level + 1);
    }

}
