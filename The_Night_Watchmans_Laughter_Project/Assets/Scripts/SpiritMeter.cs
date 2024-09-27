using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiritMeter : MonoBehaviour
{
    public Slider spiritMeterUI;
    public Spirit playerSpirit;
        
    // Start is called before the first frame update
    void Start()
    {

        playerSpirit = GameObject.FindGameObjectWithTag("Player").GetComponent<Spirit>(); 
        spiritMeterUI = GetComponent<Slider>();
        spiritMeterUI.maxValue = playerSpirit.maxSpirt;
        spiritMeterUI.value = playerSpirit.maxSpirt; 
    }

   
    public void SetSpirit(int SP)
    {
        spiritMeterUI.value = SP; 
    }   
}
