using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailStateChecker : MonoBehaviour
{

    GameObject noiseBar;
    // Start is called before the first frame update
    void Start()
    {
        noiseBar = GameObject.FindGameObjectWithTag("NoiseBar");
    }

    // Update is called once per frame
    void Update()
    {
        if( noiseBar.GetComponent<NoiseLevelController>().noiseLevel >= 10)
        {
            Debug.Log("LOOSE");
        }
    }
}
