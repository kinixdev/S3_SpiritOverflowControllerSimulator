using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour
{
    private Text TextComponent; 

    
    void Start()
    {
        TextComponent = GetComponent<UnityEngine.UI.Text>();
        // UpdateDebugText("\n\nTo start sending OSC\nturn toggle on");
    }

    public void UpdateDebugText(string ip, int portA, int portB){
        // TextComponent.text = "Sending to ip\n" + ip + "\nPort A:\t" + portA + "\nPortB:\t" + portB;
        // TextComponent.color = Color.green;
    }

    public void UpdateDebugText(string errorMessage){
        // TextComponent.text = errorMessage;
        // TextComponent.color = Color.red;
    }


    // public void UpdateIP(string _ip){
    //     ip = _ip;
    //     UpdateDebugText();
    // }

    // public void UpdatePortA(string _portA){
    //     portA = _portA;
    //     UpdateDebugText();
    // }

    // public void UpdatePortB(string _portB){
    //     portB = _portB;
    //     UpdateDebugText();
    // }
}
