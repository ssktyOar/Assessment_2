using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : Endurance
{
    [SerializeField]
    float maxHealth;

    [SerializeField]
    float health;

    [SerializeField]
    float resistant;

    [SerializeField]
    float maxShield;

    [SerializeField]
    float shield;

    [SerializeField]
    float shieldResistant;

    float curdmg;

    public override void Damage(float damage)
    {
        if (shield > 0)
        {
            curdmg = damage * resistant;
            if (curdmg / maxShield > 6)
            {
                curdmg -= shield;
                shield = 0;

                health -= curdmg;
                if (health <= 0)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                shield -= damage*resistant;
                if (shield < 0)
                {
                    shield = 0;
                }
            }
        }
        else
        {
            health -= damage;
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void RegenShield(float val)
    {
        if (shield < maxShield)
        {
            shield += val;
            if(shield > maxShield)
            {
                shield = maxShield;
            }
        }
    }

    public override void Repair(float val)
    {
        if (shield < maxShield)
        {
            shield += val;
            if (shield > maxShield)
            {
                shield = maxShield;
            }
        }
    }
}
