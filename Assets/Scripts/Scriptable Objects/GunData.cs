using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//creating a kind of select dropdown in the menu section of Assets in the Hierarchy: s.t. we can make new guns with the properties as mentioned in the GunData class.
[CreateAssetMenu(fileName ="Gun", menuName = "Weapon/Gun")]

//inheriting from unity's existing class of ScriptableObject:
public class GunData : ScriptableObject
{
    [Header("Info")]
    public new string name;

    [Header("Shooting")]
    public float damage;
    public float maxDistance;

    [Header("Reloading")]
    public int currentAmmo;
    public int magSize;
    public float fireRate;
    public float reloadTime;

    //[HideInInspector]
    public bool reloading;

}
