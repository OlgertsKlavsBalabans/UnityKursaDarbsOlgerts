using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Via.olgerts.kursadarbs
{
    public class FirstPersonController : MonoBehaviour
    {
        [SerializeField] float movementSpeed = 10f;

        [SerializeField] float roatationSpeed = 5f;

        [SerializeField] float jumpHeight = 5f;

        private Vector3 motion = Vector3.zero;
        CharacterController _characterController;
        Camera _camera;
        Vector3 _velocity;

        float pitch;
        float jaw;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _camera = GetComponentInChildren<Camera>();

            pitch = transform.localEulerAngles.x;

            jaw = transform.localEulerAngles.y;

            Cursor.visible = false;

            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {       
            addMotionWalk();
            addMotionJump();
            addMotionGravity();
            applyMotion();           
            changeLocalRotation();
        }

       
        private void applyMotion ()
        {
            _characterController.Move(motion * Time.deltaTime);
        }
        private void addMotionWalk()
        {
            float hWalk = Input.GetAxis("Horizontal");
            float vWalk = Input.GetAxis("Vertical");
            Vector3 input = new Vector3(hWalk, 0, vWalk);

            Vector3 localInput = transform.rotation * input * movementSpeed;

            motion.x = localInput.x;
            motion.z = localInput.z;

        }
        private void addMotionJump()
        {
            float jump = Input.GetAxis("Jump");

            if (_characterController.collisionFlags == CollisionFlags.Below)
            {
                motion.y = jump*jumpHeight;
            }

        }
        private void addMotionGravity()
        {
            motion += Physics.gravity * Time.deltaTime;
        }


        private void changeLocalRotation()
        {
            float hMouse = Input.GetAxis("Mouse X");
            float vMouse = Input.GetAxis("Mouse Y");
            pitch -= vMouse * Time.deltaTime * roatationSpeed;
            jaw += hMouse * Time.deltaTime * roatationSpeed;
            transform.localRotation = Quaternion.Euler(0, jaw, 0);
        }

        private void LateUpdate()
        {
            _camera.transform.localRotation = Quaternion.Euler(pitch, 0, 0);
        }



    }
}

