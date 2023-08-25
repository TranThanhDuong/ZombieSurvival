using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour
{
    public Func<Vector3> getCameraFollowPosition;
    public float cameraMoveSpeed = 1f;
    public Transform target;
    public Vector3 offset;
    private Transform trans;
    // Update is called once per frame
    private void Start()
    {
        trans = transform;
        offset = trans.position - target.position;
    }
    private void LateUpdate()
    {
        trans.position = Vector3.Lerp(trans.position, target.position + offset, Time.deltaTime * 3f);
    }
}
