using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SendOSC : MonoBehaviour
{
    public GameObject InputIp, InputAge;
    public Slider SpeedSlider, BpmSlider, SteeringSlider, PowerSlider, ResistanceSlider;
    // [SerializeField] OscOut _oscOutA, _oscOutB;
    [SerializeField] OscOut oscOut_Game, oscOut_Resistance;

    const string addressStart = "/UI/pressStart";
    const string addressSteering = "/char/steering";
    const string addressCalibrateSteering = "/char/calibrateSteering";
    const string addressActivateBioUltimate =  "/char/activateBioUltimate";
    const string addressUseItem = "/char/useItem";
    const string addressSpeed = "/char/speed";
    const string addressBPM = "/char/bpm"; 
    const string addressChangeCamera = "/camera/change";
    const string addressPlayerAge = "/player/age";
    const string addressPower = "/char/power";
    const string addressResistance = "/wahoo/resistance";

    string ip = "127.0.0.1";
    int player = 1;
    int portPlayer1 = 9611;
    int portPlayer2 = 9621;
    int portResistance = 9001;

    public bool canSend = false;

    int bpm;
    float steering, speed, power;
    string resistance;


    void Start(){
        // Ensure that we have a OscOut component.
        if (!oscOut_Game) oscOut_Game = gameObject.AddComponent<OscOut>();
        if (!oscOut_Resistance) oscOut_Resistance = gameObject.AddComponent<OscOut>();

        StartCoroutine("SendSpeed");
        StartCoroutine("SendBPM");
        StartCoroutine("SendPower");
        StartCoroutine("SendResistance");
        SetSpeed();
        SetSteering();
        SetBpm();
        SetPower();
        SetResistance();
    }

    void Update(){
        if (canSend) oscOut_Game.Send(addressSteering, steering);
    }


    private IEnumerator SendSpeed(){
        yield return new WaitForSeconds(1.0f);
        if (canSend) oscOut_Game.Send(addressSpeed, speed);
        StartCoroutine("SendSpeed");
    }

    private IEnumerator SendBPM(){
        yield return new WaitForSeconds(1.0f);
        if (canSend) oscOut_Game.Send(addressBPM, bpm);
        StartCoroutine("SendBPM");
    }

    private IEnumerator SendPower(){
        yield return new WaitForSeconds(1.0f);
        if (canSend) oscOut_Game.Send(addressPower, power);
        StartCoroutine("SendPower");
    }

    private IEnumerator SendResistance(){
        yield return new WaitForSeconds(0.33f);
        if (canSend) oscOut_Resistance.Send(addressResistance, resistance);
        StartCoroutine("SendResistance");
    }

    public void SendStart(){
        if (canSend) oscOut_Game.Send(addressStart, 1);
    }

    public void SendCalibrateSteering(){
        if (canSend) oscOut_Game.Send(addressCalibrateSteering, 1);
    }

    public void SendActivateBioUltimate(){
        if (canSend) oscOut_Game.Send(addressActivateBioUltimate, 1);
    }

    public void SendUseItem(){
        if (canSend) oscOut_Game.Send(addressUseItem, 1);
    }

    public void SendChangeCamera(){
        if (canSend) oscOut_Game.Send(addressChangeCamera, 1);
    }

    public void SendAge(){
        int age = 0;
        int.TryParse(InputAge.GetComponent<InputField>().text, out age);
        if (canSend) oscOut_Game.Send(addressPlayerAge, age);
    }

    public void UpdateOSCStatus(){
        if (player == 1) oscOut_Game.Open (portPlayer1, ip);
        else if (player == 2) oscOut_Game.Open (portPlayer2, ip);
    }

    public void ChangeIP(){
        ip = InputIp.GetComponent<InputField>().text;
        UpdateOSCStatus();
    }

    public void ToggleSendOSC(bool b){
        canSend = b;
        if (b){
            UpdateOSCStatus();
            oscOut_Resistance.Open (portResistance, "127.0.0.1");
        } 
    }

    public void SetSpeed(){
        speed = SpeedSlider.value;
    }

    public void SetSteering(){
        if (steering > 360) steering = steering - 359;
        steering = SteeringSlider.value;
    }

    public void SetBpm(){
        bpm = (int)BpmSlider.value;
    }

    public void SetPower(){
        power = (int)PowerSlider.value;
    }

    public void SetResistance(){
        resistance = ResistanceSlider.value.ToString("0.##");
        Debug.Log(resistance.GetType());
        Debug.Log(resistance);
    }

    public void ChoosePlayer1(){
        player = 1;
        UpdateOSCStatus();
    }

    public void ChoosePlayer2(){
        player = 2;
        UpdateOSCStatus();
    }
    
}


