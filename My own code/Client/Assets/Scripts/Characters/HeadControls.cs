using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadControls : MonoBehaviour
{
    [SerializeField]
    GameObject head;

    [SerializeField]
    float sensivity = 1f;

    [SerializeField]
    float force = 1f;

    [HideInInspector]
    Vector3 l;


    public void Action(float val)
    {
        l = head.transform.localEulerAngles;
        l = new Vector3(l.x + force * sensivity * val, l.y, l.z);
        if (l.x > 80 && l.x < 280)
        {
            l.x = 80;
        }
        else if (l.x > 270 && l.x < 300)
        {
            l.x = 300f;
        }
        head.transform.localEulerAngles = l;
    }

}
