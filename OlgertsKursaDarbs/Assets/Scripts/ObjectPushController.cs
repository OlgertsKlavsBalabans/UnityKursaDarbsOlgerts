using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPushController : MonoBehaviour
{
    [SerializeField] float pushPower = 2f;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody hitBody = hit.collider.attachedRigidbody;
        Vector3 pushVector = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        if (hitBody == null || hitBody.isKinematic)
        {
            return;
        }

        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        //After all checks apply the force

        hitBody.velocity = pushVector * pushPower;

    }
}
