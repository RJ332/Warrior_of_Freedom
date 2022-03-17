using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visao3 : MonoBehaviour
{
    public Animator animator;
    public GameObject esqueleto;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    { 
      //GameObject thePlayer3 = GameObject.Find("Esqueleto");
      EsqueletoMove playerScript3 = esqueleto.GetComponent<EsqueletoMove>();

    if (collision.CompareTag("Player") && (playerScript3.vdead == 0))
    { 
      //Esqueleto
      //GameObject thePlayer1 = GameObject.Find("Esqueleto");
      EsqueletoMove playerScript1 = esqueleto.GetComponent<EsqueletoMove>();
      playerScript1.speed = 0f;
      animator.SetBool("attack", true); 
    } else if(playerScript3.vdead == 1) {
      animator.SetBool("attack", false);
      animator.SetBool("dead", true);
    }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
      //GameObject thePlayer = GameObject.Find("Esqueleto");
      EsqueletoMove playerScript = esqueleto.GetComponent<EsqueletoMove>();

    if (collision.CompareTag("Player") && (playerScript.vdead == 0))
    {
      //Esqueleto
      //GameObject thePlayer2 = GameObject.Find("Esqueleto");
      EsqueletoMove playerScript2 = esqueleto.GetComponent<EsqueletoMove>();
      playerScript2.speed = 0.2f;
      animator.SetBool("attack", false); 
    }  
    }
}
