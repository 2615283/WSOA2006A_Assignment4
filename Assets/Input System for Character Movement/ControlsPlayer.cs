//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Input System for Character Movement/ControlsPlayer.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @ControlsPlayer: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ControlsPlayer()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ControlsPlayer"",
    ""maps"": [
        {
            ""name"": ""Movement_Player"",
            ""id"": ""d4d0c9b8-012d-4f09-bf16-e06a5ad7b240"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e34e4ff0-b10e-4de5-b726-0896c181c89f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cam"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bd1844ab-cd6f-4159-b2a3-c0731d7e4f6d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""8053a1ea-2319-4fbf-bc7e-eddbf8606eca"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fa2f3c7a-82fc-4fb7-99b4-3616b0280460"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""16d37feb-cfad-4c3d-93ef-ea4787082579"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""86c09c6b-dd27-4d32-8b4c-278a3dfe5aaf"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6aeb838e-c601-4ae4-b001-2bdb2d906ad2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4eb5ca5e-9153-488f-b3fe-a73108e3de4a"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement_Player
        m_Movement_Player = asset.FindActionMap("Movement_Player", throwIfNotFound: true);
        m_Movement_Player_Move = m_Movement_Player.FindAction("Move", throwIfNotFound: true);
        m_Movement_Player_Cam = m_Movement_Player.FindAction("Cam", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Movement_Player
    private readonly InputActionMap m_Movement_Player;
    private List<IMovement_PlayerActions> m_Movement_PlayerActionsCallbackInterfaces = new List<IMovement_PlayerActions>();
    private readonly InputAction m_Movement_Player_Move;
    private readonly InputAction m_Movement_Player_Cam;
    public struct Movement_PlayerActions
    {
        private @ControlsPlayer m_Wrapper;
        public Movement_PlayerActions(@ControlsPlayer wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Movement_Player_Move;
        public InputAction @Cam => m_Wrapper.m_Movement_Player_Cam;
        public InputActionMap Get() { return m_Wrapper.m_Movement_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Movement_PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IMovement_PlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_Movement_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_Movement_PlayerActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Cam.started += instance.OnCam;
            @Cam.performed += instance.OnCam;
            @Cam.canceled += instance.OnCam;
        }

        private void UnregisterCallbacks(IMovement_PlayerActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Cam.started -= instance.OnCam;
            @Cam.performed -= instance.OnCam;
            @Cam.canceled -= instance.OnCam;
        }

        public void RemoveCallbacks(IMovement_PlayerActions instance)
        {
            if (m_Wrapper.m_Movement_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMovement_PlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_Movement_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_Movement_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public Movement_PlayerActions @Movement_Player => new Movement_PlayerActions(this);
    public interface IMovement_PlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnCam(InputAction.CallbackContext context);
    }
}
