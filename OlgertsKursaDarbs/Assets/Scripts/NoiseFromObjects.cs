using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseFromObjects : MonoBehaviour
{
    GameObject noiseBar;
    [SerializeField] int noiseMultiplier = 2;
    private AudioSource breakSound;
    float createdNoise;
    private void Start()
    {
        noiseBar = GameObject.FindGameObjectWithTag("NoiseBar");
        breakSound = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        createdNoise = collision.relativeVelocity.magnitude;
        if (createdNoise > 1)
        {
            breakSound.volume = createdNoise * 0.1f;
            if (breakSound.isPlaying == false)
            {
                breakSound.PlayOneShot(breakSound.clip);
            }
            
            noiseBar.GetComponent<NoiseLevelController>().noiseLevel += createdNoise*noiseMultiplier;
        }
        
    }
}
