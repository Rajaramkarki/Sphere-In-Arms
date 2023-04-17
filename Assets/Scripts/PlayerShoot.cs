//script to invoke "shoot" or "reload" action when the event is being performed

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public static Action shootInput; //for shoot input
    public static Action reloadInput; //for reload input

    [SerializeField] private KeyCode reloadKey;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shootInput?.Invoke(); //null conditional operator that avoids the function, "Invoke()" whenever the event "GetMouseButton(0)" i.e. mouse button input is not found!
        }

        if (Input.GetKeyDown(reloadKey))
        {
            reloadInput?.Invoke(); //if we press the reloadKey, invoke the event.
        }
    }
}
