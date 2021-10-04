using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piket : MonoBehaviour
{
    private float piket = 0.0f;
    public Text timeText;

    public MenuFund menuFund;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var player = GetComponent<PlayerController>();
        if (player.TheEnd())
        {
            menuFund.displayMainMenu(piket);
            return;
        }
           
        piket += Time.deltaTime;
        timeText.text = "Time passed: " + ((int)piket).ToString();   
    }
}
