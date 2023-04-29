using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    private float currentSpeed;

    public bool grounded = true;

    private Rigidbody rb;
    private AudioSource carAudio;

    public float minPitch;
    public float maxPitch;
    private float pitchFromCar;

    void Start()
    {
        carAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        currentSpeed = rb.velocity.magnitude;
        pitchFromCar = rb.velocity.magnitude / 50f;

        if(currentSpeed < minSpeed)
            carAudio.pitch = minPitch;
        
        if(currentSpeed > minSpeed && currentSpeed < maxSpeed)
            carAudio.pitch = minPitch + pitchFromCar;

        if(currentSpeed > maxSpeed)
            carAudio.pitch = maxPitch;
    }

    public void Grounding(bool g)
    {

        if(g && !grounded)
        {
            carAudio.volume *= 3;
            grounded = true;
        }

        if(!g && grounded)
        {
            carAudio.volume /= 3;
            grounded = false;
        }
    }
}
