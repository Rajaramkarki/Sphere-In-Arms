//*********************************************************************************

//not being used**

//Weapon Sway: weapon movement in the game to feel game more responsive/ alive.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_WeaponSway : MonoBehaviour
{
    [Header("Sway Settings")]
    [SerializeField] private float smoothSway = 8;
    [SerializeField] private float swayMultiplier = 2;

    private void Update()
    {
        //get mouse input(not using Input System here, be sure to tick "both" in the input options in Project settings!)
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;

        //calculate target rotation:
        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right); //+ve on Y has the inverted effect by default!
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        //combining the rotations in X and Y
        Quaternion targetRotation = rotationX * rotationY;

        //rotate via Slerp is used for interpolating the angles based on only few inputs and some default values.(creating smooth weapon sway):
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoothSway * Time.deltaTime);
    }
}
