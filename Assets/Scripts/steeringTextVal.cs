using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class steeringTextVal : MonoBehaviour
{
    public Slider SteeringSlider;

    void Start(){
        
    }

    void Update(){
        float steering = SteeringSlider.value;
        if (steering > 360) steering = steering - 359;
        GetComponent<Text>().text = steering.ToString("#.#");
    }
}
