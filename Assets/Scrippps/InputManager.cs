using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    ControlsPlayer controlsPlayer;
    PlayerMovement playerMovement;
    AnimatorManager animatorManager;

    public Vector2 moveInput;
    public Vector2 camInput;

    public float XCamInput;
    public float YCamInput;

    public float amountMove;
    public float inputVertical;
    public float inputHorizontal;

    public bool shift_input;
    public bool tab_input;

    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        if (controlsPlayer == null)
        {
            controlsPlayer = new ControlsPlayer();

            controlsPlayer.Movement_Player.Move.performed += j => moveInput = j.ReadValue<Vector2>();
            controlsPlayer.Movement_Player.Cam.performed += i => camInput = i.ReadValue<Vector2>();

            controlsPlayer.Player_Actions.Shift.performed += k => shift_input = true;
            controlsPlayer.Player_Actions.Shift.canceled += k => shift_input = false;

            controlsPlayer.Player_Actions.Tab.performed += k => tab_input = true;
            controlsPlayer.Player_Actions.Tab.canceled += k => tab_input = false;
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
        SneakingHandler();
        SprintingHandler();
    }

    private void MovementHandlerInput()
    {
        inputVertical = moveInput.y;
        inputHorizontal = moveInput.x;

        YCamInput = camInput.y;
        XCamInput = camInput.x;

        amountMove = Mathf.Clamp01(Mathf.Abs(inputHorizontal) + Mathf.Abs(inputVertical));

        animatorManager.UpdateAnimationValues(0, amountMove, playerMovement.isSneaking, playerMovement.isSprinting);
    }

    private void SneakingHandler()
    {
        if (shift_input)
        {
            playerMovement.isSneaking = true;
        }
        else
        {
            playerMovement.isSneaking = false;
        }
    }

    private void SprintingHandler()
    {
        if (tab_input)
        {
            playerMovement.isSprinting = true;
        }
        else
        {
            playerMovement.isSprinting = false;
        }
    }
}
