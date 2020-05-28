using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoiseLevelController : MonoBehaviour
{
    [SerializeField] float decaySpeed = 10f;
    [System.NonSerialized]public float noiseLevel = 0.01f;
    private float oldWidth;
    private float newWidth;
    private RectTransform rTransform;
    private Image img;

    private void Start()
    {
        rTransform = this.GetComponent<RectTransform>();
        img = this.GetComponent<Image>();
    }
    private void Update()
    {
        if (noiseLevel >0)
        {
           // Debug.Log(noiseLevel);
            noiseLevel = noiseLevel - (decaySpeed* Time.deltaTime);
            if (noiseLevel<0)
            {
                noiseLevel = 0;
            }
            if (noiseLevel > 10)
            {
                noiseLevel = 10;
            }
            oldWidth = rTransform.sizeDelta.x;

            //Set width of bar
            rTransform.sizeDelta = new Vector2(noiseLevel*10, rTransform.sizeDelta.y);
           
            newWidth = this.GetComponent<RectTransform>().sizeDelta.x;
            //Set new position of bar
            rTransform.transform.position = new Vector3(
                rTransform.transform.position.x + ((newWidth - oldWidth) /2),
                rTransform.transform.position.y,
                rTransform.transform.position.z
                );
            //Change colour of bar 
            img.color = Color.Lerp(Color.green, Color.red, (noiseLevel / 10));
            
            

        }
    }
}
