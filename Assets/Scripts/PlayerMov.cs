using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement ;
using UnityEngine.Advertisements;


public class PlayerMov : MonoBehaviour
{
    private string gameId = "YourGameIDHere";
    [Header("Player & Level attributes")]
    public float timeSlowVariable = 0.5f ;
    public int lifeDrainDivider ;
    public float force;
    public float foodMultiplier ;
    public AudioSource audioSource ;
    public float startingTime = 100f;
    [Header("Game Objects")]
    public GameObject showAds ;
    public GameObject timer ;
    public Text Timer ;
    public GameObject gameOverscreen ;
    public GameObject finishScreen ;
    [SerializeField] Text finishTimeText;
    [SerializeField] Text newHiScore;
    [SerializeField] Text countdownText;
    public GameObject Ui ;
    public Rigidbody2D player ;
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public LineRenderer lr ;
    [Header("Prefab Filled & bools")]
    public ParticleSystem ps;
    public ParticleSystem pf;
    public ParticleSystem ta;
    public ParticleSystem gold;
    public bool gameOver ;
    public bool finish = false;
    public Color playerColor ;
    float currentTime;
    float levelTime ;
    float highScore ;
    bool secondtrybool ;
    float generalTimeScale = 1 ;
    float endlessScore;
    public float secondtryCounter = 3 ;
    float soundVolume ;
    int effectVolume ;




