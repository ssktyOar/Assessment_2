using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyboardController : MonoBehaviour
{
    [SerializeField]
    string[] keys;

    [SerializeField]
    AbsrtClass[] actions;

    int min;

    int i;

    private void Start()
    {
        min = Math.Min(keys.Length, actions.Length);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for(i = 0; i < min; i++)
        {
            if (Input.GetKey(keys[i]))
            {
                actions[i].Action();
            }
        }
    }
}
