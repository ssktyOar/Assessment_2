using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneGravity : MonoBehaviour
{
    [SerializeField]
    float force;

    [SerializeField]
    float force2;

    [SerializeField]
    float time;

    [SerializeField]
    float dist;

    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    Vector3 drag = new(0, 30, 0);

    [HideInInspector]
    Vector3 velosity;

    RaycastHit hit;

    float count = 0;

    // Bit shift the index of the layer (8) to get a bit mask
    // This would cast rays only against colliders in layer 8.
    // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
    [HideInInspector]
    readonly int layerMask = ~(1 << 8);

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(0, -1, 0), out hit, dist, layerMask))
        {
            drag.y = 30f;

            if (hit.distance < dist / 4)
            {
                count += time * 0.1f;
                rb.useGravity = false;
            }
            else
            {
                rb.useGravity = true;
            }

            if (count < time)
            {
                count += Time.fixedDeltaTime;
            }
            else
            {
                if (hit.distance < dist / 2)
                {
                    rb.AddForce(0, force2, 0);
                }
                else
                {
                    rb.AddForce(0, force, 0);
                }
            }
        }
        else
        {
            drag.y = 0f;
            count = 0;
            rb.useGravity = true;
        }
        velosity = rb.velocity;
        rb.velocity -= new Vector3(velosity.x * drag.x, velosity.y * drag.y, velosity.z * drag.z) * Time.fixedDeltaTime;
    }
}
