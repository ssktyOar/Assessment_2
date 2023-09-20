using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField]
    internal Sprite spr;

    [SerializeField]
    internal string[] keys;

    public abstract void Action(string key);
}
