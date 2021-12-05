// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PControls"",
            ""id"": ""8ae20d1f-fab5-43b7-81ca-0b4834578f6c"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""008c487b-528b-4e9f-802f-de4be043db45"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""d93c233a-2eee-4a67-9e36-3928c10386a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""b5126a41-90a3-4c16-b767-6c5495667dc2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""010be20d-b310-44d5-b0a1-185fa3a26b6a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FirePosition"",
                    ""type"": ""Value"",
                    ""id"": ""2983c95d-8cdb-4f8b-ae9e-9e60d936e5f2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FireDirection"",
                    ""type"": ""Button"",
                    ""id"": ""3a935407-e4ad-4091-aac8-af12f86725f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD Keys"",
                    ""id"": ""6b68816a-6fbf-433a-b38a-b3d8bd01f380"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""df397162-ce73-4cf1-b975-f476ae38a98a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a05191bb-c84d-49ee-b38d-a17c55a74a96"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""46e49f19-5b34-4b9b-88d3-066152238790"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6be3923d-b314-4c39-8541-05bf03757d31"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d12b1fc7-147c-4041-8a79-05acc1e110f3"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cefa767f-f5af-44c7-a66b-263422690a24"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0303eaa-7217-46a5-aaf4-4741d66559c5"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28382874-9bc2-4bb7-b37a-175b1a710a3d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ef09892-4eab-4ed0-a03d-ed5190e4c3ba"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""678a442f-3283-43d6-845a-b8a3f0b68725"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8fd68866-332b-43a4-96de-3c7be282088e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d948006-f0fe-406a-981c-44362266928e"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""FirePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82d87726-a62c-4b1e-b1a8-288f10ac7793"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""FireDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KBM"",
            ""bindingGroup"": ""KBM"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PControls
        m_PControls = asset.FindActionMap("PControls", throwIfNotFound: true);
        m_PControls_Movement = m_PControls.FindAction("Movement", throwIfNotFound: true);
        m_PControls_Jump = m_PControls.FindAction("Jump", throwIfNotFound: true);
        m_PControls_Dash = m_PControls.FindAction("Dash", throwIfNotFound: true);
        m_PControls_Attack = m_PControls.FindAction("Attack", throwIfNotFound: true);
        m_PControls_FirePosition = m_PControls.FindAction("FirePosition", throwIfNotFound: true);
        m_PControls_FireDirection = m_PControls.FindAction("FireDirection", throwIfNotFound: true);
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

    // PControls
    private readonly InputActionMap m_PControls;
    private IPControlsActions m_PControlsActionsCallbackInterface;
    private readonly InputAction m_PControls_Movement;
    private readonly InputAction m_PControls_Jump;
    private readonly InputAction m_PControls_Dash;
    private readonly InputAction m_PControls_Attack;
    private readonly InputAction m_PControls_FirePosition;
    private readonly InputAction m_PControls_FireDirection;
    public struct PControlsActions
    {
        private @PlayerControls m_Wrapper;
        public PControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PControls_Movement;
        public InputAction @Jump => m_Wrapper.m_PControls_Jump;
        public InputAction @Dash => m_Wrapper.m_PControls_Dash;
        public InputAction @Attack => m_Wrapper.m_PControls_Attack;
        public InputAction @FirePosition => m_Wrapper.m_PControls_FirePosition;
        public InputAction @FireDirection => m_Wrapper.m_PControls_FireDirection;
        public InputActionMap Get() { return m_Wrapper.m_PControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPControlsActions instance)
        {
            if (m_Wrapper.m_PControlsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PControlsActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PControlsActionsCallbackInterface.OnJump;
                @Dash.started -= m_Wrapper.m_PControlsActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PControlsActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PControlsActionsCallbackInterface.OnDash;
                @Attack.started -= m_Wrapper.m_PControlsActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PControlsActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PControlsActionsCallbackInterface.OnAttack;
                @FirePosition.started -= m_Wrapper.m_PControlsActionsCallbackInterface.OnFirePosition;
                @FirePosition.performed -= m_Wrapper.m_PControlsActionsCallbackInterface.OnFirePosition;
                @FirePosition.canceled -= m_Wrapper.m_PControlsActionsCallbackInterface.OnFirePosition;
                @FireDirection.started -= m_Wrapper.m_PControlsActionsCallbackInterface.OnFireDirection;
                @FireDirection.performed -= m_Wrapper.m_PControlsActionsCallbackInterface.OnFireDirection;
                @FireDirection.canceled -= m_Wrapper.m_PControlsActionsCallbackInterface.OnFireDirection;
            }
            m_Wrapper.m_PControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @FirePosition.started += instance.OnFirePosition;
                @FirePosition.performed += instance.OnFirePosition;
                @FirePosition.canceled += instance.OnFirePosition;
                @FireDirection.started += instance.OnFireDirection;
                @FireDirection.performed += instance.OnFireDirection;
                @FireDirection.canceled += instance.OnFireDirection;
            }
        }
    }
    public PControlsActions @PControls => new PControlsActions(this);
    private int m_KBMSchemeIndex = -1;
    public InputControlScheme KBMScheme
    {
        get
        {
            if (m_KBMSchemeIndex == -1) m_KBMSchemeIndex = asset.FindControlSchemeIndex("KBM");
            return asset.controlSchemes[m_KBMSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnFirePosition(InputAction.CallbackContext context);
        void OnFireDirection(InputAction.CallbackContext context);
    }
}
