using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeam
{
    public GameObject laserObj;
    private LineRenderer laser;
    private List<Vector3> laserIndicies = new List<Vector3>();


    public LightBeam(Vector3 pos, Vector3 dir, float startWidth, float endwith, Color startColor, Color endColor, Material material)
    {
        laser = new LineRenderer();
        laserObj = new GameObject();
        laserObj.name = "Laser Beam";

        laser = this.laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        laser.startWidth = startWidth;
        laser.endWidth = endwith;
        laser.startColor = startColor;
        laser.endColor = endColor;
        laser.material = material;

        CastLaser(pos, dir);

        
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

    private void ChangeColor(Color color)
    {
        laser.endColor = color;
        laser.startColor = color;
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
            Vector3 pos = hit.point + new Vector3(.2f*direction.x, .2f*direction.y, 0);
            Vector3 dir = direction;

            CastLaser(pos, dir);
        }
        else if (hit.collider.tag.Equals("Blue Gem"))
        {
            ChangeColor(Color.blue);
            Debug.Log("Blued");
            Vector3 pos = hit.point + new Vector3(1f * direction.x, 1f * direction.y, 0);
            Vector3 dir = direction;

            CastLaser(pos, dir);
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
