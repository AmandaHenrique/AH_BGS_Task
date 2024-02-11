using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static bool CompareDistance(Transform target, Transform origin, float min) {
        return Vector3.Distance(target.position, origin.position) <= min;
    }
}
