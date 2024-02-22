using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveMove : MonoBehaviour
{

    private float interpolateAmount;
    [SerializeField] private Transform pointA, pointB, pointC, projectile;
    void Update()
    {
        interpolateAmount = (interpolateAmount + Time.deltaTime) % 1;
        projectile.position = QuadraticLerp(pointA.position, pointB.position, pointC.position, interpolateAmount);
    }

    private Vector3 QuadraticLerp(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        Vector3 ab = Vector3.Lerp(a, b , t);
        Vector3 bc = Vector3.Lerp(b, c, t);

        return Vector3.Lerp(ab, bc, t);
    }
}
