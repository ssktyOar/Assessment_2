using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    Gun[] guns;

    [SerializeField]
    internal Gun currentGun;

    [SerializeField]
    Image image;

    [SerializeField]
    string[] keys;

    int i;

    public void Switch(int val)
    {
        if (0 <= val && val < guns.Length)
        {
            currentGun = guns[val];
            image.sprite = guns[val].spr;
        }
    }

    public void FixedUpdate()
    {
        for (i = 0; i < keys.Length; i++)
        {
            if (Input.GetKey(keys[i]))
            {
                Switch(i);
            }
        }

        for (i = 0; i < currentGun.keys.Length; i++)
        {
            if (Input.GetKey(currentGun.keys[i]))
            {
                currentGun.Action(currentGun.keys[i]);
                break;
            }
        }
    }
}
