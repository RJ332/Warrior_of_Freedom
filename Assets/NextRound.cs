using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextRound : MonoBehaviour
{
    public GameObject[] enemys;
    public GameObject powerupUI;
    public Image roundNUI;
    public int round = 1;
    public Sprite[] roundUInumber;
    
    // Start is called before the first frame update
    void Start()
    {
        Sprite round1 = Resources.Load <Sprite>("Assets/Buttons/1Text");
        roundNUI.sprite = roundUInumber[0];
    }

    // Update is called once per frame
    void Update()
    {
       if((enemys[0] == null) && (enemys[1] == null) && (enemys[2] == null) && (enemys[3] == null) && (enemys[4] == null) && (enemys[5] == null) && (round == 1)){
           powerupUI.SetActive(true);
           Time.timeScale = 0f;
           round = round + 1;
           Sprite round2 = Resources.Load <Sprite>("Assets/Buttons/2Text"); 
           roundNUI.sprite = roundUInumber[1];
       }  
    }
}
