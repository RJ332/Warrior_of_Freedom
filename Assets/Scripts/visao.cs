using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visao : MonoBehaviour
{
     private GameObject Witcht;
     private MoveWitch Witch;
    // Start is called before the first frame update
    void Start()
    {
        Witcht = GameObject.Find("Witch");
        Witch = Witcht.GetComponent<MoveWitch>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D  collision)
    {
         if((collision.gameObject.tag == "Player") && (Witch.animator.GetBool("charge") == true) && (Witch.animator.GetBool("hit") == true)) {
            Witch.animator.SetBool("attack", false);
            Witch.speed = 0f;
       } else if((collision.gameObject.tag == "Player") && (Witch.animator.GetBool("charge") == false) && (Witch.animator.GetBool("hit") == false)) {
            Witch.animator.SetBool("attack", true);
            Witch.speed = 0f;
            StartCoroutine(waitattack());
       }
       
    }

    /* void OnTriggerExit2D(Collider2D  collision)
    {
       if(collision.gameObject.tag == "Player") {
            Witch.animator.SetBool("attack", false);
            Witch.attack = 1;
            Witch.animator.SetBool("charge", true);
       } 
    } */

    IEnumerator waitattack()
    {
         if(Witch.mySpriteRenderer.flipX == false) {
          Witch.Colliderattack.offset = new Vector2(0.43f, 0.51f);    
          yield return new WaitForSeconds(0.1f);
          Witch.bodyCollider.offset = new Vector2(-0.32f, 0.75f);
          yield return new WaitForSeconds(0.1f);
          Witch.bodyCollider.offset = new Vector2(-0.64f, 0.7633333f);
          yield return new WaitForSeconds(0.1f);
          Witch.bodyCollider.offset = new Vector2(-0.95f, 0.77f);
          yield return new WaitForSeconds(0.1f);
          Witch.bodyCollider.offset = new Vector2(-0.97f, 0.79f);  
         }
       
          if(Witch.mySpriteRenderer.flipX == true) {
          Witch.Colliderattack.offset = new Vector2(-0.43f, 0.51f);   
          yield return new WaitForSeconds(0.1f);
          Witch.bodyCollider.offset = new Vector2(0.32f, 0.75f);
          yield return new WaitForSeconds(0.1f);
          Witch.bodyCollider.offset = new Vector2(0.64f, 0.7633333f);
          yield return new WaitForSeconds(0.1f);
          Witch.bodyCollider.offset = new Vector2(0.95f, 0.77f);
          yield return new WaitForSeconds(0.1f);
          Witch.bodyCollider.offset = new Vector2(0.97f, 0.79f);  
         }

         yield return new WaitForSeconds(0.1f);
         Witch.bodyCollider.offset = new Vector2(0f, 0.6333333f);

         Witch.animator.SetBool("attack", false);
         Witch.attack = 1;
         Witch.animator.SetBool("charge", true);
         yield return new WaitForSeconds(0.5f);
         Witch.animator.SetBool("charge", false);
         Witch.speed = 3f; 
    }
}
