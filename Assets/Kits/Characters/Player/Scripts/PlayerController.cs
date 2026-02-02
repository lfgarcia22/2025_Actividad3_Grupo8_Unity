using UnityEngine;
using UnityEngine.InputSystem;
using Assets.Kits.Characters.ICommon.Scripts;

public class PlayerController : MovementController
{
    [Header("Input Actions")]
    [SerializeField] private InputActionReference walk;
    [SerializeField] private InputActionReference interact;


    private void OnEnable()
    {
        if (walk != null)
        {
            walk.action.Enable();
            walk.action.started += OnWalk;
            walk.action.performed += OnWalk;
            walk.action.canceled += OnWalk;
        }

        if (interact != null)
        {
            interact.action.Enable();
            interact.action.started += OnInteract;
        }
    }
    private void OnDisable()
    {
        if (walk != null)
        {
            walk.action.Disable();
            walk.action.started -= OnWalk;
            walk.action.performed -= OnWalk;
            walk.action.canceled -= OnWalk;
        }

        if (interact != null)
        {
            interact.action.Disable();
            interact.action.started -= OnInteract;
        }
    }

    private void OnWalk(InputAction.CallbackContext context)
    {
        DesiredMove = context.ReadValue<Vector2>();
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
    }

}
