﻿using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : Bolt.EntityBehaviour<ICustomCubeState>
{
    public Animator playerAnimator;
    public Vector2 inputVector = new Vector2(0, 0);
    public CharacterController controller;
    public Transform cam;
    public float defaultSpeed = 6;
    public float sprintSpeed = 12;
    public float turnSmootTime = 0.1f;
    public float currSpeed;
    private bool isSprinting;
    float turnSmoothVelocity;

    public void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }

    public void OnSprint(InputValue value)
    {
        if (value.Get<float>() == 1)
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }

    //Similar to Start()
    public override void Attached()
    {
        state.SetTransforms(state.CubeTransform, transform);
        state.SetAnimator(playerAnimator);
    }

    //Similar to Update()
    public override void SimulateOwner()
    {
        float horizontal = inputVector.x;
        float vertical = inputVector.y;

        if (isSprinting)
        {
            this.currSpeed = this.sprintSpeed;
        }
        else
        {
            this.currSpeed = defaultSpeed;
        }

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmootTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * currSpeed * Time.deltaTime);
        }

    }
}
