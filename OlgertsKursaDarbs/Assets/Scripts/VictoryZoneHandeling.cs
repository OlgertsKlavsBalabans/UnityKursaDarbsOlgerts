using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Via.olgerts.kursadarbs
{
    public class VictoryZoneHandeling : MonoBehaviour
    {
        [SerializeField] GameObject victoryPopup;

        private void OnTriggerEnter(Collider other)
        {
            victoryPopup.active = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
    }
}