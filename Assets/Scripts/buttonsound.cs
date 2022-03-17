using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonsound : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip houverFx;
    public AudioClip clickFx;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HoverSound()
    {
        myFx.PlayOneShot(houverFx);
    }

    public void ClickSound()
    {
        myFx.PlayOneShot(clickFx);
    }
}
