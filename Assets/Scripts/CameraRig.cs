using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float followSmoothing;



    // Update is called once per frame
    void FixedUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {

        transform.position = Vector2.Lerp(transform.position, target.position, followSmoothing * Time.deltaTime);

    }
}
