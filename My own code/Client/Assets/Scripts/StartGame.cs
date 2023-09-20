using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    GameObject destroy;



    [SerializeField]
    GameObject host;

    [SerializeField]
    GameObject cd;

    public void Host()
    {
        Instantiate(host);
        Destroy(destroy);
    }

    public void CD()
    {
        Instantiate(cd);
        Destroy(destroy);
    }
}
