using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseScreenEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public void goToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        Debug.Log(Time.timeScale);
    }
}
