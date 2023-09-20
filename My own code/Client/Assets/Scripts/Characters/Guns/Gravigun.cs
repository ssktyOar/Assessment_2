using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravigun : Gun
{
    [SerializeField]
    GameObject head;

    [SerializeField]
    float dist;

    [SerializeField]
    GameObject cmps;

    [HideInInspector]
    RaycastHit hit;

    [HideInInspector]
    readonly int layerMask = ~(1 << 8);

    [HideInInspector]
    GameObject g;



    private void Start()
    {
        cmps.transform.parent = gameObject.transform;
    }

    public override void Action(string key)
    {
        if(key == "Fire1")
        {
            GetObject();
        }
    }

    void GetObject()
    {
        if(g == null)
        {
            if (Physics.Raycast(head.transform.position, head.transform.TransformDirection(0, 0, 1), out hit, dist, layerMask))
            {
                if (hit.rigidbody != null)
                {
                    g = hit.rigidbody.gameObject;
                    g.GetComponent<Rigidbody>().isKinematic = true;
                    cmps.transform.localPosition = new(0, 0, hit.distance);
                    g.transform.parent = cmps.transform;
                }
            }
        }
        else
        {
            g.transform.parent = null;
            g.GetComponent<Rigidbody>().isKinematic = false;
            g = null;
        }
    }

}