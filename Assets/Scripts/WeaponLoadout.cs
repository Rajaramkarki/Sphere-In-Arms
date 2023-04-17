using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLoadout : MonoBehaviour
{
    public GameObject[] loadout;
    public Transform weaponSpawn; //takes in the positional values from the weapon parent from the inspector.

    private GameObject currentEquipment;
    void Start()
    {
        Equip(0);
    }

    void Update()
    {
        //if we press "1" on the keyboard, equip the primary weapon or
        //the weapon in the first index of the loadout array.
        if (Input.GetKeyDown(KeyCode.Alpha1)) Equip(0);
        if(Input.GetKeyDown(KeyCode.Alpha2)) Equip(1);
    }

    void Equip(int weapon_index)
    {
        //if we are equipped with the weapon/equipment already, destroy it
        //and create a new one with instantiate()
        //and set the currentEquipment to the instantiated equipment/weapon.

        //--------------------------------------------------------------------------
        //if (currentEquipment != loadout[weapon_index])
        //{
        //    WeaponSwapDelay(2.5f);
        //}
        //else
        //{
        //    WeaponSwapDelay(2.5f);
        //}
        //--------------------------------------------------------------------------
        if (currentEquipment != null) Destroy(currentEquipment);
        GameObject newEquipment = Instantiate(loadout[weapon_index], weaponSpawn.position, weaponSpawn.rotation, weaponSpawn) as GameObject;

        //setting the instantiated object position
        //and rotation to zero wrt the parent.
        newEquipment.transform.localPosition = Vector3.zero;
        newEquipment.transform.localEulerAngles = new Vector3(0, 180, 0);

        currentEquipment = newEquipment;
    }

    //--------------------------------------------------------------------------------------------------------
    //private IEnumerator WeaponSwapDelay(float delay)
    //{
    //    //a subroutine made from IEnumerator to make a player wait a few moment to swap the weapon/equipment.
    //    yield return new WaitForSeconds(delay);
    //}
    //--------------------------------------------------------------------------------------------------------
}