      // Start is called before the first frame update
    void Start(){
      playerColor = new Color(PlayerPrefs.GetFloat("colorR" , 255f )/255f , PlayerPrefs.GetFloat("colorG" , 255f )/255f ,PlayerPrefs.GetFloat("colorB" , 255f )/255f , 255f) ;
      var main = ps.main;
      gameObject.GetComponent<SpriteRenderer>().color = playerColor ;
      gameObject.GetComponent<TrailRenderer>().startColor = playerColor ;
      gameObject.GetComponent<TrailRenderer>().endColor = playerColor ;
      lr.startColor = playerColor ;
      lr.endColor = Color.white ;
      main.startColor = playerColor ;
      highScore = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().buildIndex.ToString() , startingTime ) ;
      StartCoroutine(Countdown());
      ps.Clear();
      SetMaxHealth();
      currentTime = startingTime;
      countdownText.text = currentTime.ToString("0");
      endlessScore = PlayerPrefs.GetFloat("endlessScore" , 0 ) ;
      if(SceneManager.GetActiveScene().buildIndex == 14) secondtryCounter = PlayerPrefs.GetFloat("secondtryCounter" , secondtryCounter ) ;
      soundVolume = PlayerPrefs.GetFloat("soundVolume" , 0.1f) ;
      effectVolume = PlayerPrefs.GetInt("effectVolume" , 1) ;
      Advertisement.Initialize (gameId, false);

    }

    void FixedUpdate(){
        if(secondtrybool)
        {transform.localScale += new Vector3(0.005f,0.005f,0);
        SetHealth();}
        if(transform.localScale.x >= 1 )
        {
          secondtrybool = false ;
          transform.localScale = new Vector3(1,1,0);
        }

    }

    void Update(){
      Camera.main.gameObject.GetComponent<AudioSource>().volume = soundVolume ;
      Camera.main.gameObject.GetComponent<AudioSource>().pitch = Time.timeScale ;
      audioSource.pitch = Time.timeScale ;
      if(SceneManager.GetActiveScene().buildIndex == 14 && secondtryCounter == 0 && gameOver)
      {
        PlayerPrefs.SetFloat("secondtryCounter" , 3) ;
        finishTheRun();
      }


      if(PlayerPrefs.GetInt("rewardedVideo" , 0) == 1 )
      {
        if(secondtryCounter == 0 )
        {
          showAds.SetActive(false);
        }
        else{
          secondtry();
          secondtryCounter -= 1 ;
          if(secondtryCounter == 0 )
          {
            showAds.SetActive(false);
          }
          PlayerPrefs.SetFloat("secondtryCounter" , secondtryCounter) ;
        }


      }

      if(!Advertisement.isShowing)
      {
        Time.timeScale = generalTimeScale ;
      }
      else{
        Time.timeScale = 0f ;
      }

      if(!finish)
      {
        if(gameOver)
        {
          Camera.main.gameObject.GetComponent<AudioSource>().enabled = false ;
          Ui.SetActive(false) ;
          gameOverscreen.SetActive(true);
        }
        else{
          if(!timer.activeSelf)
          {
            currentTime -= Time.deltaTime;
            levelTime += Time.deltaTime ;
            countdownText.text = currentTime.ToString("0");
            if (currentTime <= 0)
            {
                currentTime = 0;
                gameOver = true ;
            }
            Camera.main.gameObject.GetComponent<AudioSource>().enabled = true ;
            if(Input.GetMouseButton(0))
            {
              DrawArrow();
            }
            if(Input.GetMouseButtonUp(0))
            {
              MoveToMouse();
            }
          }
        }
      }else
      {
          Ui.SetActive(false) ;
          Camera.main.gameObject.GetComponent<AudioSource>().enabled = false ;
      }
    }

    void OnTriggerEnter2D (Collider2D other){
      if(!finish)
      {
        if(!gameOver)
        {
          if(other.gameObject.tag == "Endless"){
              other.gameObject.GetComponent<AudioSource>().volume = effectVolume ;
              other.gameObject.GetComponent<AudioSource>().pitch = Time.timeScale;
              other.gameObject.GetComponent<AudioSource>().Play();
              endlessScore += 1   ;
              PlayerPrefs.SetFloat("endlessScore" , endlessScore) ;
              getGold(endlessScore * 3) ;
              if(endlessScore > PlayerPrefs.GetFloat(SceneManager.GetActiveScene().buildIndex.ToString() , 0 ))
              {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().buildIndex.ToString() , endlessScore ) ;
                newHiScore.gameObject.SetActive(true) ;
              }
              StartCoroutine(endlessReached()) ;

          }
          if(other.gameObject.tag == "Food"){
              other.gameObject.GetComponent<AudioSource>().volume = effectVolume ;
            other.gameObject.GetComponent<AudioSource>().pitch = Time.timeScale;
              other.gameObject.GetComponent<AudioSource>().Play();
              eat();
              pf.Clear();
              pf.Play();
              other.gameObject.GetComponent<SpriteRenderer>().enabled = false ;
              other.gameObject.GetComponent<BoxCollider2D>().enabled = false ;
          }
          if(other.gameObject.tag == "Gold"){
              other.gameObject.GetComponent<AudioSource>().volume = effectVolume ;
              other.gameObject.GetComponent<AudioSource>().pitch = Time.timeScale;
              other.gameObject.GetComponent<AudioSource>().Play();
              getGold(1f);
              gold.Clear();
              gold.Play();
              other.gameObject.GetComponent<SpriteRenderer>().enabled = false ;
              other.gameObject.GetComponent<BoxCollider2D>().enabled = false ;
          }
          if(other.gameObject.tag == "slowTime"){

              generalTimeScale = timeSlowVariable;
          }
          if(other.gameObject.tag == "Electric"){
                other.gameObject.GetComponent<AudioSource>().volume = effectVolume ;
                other.gameObject.GetComponent<AudioSource>().pitch = Time.timeScale;
                other.gameObject.GetComponent<AudioSource>().Play();
                ps.Clear();
                ps.Play();
                transform.localScale = new Vector3((float)0.1,(float)0.1,0);
                gameOver = true ;
                other.gameObject.GetComponent<Collider>().enabled = false;
          }
          if(other.gameObject.tag == "End"){
                other.gameObject.GetComponent<AudioSource>().volume = effectVolume ;
                other.gameObject.GetComponent<AudioSource>().pitch = Time.timeScale;
                other.gameObject.GetComponent<AudioSource>().Play();
                pf.Clear();
                pf.Play();
                finish = true ;
                countdownText.enabled = false;
                finishTimeText.text = levelTime.ToString("#.00");

                if(startingTime > 100 || (startingTime-levelTime) < 0)getGold(10);
                else getGold(startingTime - levelTime);


                if(levelTime < highScore)
                {
                  PlayerPrefs.SetFloat(SceneManager.GetActiveScene().buildIndex.ToString() , levelTime ) ;
                  newHiScore.gameObject.SetActive(true) ;

                }

                if (SceneManager.GetActiveScene().buildIndex + 1 > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", SceneManager.GetActiveScene().buildIndex + 1);
                }

                finishScreen.SetActive(true) ;

          }
          if(other.gameObject.tag == "addTime"){
                other.gameObject.GetComponent<AudioSource>().volume = effectVolume ;
                other.gameObject.GetComponent<AudioSource>().pitch = Time.timeScale;
                other.gameObject.GetComponent<AudioSource>().Play();
                timeAdd();
                ta.Clear();
                ta.Play();
                other.gameObject.GetComponent<SpriteRenderer>().enabled = false ;
                other.gameObject.GetComponent<BoxCollider2D>().enabled = false ;
          }

        }
      }
    }

    void OnTriggerExit2D(Collider2D other){

      if(other.gameObject.tag == "slowTime"){

          generalTimeScale = 1f;
      }
    }



    public void secondtry()  {
      secondtrybool = true ;
      PlayerPrefs.SetInt("rewardedVideo" , 0) ;
      currentTime = startingTime ;
      gameOver = false ;
      Ui.SetActive(true) ;
      gameOverscreen.SetActive(false);
      StartCoroutine(Countdown()) ;

    }

    void DrawArrow(){
      lr.enabled = true ;
      Vector3 mousePosition = Input.mousePosition;
      mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
      Vector3 direction = new Vector3( mousePosition.x , mousePosition.y , 0);
      lr.startWidth = 0.3f ;
      Vector3 dir = direction - transform.position;
      float dist = Mathf.Clamp(Vector3.Distance(transform.position, direction), 0, 5);
      direction = transform.position + (dir.normalized * dist);
      lr.SetPosition(0 , transform.position);
      lr.SetPosition(1 , direction);
    }

    void MoveToMouse(){
      if(transform.localScale.x < 0.3)
      {
        ps.Clear();
        ps.Play();
        transform.localScale = new Vector3((float)0.1,(float)0.1,0);
        gameOver = true ;
      }
      Vector3 mousePosition = Input.mousePosition;
      mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
      Vector2 direction = new Vector2( mousePosition.x - transform.position.x , mousePosition.y - transform.position.y);
      transform.up = direction;
      player.AddForce(direction*force , ForceMode2D.Impulse) ;
      Vector3 scaleChange = new Vector3(-direction.magnitude/lifeDrainDivider, -direction.magnitude/lifeDrainDivider, 0);
      transform.localScale += scaleChange;
      lr.enabled = false ;
      ps.Clear();
      ps.Play();
      audioSource.volume = effectVolume ;
      audioSource.Play();
      SetHealth();

    }


    void getGold(float Amount){
      float gold = PlayerPrefs.GetFloat("Gold" , 0 ) ;
      gold += Amount ;
      PlayerPrefs.SetFloat("Gold" , gold) ;

    }


    void eat(){
      Vector3 scaleChange = new Vector3(foodMultiplier , foodMultiplier , 0);
      if(transform.localScale.x + scaleChange.x > 1 )
      {
        transform.localScale = new Vector3(1 , 1 , 0);
      }
      else
      {
        transform.localScale += scaleChange;
      }
      SetHealth();
    }
    void timeAdd(){
      currentTime += 10 ;
    }

    public void Restart(){

      Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
    public void finishTheRun()  {
      audioSource.Play();
      finish = true ;
      gameOverscreen.SetActive(false) ;
      levelTime = endlessScore ;
      finishTimeText.text = levelTime.ToString();
      finishScreen.SetActive(true);
      PlayerPrefs.SetFloat("endlessScore" , 0 );

    }
    public void mainMenu()  {
      SceneManager.LoadScene(15);
    }

    public void goToNextLevel(){
      if(SceneManager.GetActiveScene().buildIndex == 13)
      {
        SceneManager.LoadScene(0);
      }
      else
      {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      }
    }
    public void SetMaxHealth(){

      slider.maxValue = transform.localScale.x-(float)0.2;
      slider.value = transform.localScale.x-(float)0.2;
      fill.color = gradient.Evaluate(1f);

    }
    public void SetHealth(){

      slider.value = transform.localScale.x - (float)0.2 ;
      fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SoundMute(bool isMuted){
      if(isMuted) {
        PlayerPrefs.SetFloat("soundVolume" , 0.1f) ;
      }
      else{
         PlayerPrefs.SetFloat("soundVolume" , 0) ;
       }

    }
    public void EffectsMute(bool isMuted){
      if(isMuted) {
        PlayerPrefs.SetInt("effectVolume" , 1) ;
      }
      else{
         PlayerPrefs.SetInt("effectVolume" , 0) ;
       }
    }
    IEnumerator Countdown(){
        Camera.main.gameObject.GetComponent<AudioSource>().enabled = false ;
        timer.SetActive(true) ;
        Timer.text = "3" ;
        yield return new WaitForSeconds(1);
        Timer.text = "2" ;
        yield return new WaitForSeconds(1);
        Timer.text = "1" ;
        yield return new WaitForSeconds(1);
        Timer.text = "Go On!" ;
        yield return new WaitForSeconds(1);
        timer.SetActive(false) ;
    }
    IEnumerator endlessReached(){
        timer.SetActive(true) ;
        Timer.color = Color.yellow ;
        Timer.text = endlessScore.ToString() ;
        generalTimeScale = 0.5f ;
        yield return new WaitForSeconds(1);
        generalTimeScale = 1f ;
        timer.SetActive(false) ;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }



}
