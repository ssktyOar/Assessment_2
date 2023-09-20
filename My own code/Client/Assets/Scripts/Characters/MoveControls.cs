using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControls : AbsrtClass
{
    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    Vector3 force;

    public override void Action()
    {
        rb.AddRelativeForce(force);
    }
}
