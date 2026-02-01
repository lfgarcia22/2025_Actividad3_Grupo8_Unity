using UnityEngine;
using UnityEngine.InputSystem;
using Assets.Kits.Characters.ICommon.Scripts;

public class PlayerController : MovementController
{
    [Header("Input Actions")]
    [SerializeField] private InputActionReference walk;
    [SerializeField] private InputActionReference interact;


    // [Header("General")]
    // [SerializeField] private RuntimeAnimatorController selectedCharacterController;

    private void OnEnable()
    {
        walk.action.Enable();
        interact.action.Enable();

        walk.action.started += OnWalk;
        walk.action.performed += OnWalk;
        walk.action.canceled += OnWalk;

        interact.action.started += OnInteract;
    }
    private void OnDisable()
    {
        walk.action.Disable();
        interact.action.Disable();

        walk.action.started -= OnWalk;
        walk.action.performed -= OnWalk;
        walk.action.canceled -= OnWalk;

        interact.action.started -= OnInteract;
    }

    private void OnWalk(InputAction.CallbackContext context)
    {
        DesiredMove = context.ReadValue<Vector2>();
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
    }



}
