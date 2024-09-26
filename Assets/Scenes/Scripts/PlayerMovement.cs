using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Transform Coin;
    public GameObject[] EnemyPieces;

    public AudioClip Hit;
    public AudioClip CollectCoin;
    public AudioClip Win;
    public AudioClip Lose;

    public Text HPtext;
    public Text CoinsText;
    public Text RestartText;
    public Text WinMsg;

    AudioSource Sounds;

    public GameObject Screen;
    public GameObject GameOverS;

    int Min = -2;
    int Max = 3;
    int CoinScore = 0;
    int Lives = 3;

    bool GameOver = false;
    bool WinGame = false;


    // Start is called before the first frame update
    void Start()
    {

        Sounds = GetComponent<AudioSource>();
       // GameOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        CoinsText.text = "Coins: " + CoinScore;
        HPtext.text = "HP: " + Lives;
        RestartText.enabled = false;
        WinMsg.enabled = false;

        if (GameOver == true)
        {
            var color = GameOverS.GetComponent<Image>().color;
            color.a = 1f;
            GameOverS.GetComponent<Image>().color = color;
            RestartText.enabled = true;
            WinMsg.enabled = false;

            if (Input.GetKeyDown("r")) 
            {
                if (GameOverS != null) 
                {
                    color.a = 0f;
                    GameOverS.GetComponent<Image>().color = color;
                }

                Lives = 3;
                CoinScore = 0;
                RestartText.enabled = false;
                WinMsg.enabled = false;
                WinGame = false;
                GameOver = false;
            }
                return;
        }

        else if (GameOver == false)
        {
            // (PLAYER MOVEMENT) \\
            if (Input.GetKeyDown("w"))
            {
                if (transform.position.x >= 3f)
                {
                    transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
                }
                else
                {
                    Sounds.Play();
                    transform.position += new Vector3(1f, 0f, 0f);
                    transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
                }
            }

            if (Input.GetKeyDown("d"))
            {
                if (transform.position.z < -1f)
                {
                    transform.rotation = Quaternion.AngleAxis(-90, Vector3.up);
                }
                else
                {
                    Sounds.Play();
                    transform.position += new Vector3(0f, 0f, -1f);
                    transform.rotation = Quaternion.AngleAxis(-90, Vector3.up);
                }
            }

            if (Input.GetKeyDown("a"))
            {
                if (transform.position.z >= 3f)
                {
                    transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
                }
                else
                {
                    Sounds.Play();
                    transform.position += new Vector3(0f, 0f, 1f);
                    transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
                }
            }

            if (Input.GetKeyDown("s"))
            {
                if (transform.position.x < -2f)
                {
                    transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
                }
                else
                {
                    Sounds.Play();
                    transform.position += new Vector3(-1f, 0f, 0f);
                    transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
                }
            }


            if (transform.position == Coin.position)
            {
                int RandomPosX = Random.Range(Min, Max + 1);
                int RandomPosZ = Random.Range(Min, Max + 1);

                Sounds.PlayOneShot(CollectCoin);
                Coin.position = new Vector3(RandomPosX, 0.5f, RandomPosZ);
                CoinScore += 1;
                Debug.Log("Coins Collected: " + CoinScore);
            } // Coin Function 

            // (Screen Fade) \\   "Learned this from a tutorial"
            if (Screen != null)
            {
                if (Screen.GetComponent<Image>().color.a > 0)
                {
                    var color = Screen.GetComponent<Image>().color;

                    color.a -= 0.002f;

                    Screen.GetComponent<Image>().color = color;
                }
            }

            if (Lives <= 0 && !GameOver)
            {
                GameOver = true;
                Sounds.PlayOneShot(Lose);
            }

            if (CoinScore == 50 && !WinGame) 
            {
                WinGame = true;
                Sounds.PlayOneShot(Win);
            }
        }

         if (WinGame == true)
        {
            WinMsg.enabled = true;
            return;
        }

    } // Void Update End

    private void OnTriggerEnter(Collider detect) //This is the collision function, the player and enemy need a box collider for it to work and have it set to "IsTrigger"
    {
            for (int i = 0; i < EnemyPieces.Length; i++)
            {
                if (detect.gameObject == EnemyPieces[i]) 
                {
                    var color = Screen.GetComponent<Image>().color; // This is how I change the screen to red, I usually only effect its alpha color tho (it acts like a transparency property)
                    color.a = 0.8f;

                    Screen.GetComponent<Image>().color = color;
                    Sounds.PlayOneShot(Hit);
                    transform.position = new Vector3(-3f, 0.5f, -2f);
                    Lives -= 1;

                    Debug.Log("Lives Left: " + Lives);
                }
            }

        
    }
} // Script End

// THIS WAS MY OLD CODE FOR ENEMY COLLISIONS


//if (transform.position == EnemyPiece.position)
//{
//    var color = Screen.GetComponent<Image>().color;
//    color.a = 0.8f;

//    Screen.GetComponent<Image>().color = color;
//    Sounds.PlayOneShot(Hit);
//    transform.position = new Vector3(-3f, 0.5f, -2f);
//    Lives -= 1;

//    Debug.Log("Lives Left: " + Lives);
//}

//gameObject.CompareTag("Enemy") I had the function use something like tags before, It doesn't really benefit much since we are using arrays but I thought it was something to share

// the ! next to your variable is the most confusing thing ever, I guess it's there to prevent mass spam but I don't know how the lost sound works without it. I added it to GameOver anyway just in case.