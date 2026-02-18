using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    // Input action controllers
    protected InputSystem_Actions m_actions;

    // Variables to store values from inputs
    protected Vector2 m_moveAmt;
    protected bool m_attackAmt = false;
    protected bool m_pause = false;

    void Awake()
    {
        Debug.Log("InputController - Awake");
        m_actions = new InputSystem_Actions();
    }

    void OnEnable()
    {
        Debug.Log("InputController - OnEnable");
        m_actions.Player.Enable();
        m_actions.Player.Move.performed += MoveInput;
        m_actions.Player.Move.canceled += MoveInput;
        m_actions.Player.Interact.performed += InteractInput;
        m_actions.Player.Interact.canceled += InteractInput;
        m_actions.Player.Pause.performed += PauseInput;
        m_actions.Player.Pause.canceled += PauseInput;
        m_actions.Player.Inventory.performed += InventoryInput;
        m_actions.Player.Inventory.canceled += InventoryInput;
    }

    void OnDisable()
    {
        Debug.Log("InputController - OnDisable");
        m_actions.Player.Disable();
        m_actions.Player.Move.performed -= MoveInput;
        m_actions.Player.Move.canceled -= MoveInput;
        m_actions.Player.Interact.performed -= InteractInput;
        m_actions.Player.Interact.canceled -= InteractInput;
        m_actions.Player.Pause.performed -= PauseInput;
        m_actions.Player.Pause.canceled -= PauseInput;
        m_actions.Player.Inventory.performed -= InventoryInput;
        m_actions.Player.Inventory.canceled -= InventoryInput;
    }

    private void MoveInput(InputAction.CallbackContext ctx)
    {
        m_moveAmt = ctx.ReadValue<Vector2>();
    }

    private void InteractInput(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Debug.Log("InputController - InteractInput: performed");
            CallInteraction();
        }
    }

    private void PauseInput(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Debug.Log("InputController - PauseInput: performed");
        }
    }

    private void InventoryInput(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Debug.Log("InputController - InventoryInput: performed");
            CallInventory();
        }
    }

    protected virtual void CallInteraction()
    {
        Debug.Log("InputController - CallInteraction");
    }

    protected virtual void CallInventory()
    {
        Debug.Log("InputController - CallInventory");
    }
}
