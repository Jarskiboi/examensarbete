using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI FPSText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI winTimeText;
    public TextMeshProUGUI winHsText;
    public Rigidbody playerRb;
    public StageHandler handler;
    public GameObject WinScreen;
    public GameObject[] medals;

    // Start is called before the first frame update
    void Start()
    {
        WinScreen.SetActive(false);
    }

    public string TimeCalc(float t){
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

        return Min + ":" + Sec;
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = TimeCalc(handler.t);
        FPSText.text = Mathf.Round(1f / Time.unscaledDeltaTime) + "";
        speedText.text = Mathf.Round(playerRb.velocity.magnitude * 3)+ "";
    }

    public void Win(float t, float hs){
        speedText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        WinScreen.SetActive(true);
        winTimeText.text = TimeCalc(t);
        winHsText.text = TimeCalc(hs);
        Time.timeScale = 0.3f;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

    public void Medals(int achMedal)
    {
        if(achMedal == 3)
        {
            medals[0].SetActive(true); 
            medals[1].SetActive(true); 
            medals[2].SetActive(true);
        }   
        else if(achMedal == 2)
        {
            medals[1].SetActive(true); 
            medals[2].SetActive(true);
        }
        else if(achMedal == 1)
        {
            medals[2].SetActive(true);
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
