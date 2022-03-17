using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleaar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       var nearbyColliders = Physics.OverlapSphere(transform.position, 12.0f);
            foreach (var c in nearbyColliders)
            {
                if((c.CompareTag("enemy")))
                {

                }
                else {
                    Debug.Log("1ºround clear!!!");
                }
        } 
    }
}
