using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInputActions playerControls;
    private InputAction movement;
    private InputAction mouse;
    private InputAction shoot;


    [SerializeField] private Vector2 movementValue;
    [SerializeField] private Vector2 mouseValue;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        movement = playerControls.gameplay.movement;
        movement.Enable();
        mouse = playerControls.gameplay.mouse;
        mouse.Enable();
        shoot = playerControls.gameplay.shoot;
        shoot.Enable();
        shoot.performed += Shoot;
    }
    private void OnDisable()
    {
        movement.Disable();
        mouse.Disable();
        shoot.Disable();
    }

    private void Update()
    {
        movementValue = movement.ReadValue<Vector2>();
        mouseValue = mouse.ReadValue<Vector2>();


        //this is temporary code just to demonstrate that the game detects player input and can respond to it.
        transform.position += new Vector3(movementValue.x, 0, movementValue.y) * Time.deltaTime * 10;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (new Vector3(-mouseValue.y, mouseValue.x, 0) * Time.deltaTime * 10f));
        ////////////////////////
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        Debug.Log("left click");
    }    
}