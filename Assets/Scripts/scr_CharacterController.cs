using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class scr_CharacterController : MonoBehaviour
{
    //using the Input System's generated class.
    private InputMaster inputMaster;
    public Vector2 input_Movement;
    public Vector2 input_View;

    private Vector3 newCameraRotation;
    private Vector3 newCharacterRotation;

    [Header("References")]
    public Transform cameraHolder;

    [SerializeField] private float ViewXSensitivity = 10;
    [SerializeField] private float ViewYSensitivity = 10;
    [SerializeField] private float viewClampYMin = -70;
    [SerializeField] private float viewClampYMax = 80;

    [Header("Movement Speed")]
    [SerializeField] private float WalkingForwardSpeed = 10;
    [SerializeField] private float WalkingStrafeSpeed = 6;
    //[SerializeField] private float WalingBackwardSpeed = 4;

    private CharacterController characterController;

    [Header("Weapon Rotation")]
    [SerializeField] private Transform weapon;

    private void Awake()
    {
        //creating an instance of the InputMaster Class aka, generated class.
        inputMaster = new InputMaster();

        //making use of the events being called in the inputMaster as specified in our input system.
        //"input_Movement" and "input_View" are just used as references to the events of our input system.. rest is the syntax working.
        //e.ReadValue<Vector2>(); is making input_Movement and input_View, independently expect the Vector2 values.
        inputMaster.Character.Movement.performed += e => input_Movement = e.ReadValue<Vector2>();
        inputMaster.Character.View.performed += e => input_View = e.ReadValue<Vector2>();


        //enabling our inputMaster instance of the InputMaster Class:
        inputMaster.Enable();

        //getting the local Transform of camera.
        newCameraRotation = cameraHolder.localRotation.eulerAngles;

        //getting the local transform for character rotation too.
        newCharacterRotation = transform.localRotation.eulerAngles;

        //variable for game object:
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        CalculateView();
        CalculateMovement();
    }

    private void CalculateView()
    {
        //controlling our mouse's vertical movement(Camera's movement) i.e. rotating/controlling our camera.
        newCameraRotation.x += ViewYSensitivity * -input_View.y * Time.deltaTime; //negative input_View.y to get rid of mouse inverted effect.
        newCameraRotation.x = Mathf.Clamp(newCameraRotation.x, viewClampYMin, viewClampYMax);

        cameraHolder.localRotation = Quaternion.Euler(newCameraRotation);

        //controlling our mouse's horizontal movement i.e controlling/rotating the character as a whole.(Y-axis)
        newCharacterRotation.y += ViewXSensitivity * input_View.x * Time.deltaTime;
        ;
        transform.localRotation = Quaternion.Euler(newCharacterRotation);

        weapon.rotation = cameraHolder.rotation;
    }

    private void CalculateMovement()
    {
        //creating new variables for combining the speed of character in different directions along with the booleans that they have been performed.
        var verticalSpeed = WalkingForwardSpeed * input_Movement.y * Time.deltaTime;
        var horizontalSpeed = WalkingStrafeSpeed * input_Movement.x * Time.deltaTime;

        //new positional vector:
        var newMovementSpeed = new Vector3(horizontalSpeed, 0, verticalSpeed);

        //changing the speed relative to the player/player's perspective of direction/rotation of player:
        newMovementSpeed = transform.TransformDirection(newMovementSpeed); //we're supposed to make a change to our value of "newMovementSpeed" and update it.

        //using the inbuilt Character Controller's Move() method:
        characterController.Move(newMovementSpeed);
    }
}


