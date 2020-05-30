using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorDetector : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private bool animationPlaying = false;

    private AudioSource doorCreak;
    void Start()
    {
        doorCreak = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Door")
        {
            anim = other.GetComponentInParent<Animator>();
            Debug.Log("COLLISION");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Door")
        {

            if ((Input.GetKeyDown(KeyCode.E))&&(animationPlaying == false))
            {
                anim.Play("TriggerAnim");
                doorCreak.PlayOneShot(doorCreak.clip);

                bool animatorBool = anim.GetBool("DoorClosed");
                anim.SetBool("DoorClosed", !animatorBool);

                float animLength = anim.GetCurrentAnimatorStateInfo(0).length;
                StartCoroutine( waitForAnimFinish(animLength));
            }
        }
    }

    private IEnumerator waitForAnimFinish(float animLength)
    {

        animationPlaying = true;
        yield return new WaitForSeconds(animLength);
        animationPlaying = false;

    }


}
