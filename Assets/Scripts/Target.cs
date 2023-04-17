using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//inheriting from IDamageable "interface" class too:
public class Target : MonoBehaviour, IDamageable
{
    //Declaring HP of our Target:
    public float health = 100f;

    //implementing the Damage() method of our Interface class:
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
