using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Settings : MonoBehaviour
{
    [SerializeField]
    Camera c;

    GraphicsTier[] graphicsTiers;

    private void Start()
    {
        graphicsTiers = new GraphicsTier[] { GraphicsTier.Tier1, GraphicsTier.Tier2, GraphicsTier.Tier3 };
    }

    public void CameraFar(float val)
    {
        c.farClipPlane = val;
    }

    public void GraphicsSettings(int number)
    {
        Graphics.activeTier = graphicsTiers[number];
    }

    public void CameraDistance(float val)
    {
        c.transform.localPosition = new Vector3(0, 0, val);
    }
}
