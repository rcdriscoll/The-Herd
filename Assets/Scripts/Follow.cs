using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    float mSpeed = 10.0f;

    //distance object follows player
    const float EPSILON = 5.0f;

    void Update()
    {
        transform.LookAt(target.position);

        if ((transform.position - target.position).magnitude > EPSILON)
        {
            transform.Translate(0.0f, 0.0f, mSpeed * Time.deltaTime);

        }
    }
}
