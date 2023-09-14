using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    ControlsPlayer controlsPlayer;

    public Vector2 moveInput;

    public float inputVertical;
    public float inputHorizontal;

    private void OnEnable()
    {
        if (controlsPlayer == null)
        {
            controlsPlayer = new ControlsPlayer();

            controlsPlayer.Movement_Player.Move.performed += j => moveInput = j.ReadValue<Vector2>();
        }

        controlsPlayer.Enable();
    }

    private void OnDisable()
    {
        controlsPlayer.Disable();
    }

    public void AllInputHandler()
    {
        MovementHandlerInput();
    }

    private void MovementHandlerInput()
    {
        inputVertical = moveInput.y;
        inputHorizontal = moveInput.x;
    }
}
