using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeam
{
    public GameObject laserObj;
    private LineRenderer laser;
    private List<Vector3> laserIndicies = new List<Vector3>();
    private GameObject creator;
    private LightStart lightStarter;
    public string color;

    public LightBeam(Vector3 pos, Vector3 dir, float startWidth, float endwith, Color startColor, Color endColor, Material material, GameObject creator, string color)
    {
        laser = new LineRenderer();
        laserObj = new GameObject();
        laserObj.name = "Laser Beam";
        laserObj.tag = color;

        laser = this.laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        
        laser.startWidth = startWidth;
        laser.endWidth = endwith;
        laser.startColor = startColor;
        laser.endColor = endColor;
        laser.material = material;
        this.creator = creator;
        lightStarter = creator.GetComponent<LightStart>();

        CastLaser(pos, dir);

        
    }

    public void DestroyBeam()
    {
        GameObject.Destroy(laserObj);
    }
    private void CastLaser(Vector3 pos, Vector3 dir)
    {
        laserIndicies.Add(pos);
        Ray ray = new Ray(pos, dir);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, 1))
        {
            CheckHit(hit, dir);
        }
        else
        {
            laserIndicies.Add(ray.GetPoint(100));
            UpdateLaser();
        }

    }
    private void CheckHit(RaycastHit hit, Vector3 direction)
    {
        if (hit.collider.tag.Equals("Mirror"))
        {
            Vector3 pos = hit.point;
            Vector3 dir = Vector3.Reflect(direction, hit.normal);

            CastLaser(pos, dir);
        }
        else if (hit.collider.tag.Equals("Glass"))
        {
            Vector3 pos = hit.point + new Vector3(.21f*direction.x, .21f*direction.y, 0);
            Vector3 dir = direction;

            CastLaser(pos, dir);
        }
        //Colors
        else if (hit.collider.tag.Equals("Red Gem"))
        {
            Vector3 pos = hit.point + new Vector3(.1f * direction.x, .1f * direction.y, 0);
            Vector3 dir = direction;
            LightBeam beam = new LightBeam(pos, dir, laser.startWidth, laser.endWidth, Color.red, Color.red, laser.material, creator, "Red");
            lightStarter.laserBeams.Add(beam);
            laserIndicies.Add(hit.point);
            UpdateLaser();
        }
        else if (hit.collider.tag.Equals("Yellow Gem"))
        {
            Vector3 pos = hit.point + new Vector3(.1f * direction.x, .1f * direction.y, 0);
            Vector3 dir = direction;
            LightBeam beam = new LightBeam(pos, dir, laser.startWidth, laser.endWidth, Color.yellow, Color.yellow, laser.material, creator, "Yellow");
            lightStarter.laserBeams.Add(beam);
            laserIndicies.Add(hit.point);
            UpdateLaser();
        }
        else if (hit.collider.tag.Equals("Green Gem"))
        {
            Vector3 pos = hit.point + new Vector3(.1f * direction.x, .1f * direction.y, 0);
            Vector3 dir = direction;
            LightBeam beam = new LightBeam(pos, dir, laser.startWidth, laser.endWidth, Color.green, Color.green, laser.material, creator, "Green");
            lightStarter.laserBeams.Add(beam);
            laserIndicies.Add(hit.point);
            UpdateLaser();
        }
        else if (hit.collider.tag.Equals("Blue Gem"))
        {
            Vector3 pos = hit.point + new Vector3(.1f * direction.x, .1f * direction.y, 0);
            Vector3 dir = direction;
            LightBeam beam = new LightBeam(pos, dir, laser.startWidth, laser.endWidth, Color.blue, Color.blue, laser.material, creator, "Blue");
            lightStarter.laserBeams.Add(beam);
            laserIndicies.Add(hit.point);
            UpdateLaser();
        }
        else if (hit.collider.tag.Equals("Magenta Gem"))
        {
            Vector3 pos = hit.point + new Vector3(.1f * direction.x, .1f * direction.y, 0);
            Vector3 dir = direction;
            LightBeam beam = new LightBeam(pos, dir, laser.startWidth, laser.endWidth, Color.magenta, Color.magenta, laser.material, creator, "Magenta");
            lightStarter.laserBeams.Add(beam);
            laserIndicies.Add(hit.point);
            UpdateLaser();
        }
        else
        {
            laserIndicies.Add(hit.point);
            UpdateLaser();
        }
    }
    private void UpdateLaser()
    {
        int count = 0;
        laser.positionCount = laserIndicies.Count;

        foreach (Vector3 index in laserIndicies)
        {
            laser.SetPosition(count, index);
            count++;
        }
    }

}
