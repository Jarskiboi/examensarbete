using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI FPSText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI timerText;
    public Rigidbody playerRb;
    public StageHandler handler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float t = handler.t;
        int min = (int)((t - t % 60)/60);
        string Min;
        if (min < 10)
            Min = "0" + (t - t % 60)/60;
        else
            Min = "" + (t - t % 60)/60;

        float sec = t % 60;
        string Sec;

        if (sec < 10f)
            Sec = "0" + (t % 60).ToString("F2");
        else    
            Sec = (t % 60).ToString("F2");

        timerText.text = Min + ":" + Sec;
        FPSText.text = Mathf.Round(1f / Time.unscaledDeltaTime) + "";
        speedText.text = Mathf.Round(playerRb.velocity.magnitude * 3)+ "";
    }
}
