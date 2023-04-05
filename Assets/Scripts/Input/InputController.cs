//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/InputController.inputactions
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

public partial class @InputController : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputController"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""63c4e2dd-28f8-48c6-be7a-ab3a8935fa42"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""59dcac1d-9869-49e4-9ad3-5652c750e1c2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Slowdown1"",
                    ""type"": ""Value"",
                    ""id"": ""934172b7-43d7-42a2-8f0f-8ceb2ce67124"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Slowdown2"",
                    ""type"": ""Value"",
                    ""id"": ""68ceacf5-76a1-4070-87cc-1c216490d63f"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""StartButton"",
                    ""type"": ""Button"",
                    ""id"": ""b38d2b70-eb82-49dc-843f-833b0d4e9204"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""77a7fae1-a8bc-4259-8d5a-fd69d548f8f7"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36cec8f9-4332-4e7e-b424-7945082138ce"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3fa76cfe-f38d-4412-8b7b-1e09aae4b9bb"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slowdown1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""420bfb65-8546-4b5b-b4e3-abe0585a7631"",
                    ""path"": ""<HID::Logitech Logitech RumblePad 2 USB>/button7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slowdown1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""333926e7-19b3-47e1-9031-3f62453cd053"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slowdown2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b1cd771-7ea3-4735-ae61-023de79fb3ac"",
                    ""path"": ""<HID::Logitech Logitech RumblePad 2 USB>/button8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slowdown2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""446cc21e-3684-4e15-b969-9ebdd8e832ba"",
                    ""path"": ""<HID::Logitech Logitech RumblePad 2 USB>/button10"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""864c90ce-fcb4-4851-becc-00bb7912b01f"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Slowdown1 = m_Player.FindAction("Slowdown1", throwIfNotFound: true);
        m_Player_Slowdown2 = m_Player.FindAction("Slowdown2", throwIfNotFound: true);
        m_Player_StartButton = m_Player.FindAction("StartButton", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Slowdown1;
    private readonly InputAction m_Player_Slowdown2;
    private readonly InputAction m_Player_StartButton;
    public struct PlayerActions
    {
        private @InputController m_Wrapper;
        public PlayerActions(@InputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Slowdown1 => m_Wrapper.m_Player_Slowdown1;
        public InputAction @Slowdown2 => m_Wrapper.m_Player_Slowdown2;
        public InputAction @StartButton => m_Wrapper.m_Player_StartButton;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Slowdown1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlowdown1;
                @Slowdown1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlowdown1;
                @Slowdown1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlowdown1;
                @Slowdown2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlowdown2;
                @Slowdown2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlowdown2;
                @Slowdown2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlowdown2;
                @StartButton.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartButton;
                @StartButton.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartButton;
                @StartButton.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartButton;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Slowdown1.started += instance.OnSlowdown1;
                @Slowdown1.performed += instance.OnSlowdown1;
                @Slowdown1.canceled += instance.OnSlowdown1;
                @Slowdown2.started += instance.OnSlowdown2;
                @Slowdown2.performed += instance.OnSlowdown2;
                @Slowdown2.canceled += instance.OnSlowdown2;
                @StartButton.started += instance.OnStartButton;
                @StartButton.performed += instance.OnStartButton;
                @StartButton.canceled += instance.OnStartButton;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnSlowdown1(InputAction.CallbackContext context);
        void OnSlowdown2(InputAction.CallbackContext context);
        void OnStartButton(InputAction.CallbackContext context);
    }
}
