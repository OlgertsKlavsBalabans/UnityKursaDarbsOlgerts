using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorDetector : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isColissionWithDoor = false;
    private Animator anim;
    void Start()
    {
  
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Door")
        {
            anim = other.GetComponent<Animator>();
            Debug.Log("COLLISION");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Door")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.Play("TriggerAnim");

                bool animatorBool = anim.GetBool("DoorClosed");
                
                anim.SetBool("DoorClosed", !animatorBool);
            }
        }
    }


}
