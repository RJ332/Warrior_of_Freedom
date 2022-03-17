using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWitch : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 direction;
    public SpriteRenderer mySpriteRenderer;
    public Animator animator;
    public GameObject visao;
    public GameObject player;
    public Collider2D bodyCollider;
    public Collider2D Colliderattack;
    public float speed = 2f;
    private float px1;
    private float px2;
    public int attack;
    

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(attack == 1) {
            /* px1 = transform.position.x;
            px2 = bodyCollider.offset.x;
            px2 = px2 * 2;
            px1 = px1 - px2;
            //print(px2);
            transform.position = new Vector3(px1, transform.position.y, transform.position.z);  */
            attack = 0; 
        }

       if(direction.x < 0) {
           this.mySpriteRenderer.flipX = true; 
            px2 = transform.position.x;
            px2 = px2 + -1.464f;
            visao.transform.position = new Vector3(px2, visao.transform.position.y, visao.transform.position.z);
       } else if(direction.x > 0) {
           this.mySpriteRenderer.flipX = false;
            px1 = transform.position.x;
            px1 = px1 + 0.058f;
            visao.transform.position = new Vector3(px1, visao.transform.position.y, visao.transform.position.z);
       }
    }

    void FixedUpdate()
    {
        if ((animator.GetBool("charge") == true))
        {
            direction = new Vector3(0, 0, 0);
            direction.Normalize();
            animator.SetFloat("speed", Mathf.Abs(speed));
            rb.transform.position += direction * Time.deltaTime * speed;
        } else {
            direction = player.transform.position - transform.position;
            direction.Normalize();
            animator.SetFloat("speed", Mathf.Abs(speed));
            rb.transform.position += direction * Time.deltaTime * speed;  
        } 
    }

    void OnTriggerEnter2D(Collider2D enemy)
    {
        if(enemy.gameObject.tag == "playerattack")
        {
            animator.SetBool("hit", true);
            speed = 0f;
            StartCoroutine(hithouver()); 
        }
    }

    IEnumerator hithouver() {
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("hit", false);
    }

    /* void OnTriggerEnter2D(Collider2D  collision)
    {
       if((collision.gameObject.tag == "stop") && (animator.GetBool("attack") == false)) {

        if (this.mySpriteRenderer.flipX == true)
        {
           moveHorizontal = 0f;
           StartCoroutine(waitidlex1());
        } else if (this.mySpriteRenderer.flipX == false)
        {
           moveHorizontal = 0f;  
           StartCoroutine(waitidlex2());
        }
       }
    }

    IEnumerator waitidlex1()
    {
        yield return new WaitForSeconds(3f);
 
        this.mySpriteRenderer.flipX = false;
        px1 = transform.position.x;
        px1 = px1 + 0.058f;
        visao.transform.position = new Vector3(px1, visao.transform.position.y, visao.transform.position.z); 
        moveHorizontal = 3f;
    }

    IEnumerator waitidlex2()
    {
        yield return new WaitForSeconds(3f);
 
        this.mySpriteRenderer.flipX = true; 
        px2 = transform.position.x;
        px2 = px2 + -1.464f;
        visao.transform.position = new Vector3(px2, visao.transform.position.y, visao.transform.position.z);
        moveHorizontal = -3f;
    } */
}
