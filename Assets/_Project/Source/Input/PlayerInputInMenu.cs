//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.8.2
//     from Assets/_Project/Source/Input/PlayerInputInMenu.inputactions
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
using UnityEngine;

public partial class @PlayerInputInMenu: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputInMenu()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputInMenu"",
    ""maps"": [
        {
            ""name"": ""Interact"",
            ""id"": ""67331770-009a-4f62-ba51-5d2ae73e530c"",
            ""actions"": [
                {
                    ""name"": ""SwipeLeft"",
                    ""type"": ""Button"",
                    ""id"": ""4e236181-101e-4fcb-8cda-02d8deb1a71f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PressButton"",
                    ""type"": ""Button"",
                    ""id"": ""75b44502-e444-4753-aa4a-eddfadd38248"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwipeRight"",
                    ""type"": ""Button"",
                    ""id"": ""42268b54-49df-4ea9-9a6b-b3bb29295a08"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""43240229-250e-40b4-87e7-12e948ddb5cc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwipeLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0253c653-4144-4b12-9341-747bf9def824"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwipeLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61964d8e-1f1a-4887-951e-54d0cee3dbd4"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PressButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2be734df-6d9d-41a6-b61b-e8d9027f33f2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PressButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef21a462-f4c7-4d54-92c1-e08babbd8f4d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwipeRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""584c2305-0883-4640-92f6-b40464c6a70a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwipeRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Interact
        m_Interact = asset.FindActionMap("Interact", throwIfNotFound: true);
        m_Interact_SwipeLeft = m_Interact.FindAction("SwipeLeft", throwIfNotFound: true);
        m_Interact_PressButton = m_Interact.FindAction("PressButton", throwIfNotFound: true);
        m_Interact_SwipeRight = m_Interact.FindAction("SwipeRight", throwIfNotFound: true);
    }

    ~@PlayerInputInMenu()
    {
        Debug.Assert(!m_Interact.enabled, "This will cause a leak and performance issues, PlayerInputInMenu.Interact.Disable() has not been called.");
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

    // Interact
    private readonly InputActionMap m_Interact;
    private List<IInteractActions> m_InteractActionsCallbackInterfaces = new List<IInteractActions>();
    private readonly InputAction m_Interact_SwipeLeft;
    private readonly InputAction m_Interact_PressButton;
    private readonly InputAction m_Interact_SwipeRight;
    public struct InteractActions
    {
        private @PlayerInputInMenu m_Wrapper;
        public InteractActions(@PlayerInputInMenu wrapper) { m_Wrapper = wrapper; }
        public InputAction @SwipeLeft => m_Wrapper.m_Interact_SwipeLeft;
        public InputAction @PressButton => m_Wrapper.m_Interact_PressButton;
        public InputAction @SwipeRight => m_Wrapper.m_Interact_SwipeRight;
        public InputActionMap Get() { return m_Wrapper.m_Interact; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InteractActions set) { return set.Get(); }
        public void AddCallbacks(IInteractActions instance)
        {
            if (instance == null || m_Wrapper.m_InteractActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InteractActionsCallbackInterfaces.Add(instance);
            @SwipeLeft.started += instance.OnSwipeLeft;
            @SwipeLeft.performed += instance.OnSwipeLeft;
            @SwipeLeft.canceled += instance.OnSwipeLeft;
            @PressButton.started += instance.OnPressButton;
            @PressButton.performed += instance.OnPressButton;
            @PressButton.canceled += instance.OnPressButton;
            @SwipeRight.started += instance.OnSwipeRight;
            @SwipeRight.performed += instance.OnSwipeRight;
            @SwipeRight.canceled += instance.OnSwipeRight;
        }

        private void UnregisterCallbacks(IInteractActions instance)
        {
            @SwipeLeft.started -= instance.OnSwipeLeft;
            @SwipeLeft.performed -= instance.OnSwipeLeft;
            @SwipeLeft.canceled -= instance.OnSwipeLeft;
            @PressButton.started -= instance.OnPressButton;
            @PressButton.performed -= instance.OnPressButton;
            @PressButton.canceled -= instance.OnPressButton;
            @SwipeRight.started -= instance.OnSwipeRight;
            @SwipeRight.performed -= instance.OnSwipeRight;
            @SwipeRight.canceled -= instance.OnSwipeRight;
        }

        public void RemoveCallbacks(IInteractActions instance)
        {
            if (m_Wrapper.m_InteractActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInteractActions instance)
        {
            foreach (var item in m_Wrapper.m_InteractActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InteractActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InteractActions @Interact => new InteractActions(this);
    public interface IInteractActions
    {
        void OnSwipeLeft(InputAction.CallbackContext context);
        void OnPressButton(InputAction.CallbackContext context);
        void OnSwipeRight(InputAction.CallbackContext context);
    }
}
