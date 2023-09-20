using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntigravModule : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    float maxAntigrav;

    [SerializeField]
    float coefAntigrav;

    private void FixedUpdate()
    {
        rb.AddForce(0, coefAntigrav * maxAntigrav, 0);
    }
}
