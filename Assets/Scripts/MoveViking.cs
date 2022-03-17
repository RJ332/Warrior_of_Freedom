using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveViking : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer mySpriteRenderer;
    public Animator animator;
    private float moveHorizontal = 3f;
    private float speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();      
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);
        animator.SetFloat("speed", Mathf.Abs(moveHorizontal));
        rb.transform.position += movement * Time.deltaTime * speed; 
    }

    void OnTriggerEnter2D(Collider2D  collision)
    {
       if(collision.gameObject.tag == "stop") {

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
        moveHorizontal = 3f;
    }

    IEnumerator waitidlex2()
    {
        yield return new WaitForSeconds(3f);
 
        this.mySpriteRenderer.flipX = true; 
        moveHorizontal = -3f;
    }
}
