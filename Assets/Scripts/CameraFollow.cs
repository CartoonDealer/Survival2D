using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Vector3 offset;

    private void LateUpdate()
    {
        transform.position = targetTransform.position + offset;
    }
}
