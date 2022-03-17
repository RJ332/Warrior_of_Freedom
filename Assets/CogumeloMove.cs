using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogumeloMove : MonoBehaviour
{
  private Vector3 direction;
  //public GameObject player;

    private Rigidbody2D Cogumelo;
    public Collider2D coll;
    public Animator animator;
    private SpriteRenderer mySpriteRenderer;
    public Collider2D collvisao;
    private float fEnemyX;
    public float speed = 2f;
    private int vida = 3;
    public int vdead = 0;

    // Start is called before the first frame update
    void Start()
    {
      mySpriteRenderer = GetComponent<SpriteRenderer>(); 
      Cogumelo = GetComponent<Rigidbody2D> (); 
    }

    // Use this for initialization
    void Update () 
    {
       if(direction.x < 0) {
           this.mySpriteRenderer.flipX = true; 
           collvisao.offset = new Vector2 (-0.26f , 0f);
            /* px2 = transform.position.x;
            px2 = px2 + -1.464f;
            visao.transform.position = new Vector3(px2, visao.transform.position.y, visao.transform.position.z); */
       } else if(direction.x > 0) {
           this.mySpriteRenderer.flipX = false;
           collvisao.offset = new Vector2 (0.26f , 0f);
            /* px1 = transform.position.x;
            px1 = px1 + 0.058f;
            visao.transform.position = new Vector3(px1, visao.transform.position.y, visao.transform.position.z); */
       }      
    }

    void FixedUpdate()
    {
      //DoBasicMovement();
      GameObject Player = GameObject.Find("WarriorPlayer");
      MoveCharacter player = Player.GetComponent<MoveCharacter>();
      direction = player.transform.position - transform.position;
      direction.Normalize();
      animator.SetFloat("speed", Mathf.Abs(speed));
      Cogumelo.transform.position += direction * Time.deltaTime * speed;  
    }

    /* void DoBasicMovement ()
    {
    fEnemyX = this.transform.position.x;

      switch( Direction )
        {
    case -1:
        // Moving Left
        if( fEnemyX > fMinX )
        {
            fEnemyX = -2f;
            this.mySpriteRenderer.flipX = true;
            collvisao.offset = new Vector2 (-0.26f , 0f);
            this.transform.Translate(fEnemyX * Time.deltaTime * speed, 0,0);
            animator.SetFloat("speed", Mathf.Abs(speed));
        }
        else
        {
            // Hit left boundary, change direction
            Direction = 1;
        }
        break;
     
    case 1:
        // Moving Right
        if( fEnemyX < fMaxX )
        {
          
            fEnemyX = 2f;
            this.mySpriteRenderer.flipX = false;
            collvisao.offset = new Vector2 (0.26f , 0f);
            this.transform.Translate(fEnemyX * Time.deltaTime * speed, 0,0);
            animator.SetFloat("speed", Mathf.Abs(speed));  
        }
        else
        {
            // Hit right boundary, change direction
            Direction = -1;
        }
        break;
    }         
    } */

    void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.CompareTag("playerattack"))
    {
      // collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 3f), ForceMode2D.Impulse);      
      // collision.GetComponent<Animator>().SetBool("hit", true);
        
        animator.SetBool("hit", true);    
    }  
    }

    void OnTriggerExit2D(Collider2D collision)
    {
    if (collision.CompareTag("playerattack"))
    {
      // collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 3f), ForceMode2D.Impulse);      
      // collision.GetComponent<Animator>().SetBool("hit", true);
      
      if (vida <= 0) {
        speed = 0f;
        vdead = 1;
        StartCoroutine(KillEnemy());
      } else if(vida > 0) {
        speed = 0f;
        StartCoroutine(HitEnemy());
        vida = vida - 1; 
      }  
    } 
    }

    IEnumerator HitEnemy()
    {
      yield return new WaitForSeconds(0.5f);    
      animator.SetBool("hit", false);
      speed = 2f;
    }

    IEnumerator KillEnemy()
    {
      yield return new WaitForSeconds(0.5f); 
      speed = 0f; 
      vdead = 1;
      animator.SetBool("dead", true);
      collvisao.enabled = false;
      coll.enabled = false;
      Cogumelo.GetComponent<Rigidbody2D>().isKinematic = true;
      //coll.isTrigger = true;
      yield return new WaitForSeconds(5f);
      Destroy(this.gameObject);
    }
}
