using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Endurance
{
    [SerializeField]
    Collider shieldCollider;

    [SerializeField]
    float maxShield;

    [SerializeField]
    float shield;

    [SerializeField]
    float shieldResistant;

    public override void Damage(float damage)
    {
        shield -= damage * shieldResistant;
        if (shield < 0)
        {
            shield = 0;
            shieldCollider.enabled = false;
        }
    }

    public override void Repair(float val)
    {
        shield += val;
    }

    public void OnShield()
    {
        if (shield > 0)
        {
            shieldCollider.enabled = true;
        }
    }

    public void OffShield()
    {
        shieldCollider.enabled = false;
    }
}
