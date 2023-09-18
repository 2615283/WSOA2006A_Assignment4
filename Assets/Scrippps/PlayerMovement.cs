using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    InputManager inputManager;

    private Vector3 direction;
    private Transform camObject;
    private Vector3 velocity;
    private Vector3 directionTarget;
    private Quaternion rotationTarget;
    private Quaternion rotationPlayer;

    public bool isSneaking;

    public float sneakingSpeed = 1.5f;
    public float speed = 7;
    public float speedRotation = 15;

    Rigidbody rigidbodyPlayer;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        rigidbodyPlayer = GetComponent<Rigidbody>();

        camObject = Camera.main.transform;
    }

    public void AllMovementHandler()
    {
        MovementHandler();
        RotationHandler();
    }

    private void MovementHandler()
    {
        direction = camObject.forward * inputManager.inputVertical;
        direction += camObject.right * inputManager.inputHorizontal;
        direction.Normalize();
        direction.y = 0;

        if (isSneaking)
        {
            direction = direction * sneakingSpeed;
        }
        else
        {
            direction = direction * speed;
        }        

        velocity = direction;
        rigidbodyPlayer.velocity = velocity;
    }

    private void RotationHandler()
    {
        directionTarget = Vector3.zero;

        directionTarget = camObject.forward * inputManager.inputVertical;
        directionTarget += directionTarget + camObject.right * inputManager.inputHorizontal;
        directionTarget.Normalize();
        directionTarget.y = 0;

        if (directionTarget == Vector3.zero)
        {
            directionTarget = transform.forward;
        }

        rotationTarget = Quaternion.LookRotation(directionTarget);
        rotationPlayer = Quaternion.Slerp(transform.rotation, rotationTarget, speedRotation * Time.deltaTime);

        transform.rotation = rotationPlayer;
    }
}
