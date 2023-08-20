using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public GameObject mech;
    public float speed;
    public float jumpForce;
    public bool touchGround;
    public int kolmon;
    public Text textMonetka;
    public Animator animator;
    public bool getLevel4;
    public bool IsAtacked;
    public int PudgevoiHuk;
    public int hpid;
    public GameObject[] hearts;
    public Sprite RedHeart;
    public Sprite BlackHeart;
    public GameObject GameOver;
    public bool IsTouchingZoneKotl;
    public bool getLevel5;
    public GameObject Kotl;


    /// <summary>
    /// ////////////////////////////////////////////
    /// </summary>


    // Start is called before the first frame update
    void Start()
    {

        hpid = 3;
        animator = gameObject.GetComponent<Animator>();
        PudgevoiHuk = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.N))
        {
            gameObject.GetComponent<Transform>().localScale = new Vector2(15, 15);
        }
        else if (Input.GetKeyUp(KeyCode.N))
        {
            gameObject.GetComponent<Transform>().localScale = new Vector2(7, 7);
        }

        if (IsAtacked == true)
        {
            animator.Play("ataka titanov");
        }

        if (Input.GetMouseButtonDown(0))
        {
            IsAtacked = true;
        }


        if (Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<Transform>().Translate(Vector2.right * speed * Time.deltaTime);
            gameObject.GetComponent<Transform>().localScale = new Vector3(-7, 7, 1);
            animator.Play("€ бегаю");
        }



        else if (Input.GetKey(KeyCode.A))
        {
            gameObject.GetComponent<Transform>().Translate(Vector2.left * speed * Time.deltaTime);
            gameObject.GetComponent<Transform>().localScale = new Vector3(7, 7, 1);
            animator.Play("€ бегаю");
        }
        else if (IsAtacked == false)
        {
            animator.Play("€ стою");
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (touchGround == true)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        if (touchGround == true)
        {

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LytsheYaByNeSholVles")
        {
            Debug.Log("»зијегисЌа6левле");
            gameObject.GetComponent<player>().hpid--;
        }
        touchGround = true;//только когда косаетьс€ земли//
        if (collision.gameObject.tag == "monetka")
        {
            kolmon += 1;
            textMonetka.text = kolmon.ToString();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "level 2")
        {
            if (gameObject.GetComponent<Transform>().position.x
                <= collision.gameObject.GetComponent<Transform>().position.x)
            {
                gameObject.GetComponent<Transform>().position = new Vector2(12.88f, -0.55f);
                Camera.main.GetComponent<Transform>().position = new Vector2(20.25f, 0);
            }
            else
            {
                gameObject.GetComponent<Transform>().position = new Vector2(21.36f, -1.64f);
                Camera.main.GetComponent<Transform>().position = new Vector2(20.25f, 0);
            }
        }
        if (collision.gameObject.tag == "level 1")
        {
            gameObject.GetComponent<Transform>().position = new Vector2(0.02f, -0.1f);
            Camera.main.GetComponent<Transform>().position = new Vector2(0, 0);
        }
        if (collision.gameObject.tag == "level 3")
        {
            gameObject.GetComponent<Transform>().position = new Vector2(36.92f, -1.49f);
            Camera.main.GetComponent<Transform>().position = new Vector2(38.24f, 0.52f);

        }
        if (collision.gameObject.tag == "level 4")
        {
            if ((gameObject.GetComponent<Transform>().position.x <= collision.gameObject.GetComponent<Transform>().position.x))
            {
                gameObject.GetComponent<Transform>().position = new Vector2(55.29f, -2.13f);
                Camera.main.GetComponent<Transform>().position = new Vector2(62.8f, -0.42f);
                getLevel4 = true;
            }

            else
            {
                gameObject.GetComponent<Transform>().position = new Vector2(48.12f, -2.44f);
                Camera.main.GetComponent<Transform>().position = new Vector2(38.24f, 0.52f);
                getLevel4 = false;
            }
        }
        if (collision.gameObject.tag == "level 5")
        {
            if ((gameObject.GetComponent<Transform>().position.x <= collision.gameObject.GetComponent<Transform>().position.x))
            {
                
                gameObject.GetComponent<Transform>().position = new Vector2(78.77f, -2.37202f);
                Camera.main.GetComponent<Transform>().position = new Vector2(85.55f, -0.24f);
                getLevel5 = true;

            }

            else
            {
                gameObject.GetComponent<Transform>().position = new Vector2(70.088f, -3.2438f);
                Camera.main.GetComponent<Transform>().position = new Vector2(62.8f, -0.42f);
                getLevel5 = false;
            }
        }
        if (collision.gameObject.tag == "Vertical1")
        {
            gameObject.GetComponent<Transform>().position = new Vector2(90.64f, 8.83f);
            Camera.main.GetComponent<Transform>().position = new Vector2(86.34f, 11.41f);
        }
        if (collision.gameObject.tag == "Vertical2")
        {
            gameObject.GetComponent<Transform>().position = new Vector2(89.96f, 22.94f);
            Camera.main.GetComponent<Transform>().position = new Vector2(86.34f, 22.92f);
        }
        if (collision.gameObject.tag == "Vertical3")
        {
            gameObject.GetComponent<Transform>().position = new Vector2(86.34f, 34.42f);
            Camera.main.GetComponent<Transform>().position = new Vector2(86.55f, 32.57f);
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        touchGround = false;
    }


    public void EndAttack()
    {
        IsAtacked = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Patron")
        {
            Destroy(collision.gameObject);
            hpid--;
            Debug.Log("” теб€ осталось два hp");
            ShowHp();
        }
        //if (collision.gameObject.tag == "KOTL")
        //{
        //    hpid--;
        //    ShowHp();
        //    Debug.Log("XAXXAXAXAXAXAXAXAXAXA");
        //}

        if(collision.gameObject.tag == "KOTL")
        {
            IsTouchingZoneKotl = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "KOTL")
        {
            IsTouchingZoneKotl = false;
        }
    }

    bool OneTimeDamage;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "KOTL")
        {
            if (OneTimeDamage == false)
            {
                StartCoroutine(ILLUMINATION());
                Debug.Log("XAXXAXAXAXAXAXAXAXAXA");
                OneTimeDamage = true;
            }

        }
    }

   
    
        
    
    private IEnumerator ILLUMINATION()
    {
        while(true)
        {
            if(IsTouchingZoneKotl == true)
            {
                hpid--;
                ShowHp();
            }
            yield return new WaitForSeconds(6f);
        }
    }

    private void ShowHp()
    {
        if (hpid == 2)
        {
            hearts[0].GetComponent<SpriteRenderer>().sprite = BlackHeart;
        }
        if (hpid == 1)
        {
            hearts[1].GetComponent<SpriteRenderer>().sprite = BlackHeart;
        }
        if (hpid == 0)
        {
            hearts[2].GetComponent<SpriteRenderer>().sprite = BlackHeart;
            GameOver.SetActive(true);
        }


    }
    public void StartAttack()
    {
        mech.GetComponent<PolygonCollider2D>().enabled=(true);        
    }







}
