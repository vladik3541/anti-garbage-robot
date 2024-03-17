using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRobotMoving : MonoBehaviour
{
    //speed
    [SerializeField] private float speed;
    //rotation
    [SerializeField] private float smoothTime = 1.0f;
    private float currentVelocity;

    private CharacterController characterController;
    private Main inputActions;
    private Vector2 move;

    public Animator animator;
    //gravity
    private float gravity = -9.81f;
    [SerializeField] private float gravityMultiplay = 3f;
    private float velocity;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        inputActions = new Main();
    }
    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Move.performed += Moving;
        inputActions.Player.MoveGamePad.performed += MovingJoystick;
        inputActions.Player.Move.canceled += MovingStop;
        inputActions.Player.MoveGamePad.canceled += MovingStop;

    }
    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.Player.Move.performed -= Moving;
        inputActions.Player.MoveGamePad.performed -= MovingJoystick;
        inputActions.Player.Move.canceled -= MovingStop;
        inputActions.Player.MoveGamePad.canceled -= MovingStop;

    }
    private void MovingJoystick(InputAction.CallbackContext value)
    {
        move = value.ReadValue<Vector2>().normalized;
    }
    private void Moving(InputAction.CallbackContext value)
    {
        move = value.ReadValue<Vector2>().normalized;
    }
    private void MovingStop(InputAction.CallbackContext value)
    {
        move = Vector2.zero;
    }

    private void Update()
    {
        ApplyGravity();

        ApplyMoving();
        ApplyRotation();

    }
    private void ApplyRotation()
    {
        if (move.sqrMagnitude == 0) return;
        float targetAngel = Mathf.Atan2(move.x, move.y) * Mathf.Rad2Deg;
        float angel = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngel, ref currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0, angel, 0);
    }
    private void ApplyMoving()
    {
        Vector3 directionMove = new Vector3(move.x * speed, velocity, move.y * speed);
        characterController.Move(directionMove * Time.deltaTime);
        if (move.sqrMagnitude == 0)
        {
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Run", true);
        }
    }
    private void ApplyGravity()
    {
        if (characterController.isGrounded && velocity < 0)
        {
            velocity = -1;
        }
        else
        {
            velocity += gravity * gravityMultiplay * Time.deltaTime;
        }


    }
    
}
