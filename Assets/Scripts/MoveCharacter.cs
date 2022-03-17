using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCharacter : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private SpriteRenderer mySpriteRenderer;
    private GameObject canvas;
    public GameObject checkattack;
    private PauseMenu pausemenuUI;
    private bool pauseconf;
    private static bool isJumping = false; 
    private float moveHorizontal;
    private float speed = 5f;
    private float jumpHeight = 8f;
    private float dashx = 5.5f;
    private int vdash = 0;
    public int maxhealth = 100;
    public Slider currenthealth;
    public GameObject gameover;
    private int dead = 0;
    public Animator animator;
    public Collider2D body;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>(); 

        canvas = GameObject.Find("Canvas");
        pausemenuUI = canvas.GetComponent<PauseMenu>();
        currenthealth.value = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Confirmação de Pausa
        pauseconf = pausemenuUI.GP;

        if (Input.GetKeyDown(KeyCode.D) && (pauseconf == false) && (dead == 0))
        {
           this.mySpriteRenderer.flipX = false; 
        }

        if (Input.GetKeyDown(KeyCode.A) && (pauseconf == false) && (dead == 0))
        {
           this.mySpriteRenderer.flipX = true;    
           checkattack.GetComponent<BoxCollider2D>().offset = new Vector2(-0.81f, 0.15f);
           checkattack.GetComponent<BoxCollider2D>().size = new Vector2(1.75f, 1.54f);
        }

        //Crouch
        if (Input.GetButtonDown("Fire1") && (moveHorizontal == 0f) && (pauseconf == false) && (dead == 0)) 
        {
            animator.SetBool("crouch", true);
            speed = 0f;
            StartCoroutine(Crouch2()); 
        } else if (Input.GetButtonDown("Fire1") && (moveHorizontal != 0f) && (pauseconf == false) && (dead == 0)) 
        {
            
            animator.SetBool("slide", true);
            StartCoroutine(Slide()); 
        } else if (Input.GetButtonUp("Fire1") && (pauseconf == false) && (dead == 0)) 
        {
            speed = 4f;
            animator.SetBool("crouch2", false);
            animator.SetBool("crouch", false);
        }

        if ((Input.GetButtonDown("Fire2")) && (Input.GetKey(KeyCode.LeftShift)) && (animator.GetBool ("dash") == false) && (pauseconf == false) && (dead == 0)) 
        {
            animator.SetBool("dashattack", true);
            if (this.mySpriteRenderer.flipX == false) {
               gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(dashx, 0f), ForceMode2D.Impulse); 
               StartCoroutine(DashAttackover());  
            } else if (this.mySpriteRenderer.flipX == true) {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-dashx, 0f), ForceMode2D.Impulse); 
                StartCoroutine(DashAttackover());  
            }         
        } else if (Input.GetButtonDown("Fire2") && (animator.GetBool ("attack") == false) && (animator.GetBool ("dashattack") == false) && (pauseconf == false) && (dead == 0)) 
        {
            animator.SetBool("attack", true);
            StartCoroutine(Attackover()); 
        } else if (Input.GetButtonDown("Fire3") && (pauseconf == false) && (dead == 0)) 
        {
            if ((this.mySpriteRenderer.flipX == false) && (vdash == 0) && (pauseconf == false) && (dead == 0)) 
            {
            animator.SetBool("dash", true);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(dashx, 0f), ForceMode2D.Impulse); 
            vdash = 1;
            StartCoroutine(Dashover());                 
            } else if ((this.mySpriteRenderer.flipX == true) && (vdash == 0) && (pauseconf == false) && (dead == 0)) 
            {
            animator.SetBool("dash", true);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-dashx, 0f), ForceMode2D.Impulse); 
            vdash = 1;
            StartCoroutine(Dashover()); 
            }
        }

        if(currenthealth.value == 0) {
           animator.SetBool("dead", true);
           gameover.SetActive(true); 
           speed = 0;
           dead = 1;
           body.enabled = false;
            body.GetComponent<Rigidbody2D>().isKinematic = true;
        }

        if (Input.GetButtonDown("Jump") && (isJumping == false) && (pauseconf == false) && (dead == 0)) 
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
            animator.SetBool("jump", true);
        }

        animator.SetFloat("yspeed", rb.velocity.y);
    }

    void FixedUpdate()
    {

        moveHorizontal = Input.GetAxis ("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);
        animator.SetFloat("speed", Mathf.Abs(moveHorizontal));
        rb.transform.position += movement * Time.deltaTime * speed; 
    }

    void OnTriggerStay2D(Collider2D enemy)
    {
        if(enemy.gameObject.tag == "enemy")
        {
            TakeDamage(1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       isJumping = false;
       animator.SetBool("jump", false);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isJumping = true; 
    }

    void TakeDamage(int damage)
    {
        currenthealth.value -= damage;
    }

    IEnumerator Slide()
    {
        yield return new WaitForSeconds(0.5f);
 
        animator.SetBool("slide", false);
    }

    IEnumerator Crouch2()
    {
        yield return new WaitForSeconds(0.4f);
 
        animator.SetBool("crouch2", true);
    }

    IEnumerator Dashover()
    {
        yield return new WaitForSeconds(0.7f);
        animator.SetBool("dash", false);
        yield return new WaitForSeconds(5f);
        vdash = 0;
    }

    IEnumerator Attackover()
    {
        yield return new WaitForSeconds(0.6f);
        checkattack.GetComponent<BoxCollider2D>().enabled = true;
        if (this.mySpriteRenderer.flipX == false) {
           checkattack.GetComponent<BoxCollider2D>().offset = new Vector2(0.81f, 0.15f);
           checkattack.GetComponent<BoxCollider2D>().size = new Vector2(1.75f, 1.54f);
        } else if (this.mySpriteRenderer.flipX == true) {
           checkattack.GetComponent<BoxCollider2D>().offset = new Vector2(-0.81f, 0.15f);
           checkattack.GetComponent<BoxCollider2D>().size = new Vector2(1.75f, 1.54f); 
        }
        yield return new WaitForSeconds(0.05f);
        checkattack.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.15f);
        checkattack.GetComponent<BoxCollider2D>().enabled = true;
        checkattack.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0.6f);
        checkattack.GetComponent<BoxCollider2D>().size = new Vector2(3.44f, 2.21f);
        yield return new WaitForSeconds(0.05f);
        checkattack.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.05f);
        animator.SetBool("attack", false);
    }

    IEnumerator DashAttackover()
    {
        yield return new WaitForSeconds(0.5f);
        checkattack.GetComponent<BoxCollider2D>().enabled = true;
        if(this.mySpriteRenderer.flipX == false) {
            checkattack.GetComponent<BoxCollider2D>().offset = new Vector2(0.69f, 0.26f);
            checkattack.GetComponent<BoxCollider2D>().size = new Vector2(2.56f, 2.33f);
        }else if(this.mySpriteRenderer.flipX == true) {
            checkattack.GetComponent<BoxCollider2D>().offset = new Vector2(-0.69f, 0.26f);
            checkattack.GetComponent<BoxCollider2D>().size = new Vector2(2.56f, 2.33f);
        }
        
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("dashattack", false);
    }
}
