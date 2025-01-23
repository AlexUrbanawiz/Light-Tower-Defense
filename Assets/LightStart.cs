using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStart : MonoBehaviour
{
    // Start is called before the first frame update 
    Vector3 dir = Vector3.up;
    [SerializeField] float startWidth;
    [SerializeField] float endwith;
    [SerializeField] Color startColor = Color.white;
    [SerializeField] Color endColor = Color.white;
    [SerializeField] Material material;
    public List<LightBeam> laserBeams = new List<LightBeam>() { };

    public void Update()
    {
        

        if (laserBeams.Count == 0)
        {
            LightBeam beam = new LightBeam(transform.position, dir, startWidth, endwith, startColor, endColor, material, gameObject, "White");
            laserBeams.Add(beam);

        }
        else
        {
            foreach (LightBeam laser in laserBeams)
            {
                laser.DestroyBeam();
            }
            LightBeam beam = new LightBeam(transform.position, dir, startWidth, endwith, startColor, endColor, material, gameObject, "White");
            laserBeams.Add(beam);
        }

    }
}
