using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActDsc : MonoBehaviour
{
    [SerializeField]
    GameObject g;
    public void SETACT(bool val)
    {
        g.SetActive(val);
    }
}
