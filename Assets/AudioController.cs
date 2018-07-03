using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class AudioController : MonoBehaviour
{
    public GameObject player;
    public float maxDistance;

    [Range(0.0f, 1.0f)]
    public float dopplerStrength;

    [Range(0.0f, 1.0f)]
    public float panStrength;

    private AudioSource audioSource;
    
    private Vector3 lastPlayerPosition;
    private Vector3 lastPosition;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lastPlayerPosition = player.transform.position;
        lastPosition = transform.position;
    }

    public void Update()
    {
        SetPan();
        SetDoppler();
        SetVolume();

        ResetPositions();
    }

    private void SetPan()
    {
        double radian = Vector3.SignedAngle(
            player.transform.position - transform.position,
            player.transform.forward,
            Vector3.up
        ) * Math.PI / 180;

        audioSource.panStereo = (float)Math.Sin(radian) * panStrength;
    }

    private void SetDoppler()
    {
        float currentMagnitude = (player.transform.position - transform.position).magnitude;
        float lastMagnitude = (lastPlayerPosition - lastPosition).magnitude;

        float diff = (lastMagnitude - currentMagnitude) * Time.deltaTime;

        audioSource.pitch = 1 + (diff * 100 * dopplerStrength);
    }

    private void SetVolume()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance > maxDistance)
        {
            audioSource.volume = 0;
        }
        else
        {
            audioSource.volume = (maxDistance - distance) / maxDistance;
        }
    }

    private void ResetPositions()
    {
        lastPlayerPosition = player.transform.position;
        lastPosition = transform.position;
    }
}