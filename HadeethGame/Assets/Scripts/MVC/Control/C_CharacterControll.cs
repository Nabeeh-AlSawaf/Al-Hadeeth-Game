using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CharacterControll : MonoBehaviour
{
    public CharacterController controller;
    public Joystick joystick;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;

    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Animator animator;

    private float turnSmoothVelocity;

    private Vector3 playerDirection;
    private Quaternion newAngle;
    private Vector3 velocity;
    private bool isGrounded;
    // Update is called once per frame

    private void ReadInput()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        animator.SetFloat("Blend",(Mathf.Abs( horizontal) + Mathf.Abs(vertical))/2f);
        playerDirection = new Vector3(horizontal, 0f, vertical);
    }

    private void CalculateMovementPosition()
    {
        if (playerDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(playerDirection.x, playerDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            newAngle = Quaternion.Euler(0f, angle, 0f);


            //controller.Move(playerDirection * speed * Time.deltaTime);
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

    }

    private void CalculateGravity()
    {
        velocity.y += gravity * Time.deltaTime;
    }

    private void ApplyGravity()
    {
        controller.Move(velocity * Time.deltaTime);
    }

    private void ResetVelocity()
    {
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    private void Move()
    {
            transform.rotation = newAngle;
            controller.Move(playerDirection * speed * Time.deltaTime);
    }



    void Update()
    {
        ReadInput();
        CalculateMovementPosition();
    }

    private void FixedUpdate()
    {
        Move();
        CalculateGravity();
        ApplyGravity();
        ResetVelocity();
    }
}
