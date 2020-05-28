using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseFromObjects : MonoBehaviour
{
    GameObject noiseBar;
    [SerializeField] int noiseMultiplier = 2;
    float createdNoise;
    private void Start()
    {
        noiseBar = GameObject.FindGameObjectWithTag("NoiseBar");
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        createdNoise = collision.relativeVelocity.magnitude;
        if (createdNoise > 1)
        {
            
            noiseBar.GetComponent<NoiseLevelController>().noiseLevel += createdNoise*noiseMultiplier;
        }
        
    }
}
