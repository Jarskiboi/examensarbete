using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI FPSText;
    public TextMeshProUGUI speedText;
    public Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FPSText.text = Mathf.Round(1f / Time.unscaledDeltaTime) + "";
        speedText.text = Mathf.Round(playerRb.velocity.magnitude * 3)+ "";
    }
}
