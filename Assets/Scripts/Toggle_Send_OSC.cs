using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle_Send_OSC : MonoBehaviour
{
    public GameObject InputIp, InputPortA, InputPortB, DebugText, SendOSC;
    Toggle toggle;

    void Start(){
        toggle = GetComponent<Toggle>();
    }
    
    public void CheckIfCanSend(){
        SendOSC.GetComponent<SendOSC>().ToggleSendOSC(toggle.isOn);
        // bool canSend = toggle.isOn;
        // if (canSend){
            // string ip = InputIp.GetComponent<InputField>().text;
            // int portA, portB;
            // int.TryParse(InputPortA.GetComponent<InputField>().text, out portA);
            // int.TryParse(InputPortB.GetComponent<InputField>().text, out portB);
            // SendOSC.GetComponent<SendOSC>().ChangeIP(ip);
            // SendOSC.GetComponent<SendOSC>().ChangePortA(portA);
            // SendOSC.GetComponent<SendOSC>().ChangePortB(portB);
            // SendOSC.GetComponent<SendOSC>().UpdateOSCStatus();
            // DebugText.GetComponent<DebugText>().UpdateDebugText(ip, portA, portB);
            // Debug.Log("started sending");
        }
        // else SendOSC.GetComponent<SendOSC>().StopSendingOSC();
    // }
}
