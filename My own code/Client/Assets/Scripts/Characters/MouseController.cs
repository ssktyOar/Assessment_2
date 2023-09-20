using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField]
    HeadControls hd;

    [SerializeField]
    RotateController rc;

    private void FixedUpdate()
    {
        hd.Action(Input.GetAxis("Mouse Y"));
        rc.Action(Input.GetAxis("Mouse X"));
        // // Debug.Log(Input.GetAxis("Mouse X") + " " + Input.GetAxis("Mouse Y"));
    }
}
