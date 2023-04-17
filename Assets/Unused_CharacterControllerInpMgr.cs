//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Unused_CharacterControllerInpMgr : MonoBehaviour
//{
//    [SerializeField]
//    private float speed = 5f;
//    [SerializeField]
//    private float lookSensitivity = 10f;

//    private PlayerMotor motor;

//    [SerializeField]
//    private Camera cam;

//    private Vector3 velocity = Vector3.zero;
//    private Vector3 rotation = Vector3.zero;
//    private Vector3 cameraRotation = Vector3.zero;


//    private Rigidbody rb;

//    void Start()
//    {
//        motor = GetComponent<PlayerMotor>();
//        rb = GetComponent<Rigidbody>();
//    }

//    void Update()
//    {
//        float xMovement = Input.GetAxisRaw("Horizontal");
//        float zMovement = Input.GetAxisRaw("Vertical");

//        Vector3 movHorizontal = transform.right * xMovement;
//        Vector3 movVertical = transform.forward * zMovement;


//        Vector3 velocity = (movHorizontal + movVertical).normalized * speed;

//        motor.Move(velocity);

//        float yRotation = Input.GetAxisRaw("Mouse X");

//        //only Y movement as X doesnt affect the sphere
//        Vector3 rotation = new Vector3(0f, yRotation, 0f) * lookSensitivity;

//        motor.Rotate(rotation);

//        float xRotation = Input.GetAxisRaw("Mouse Y");

//        //only Y movement as X doesnt affect the sphere
//        Vector3 cameraRotation = new Vector3(xRotation, 0f, 0f) * lookSensitivity;

//        motor.RotateCamera(cameraRotation);
//    }

//    void FixedUpdate()
//    {
//        PerformMovement();
//        PerformRotation();
//    }


//    public void Move(Vector3 _velocity)
//    {
//        velocity = _velocity;
//    }

//    public void Rotate(Vector3 _rotation)
//    {
//        rotation = _rotation;
//    }

//    public void RotateCamera(Vector3 _cameraRotation)
//    {
//        cameraRotation = _cameraRotation;
//    }

//    void PerformMovement()
//    {
//        if (velocity != Vector3.zero)
//        {
//            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
//        }
//    }

//    void PerformRotation()
//    {
//        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
//        if (cam != null)
//        {
//            cam.transform.Rotate(-cameraRotation);
//        }
//    }

//}