// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputSystem : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""Movimiento"",
            ""id"": ""3ba470d6-95ad-472a-89b4-03b131aeb069"",
            ""actions"": [
                {
                    ""name"": ""Andar"",
                    ""type"": ""Value"",
                    ""id"": ""b6348aab-d02e-4d4d-a00a-327ccea295dd"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Correr"",
                    ""type"": ""Button"",
                    ""id"": ""5587a00a-b1de-46bf-8d13-7f4c1c984444"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Saltar"",
                    ""type"": ""Button"",
                    ""id"": ""46c374cc-9df6-4233-9a02-bf10a4638d4d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4b930670-c58b-479e-aac2-ec9aaf375952"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Andar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""dc502534-2ffe-4241-9ff0-4e1cd1e45475"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Andar"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""2a9d8e89-be34-4506-93aa-abcfd66aa63c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Andar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2d5d47c3-ca6f-4bbc-a0b7-edb9635cc2b7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Andar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6ec3cf22-cd84-4e2d-af96-0456c7e2eaf1"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Correr"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff4e0180-14f5-40fc-931d-9c881aa49300"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Correr"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87ea6b65-fb86-49c6-971f-ff28816e9181"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Saltar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fcaedf6d-6381-4837-8e18-d997a47fc2f9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Saltar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Ataque"",
            ""id"": ""be13faee-d999-4648-bdd5-64f79b131927"",
            ""actions"": [
                {
                    ""name"": ""AtaqueBasico"",
                    ""type"": ""Button"",
                    ""id"": ""7ed7ae33-6d2e-4605-abba-931f6689bd3f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AtaqueDsitancia"",
                    ""type"": ""Button"",
                    ""id"": ""fe75044b-946e-4e94-b41b-4724b861cd82"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bc05fa06-6ac0-405f-b7c8-b3b235f35b12"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AtaqueBasico"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05e78738-b295-45fd-be17-d64328cf46e3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AtaqueBasico"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""339547de-8e91-4113-97c1-49eccc7a8bac"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AtaqueDsitancia"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movimiento
        m_Movimiento = asset.FindActionMap("Movimiento", throwIfNotFound: true);
        m_Movimiento_Andar = m_Movimiento.FindAction("Andar", throwIfNotFound: true);
        m_Movimiento_Correr = m_Movimiento.FindAction("Correr", throwIfNotFound: true);
        m_Movimiento_Saltar = m_Movimiento.FindAction("Saltar", throwIfNotFound: true);
        // Ataque
        m_Ataque = asset.FindActionMap("Ataque", throwIfNotFound: true);
        m_Ataque_AtaqueBasico = m_Ataque.FindAction("AtaqueBasico", throwIfNotFound: true);
        m_Ataque_AtaqueDsitancia = m_Ataque.FindAction("AtaqueDsitancia", throwIfNotFound: true);
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

    // Movimiento
    private readonly InputActionMap m_Movimiento;
    private IMovimientoActions m_MovimientoActionsCallbackInterface;
    private readonly InputAction m_Movimiento_Andar;
    private readonly InputAction m_Movimiento_Correr;
    private readonly InputAction m_Movimiento_Saltar;
    public struct MovimientoActions
    {
        private @InputSystem m_Wrapper;
        public MovimientoActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Andar => m_Wrapper.m_Movimiento_Andar;
        public InputAction @Correr => m_Wrapper.m_Movimiento_Correr;
        public InputAction @Saltar => m_Wrapper.m_Movimiento_Saltar;
        public InputActionMap Get() { return m_Wrapper.m_Movimiento; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovimientoActions set) { return set.Get(); }
        public void SetCallbacks(IMovimientoActions instance)
        {
            if (m_Wrapper.m_MovimientoActionsCallbackInterface != null)
            {
                @Andar.started -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnAndar;
                @Andar.performed -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnAndar;
                @Andar.canceled -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnAndar;
                @Correr.started -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnCorrer;
                @Correr.performed -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnCorrer;
                @Correr.canceled -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnCorrer;
                @Saltar.started -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnSaltar;
                @Saltar.performed -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnSaltar;
                @Saltar.canceled -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnSaltar;
            }
            m_Wrapper.m_MovimientoActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Andar.started += instance.OnAndar;
                @Andar.performed += instance.OnAndar;
                @Andar.canceled += instance.OnAndar;
                @Correr.started += instance.OnCorrer;
                @Correr.performed += instance.OnCorrer;
                @Correr.canceled += instance.OnCorrer;
                @Saltar.started += instance.OnSaltar;
                @Saltar.performed += instance.OnSaltar;
                @Saltar.canceled += instance.OnSaltar;
            }
        }
    }
    public MovimientoActions @Movimiento => new MovimientoActions(this);

    // Ataque
    private readonly InputActionMap m_Ataque;
    private IAtaqueActions m_AtaqueActionsCallbackInterface;
    private readonly InputAction m_Ataque_AtaqueBasico;
    private readonly InputAction m_Ataque_AtaqueDsitancia;
    public struct AtaqueActions
    {
        private @InputSystem m_Wrapper;
        public AtaqueActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @AtaqueBasico => m_Wrapper.m_Ataque_AtaqueBasico;
        public InputAction @AtaqueDsitancia => m_Wrapper.m_Ataque_AtaqueDsitancia;
        public InputActionMap Get() { return m_Wrapper.m_Ataque; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AtaqueActions set) { return set.Get(); }
        public void SetCallbacks(IAtaqueActions instance)
        {
            if (m_Wrapper.m_AtaqueActionsCallbackInterface != null)
            {
                @AtaqueBasico.started -= m_Wrapper.m_AtaqueActionsCallbackInterface.OnAtaqueBasico;
                @AtaqueBasico.performed -= m_Wrapper.m_AtaqueActionsCallbackInterface.OnAtaqueBasico;
                @AtaqueBasico.canceled -= m_Wrapper.m_AtaqueActionsCallbackInterface.OnAtaqueBasico;
                @AtaqueDsitancia.started -= m_Wrapper.m_AtaqueActionsCallbackInterface.OnAtaqueDsitancia;
                @AtaqueDsitancia.performed -= m_Wrapper.m_AtaqueActionsCallbackInterface.OnAtaqueDsitancia;
                @AtaqueDsitancia.canceled -= m_Wrapper.m_AtaqueActionsCallbackInterface.OnAtaqueDsitancia;
            }
            m_Wrapper.m_AtaqueActionsCallbackInterface = instance;
            if (instance != null)
            {
                @AtaqueBasico.started += instance.OnAtaqueBasico;
                @AtaqueBasico.performed += instance.OnAtaqueBasico;
                @AtaqueBasico.canceled += instance.OnAtaqueBasico;
                @AtaqueDsitancia.started += instance.OnAtaqueDsitancia;
                @AtaqueDsitancia.performed += instance.OnAtaqueDsitancia;
                @AtaqueDsitancia.canceled += instance.OnAtaqueDsitancia;
            }
        }
    }
    public AtaqueActions @Ataque => new AtaqueActions(this);
    public interface IMovimientoActions
    {
        void OnAndar(InputAction.CallbackContext context);
        void OnCorrer(InputAction.CallbackContext context);
        void OnSaltar(InputAction.CallbackContext context);
    }
    public interface IAtaqueActions
    {
        void OnAtaqueBasico(InputAction.CallbackContext context);
        void OnAtaqueDsitancia(InputAction.CallbackContext context);
    }
}
