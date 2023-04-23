using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    public float countdownTime = 3f;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI timerText;
    public StageHandler handler;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        countdownText.gameObject.SetActive(true);
        speedText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        handler.gameObject.SetActive(false);
        player.enabled = false;
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        countdownText.text = "GO!";
        StartGame();
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);
    }

    void StartGame(){
        Debug.Log("Started");
        speedText.gameObject.SetActive(true);
        timerText.gameObject.SetActive(true);
        handler.gameObject.SetActive(true);
        player.enabled = true;
    }
}
