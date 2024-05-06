using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform heroTransform;
    public Vector3 offset;
    private void LateUpdate()
    {
        transform.position = heroTransform.position + offset;
    }
}
