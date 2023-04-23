using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.IO;

public class StageHandler : MonoBehaviour
{
    public UI handler;
    public int achMedal;
    public int Level;
    public float hs;
    public float[] reqTimes = new float[3];

    public float t;
    // Start is called before the first frame update
    void Start()
    {
        Level = SceneManager.GetActiveScene().buildIndex;
        t = 0f;
        hs = PlayerPrefs.GetFloat((Level + "HS"), 0f);
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        handler.Win(t, hs);
        if(hs == 0f | t < hs)
            PlayerPrefs.SetFloat(Level + "HS", t);
            hs = t;

        if(hs < reqTimes[0])
            achMedal = 3;
        else if(hs < reqTimes[1])
            achMedal = 2;
        else if(hs < reqTimes[2])
            achMedal = 1;
        else
            achMedal = 0;
        
        PlayerPrefs.SetFloat(Level + "Medal", achMedal);

        handler.Medals(achMedal);
    }
}
