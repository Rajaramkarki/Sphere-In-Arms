using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAdditionalMotions : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float gravity = 9.8f;
    [SerializeField]
    private float jumpSpeed = 3.5f;

    private float DIRECTION_Y;

    private Transform _position;


    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Jump();
    }

    void Jump()
    {
        Vector3 direction = new Vector3(0, 0, 0);

        if (Input.GetButtonDown("Jump"))
        {
            DIRECTION_Y = jumpSpeed;
        }

        DIRECTION_Y -= gravity * Time.deltaTime;

        direction.y = DIRECTION_Y;

        _controller.Move(direction * moveSpeed * Time.deltaTime);
    }

}
