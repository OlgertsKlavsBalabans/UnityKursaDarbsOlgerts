using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Via.olgerts.kursadarbs
{
    public class VictoryScreenEvents : MonoBehaviour
    {
        public void goToMainMenu ()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
        }
    }
}
