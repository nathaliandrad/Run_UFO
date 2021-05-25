
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float speed;
    private int count;
    public Text countText;
    public Text winText;
    public float movementSpeed;
    public bool win;
    public Text livesText;
    public GameObject portal;
    public GameObject enemy2;
    public AudioSource speaker;
    public AudioClip coin;
    public AudioClip enemyColissionSound;
    public AudioClip powerUp;

    public SpriteRenderer enemySprite;



    Color enemyColor = new Color(144, 13, 1, 255);
    public int nextScene;
 



    public void Start()
    {
        speaker = GetComponent<AudioSource>();

        win = false;
        rb2D = GetComponent<Rigidbody2D>();
        count = 0;
        countText.text = "";
        SetCountLives();
        winText.text = "";
        SetCountText();

        portal.gameObject.SetActive(false);

        nextScene = SceneManager.GetActiveScene().buildIndex + 1;


        if(GM.lives < 0) {
            SceneManager.LoadScene(7);
        }
       

        speaker.Play();

    }

    public void FixedUpdate()
    {

       
       if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2)) {

             enemySprite = GameObject.FindGameObjectWithTag("UFOSpriteEnemy").GetComponent<SpriteRenderer>();
        }

        
         float moveHorizontal = Input.GetAxis("Horizontal");
         float moveVertical = Input.GetAxis("Vertical");
         Vector2 movement = new Vector2(moveHorizontal,moveVertical);
         rb2D.AddForce(movement * speed );
         


        if (win == true)
        {
            Debug.Log("Hereee");
            StartCoroutine(wait());
            SceneManager.LoadScene(nextScene);
        }


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp")) {
            speaker.PlayOneShot(coin, 1);
            collision.gameObject.SetActive(false);
            count++;
            SetCountText();
        }

        if (collision.gameObject.CompareTag("Portal"))
        {
            collision.gameObject.SetActive(false);
            win = true;
      
        }

        if (collision.gameObject.CompareTag("SpecialPower"))
        {
            speaker.PlayOneShot(powerUp, 1);

            collision.gameObject.SetActive(false);

            enemySprite.color = enemyColor;

        }

        if (collision.gameObject.CompareTag("SpecialPower2"))
        {

            speaker.PlayOneShot(powerUp, 1);
            collision.gameObject.SetActive(false);
            enemy2.SetActive(false);


        }



    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy2")) {
            speaker.PlayOneShot(enemyColissionSound, 1);
            
            print("Testing collision with enemy");
          
            GM.lives -= 1;

            SetCountLives();

            FindObjectOfType<GameManager>().EndGame();
        }
      



    }



    void SetCountText() {
        countText.text = "Count: " + count.ToString();

        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1)) {
            if (count >= 10)
            {
                winText.text = "Go to the next Level";
                portal.gameObject.SetActive(true);
           
            }
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            if (count > 13)
            {
                winText.text = "Go to the next Level";
                portal.gameObject.SetActive(true);
     
            }
        }
       else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
        {
            if (count >= 18)
            {
                winText.text = "Go to the next Level";
                portal.gameObject.SetActive(true);

            }
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(4))
        {
            if (count >= 24)
            {
                winText.text = "Congrats you win";
                portal.gameObject.SetActive(true);

            }
        }


    }

    
    void SetCountLives() {

        livesText.text = "LIVES: " + GM.lives.ToString();

    }

    IEnumerator wait() {
        print(Time.time);
        yield return new WaitForSeconds(10.0f);
        print(Time.time);

    }





}
