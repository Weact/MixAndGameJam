using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 20f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 _velocity;
    private bool _isGrounded;
    private Stun_size S_S;

    void Start()
    {
        S_S = GameObject.Find("EntityUnit").GetComponent<Stun_size>();
    }

    // Update is called once per frame
    void Update()
    {
        if (S_S.stun == false)
        {
            _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * (speed * Time.deltaTime));

            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            _velocity.y += gravity * Time.deltaTime;
            controller.Move(_velocity * Time.deltaTime);
        }
    }
}
