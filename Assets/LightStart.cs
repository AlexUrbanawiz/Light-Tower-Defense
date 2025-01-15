using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStart : MonoBehaviour
{
    // Start is called before the first frame update 
    Vector3 dir = Vector3.up;
    [SerializeField] float startWidth;
    [SerializeField] float endwith;
    [SerializeField] Color startColor;
    [SerializeField] Color endColor;
    [SerializeField] Material material;

    public void Update()
    {
        GameObject laserBeam = GameObject.Find("Laser Beam");
        if (laserBeam == null)
        {
            LightBeam beam = new LightBeam(transform.position, dir, startWidth, endwith, startColor, endColor, material);
        }
        else
        {
            Destroy(laserBeam);
            LightBeam beam = new LightBeam(transform.position, dir, startWidth, endwith, startColor, endColor, material);
        }

    }
}
