using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailStateChecker : MonoBehaviour
{
    [SerializeField] GameObject loosePopup;
    GameObject noiseBar;
    private bool playerLost = false;
    // Start is called before the first frame update
    void Start()
    {
        noiseBar = GameObject.FindGameObjectWithTag("NoiseBar");
    }

    // Update is called once per frame
    void Update()
    {
        if(( noiseBar.GetComponent<NoiseLevelController>().noiseLevel >= 10)&&(playerLost == false))
        {
            playerLost = true;

            loosePopup.active = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
    }
}
