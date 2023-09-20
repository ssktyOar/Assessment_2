using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
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
        head.transform.localEulerAngles = new Vector3(l.x, l.y + force * sensivity * val, l.z);
    }
}
