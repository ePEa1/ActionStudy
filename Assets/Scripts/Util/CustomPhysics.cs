using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPhysics : MonoBehaviour
{
    public static Vector3 FixedMoveVector(Vector3 startPos, Vector3 ray, LayerMask layer)
    {
        Vector3 center = new Vector3(startPos.x, 0.0f, startPos.z);
        Vector3 dir = ray.normalized;
        float dis = Vector3.Distance(Vector3.zero, ray);

        Vector3 fixedPos = startPos + ray;
        RaycastHit hit;
        if (Physics.Raycast(startPos, dir, out hit, dis, layer))
        {
            Vector3 hitPoint = new Vector3(hit.point.x, 0.0f, hit.point.z);
            Vector3 normal = new Vector3(hit.normal.x, 0.0f, hit.normal.z).normalized;
            float overDis = dis - Vector3.Distance(center, hitPoint);

            fixedPos = startPos + ray + normal * (overDis * Vector3.Dot(-dir, normal) + 0.01f);

            if (Physics.Raycast(startPos, (fixedPos - startPos).normalized, Vector3.Distance(startPos, fixedPos - startPos), layer))
            {
                fixedPos = FixedMoveVector(startPos, fixedPos - startPos, layer);
            }
        }

        return fixedPos;
    }
}
