using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public Transform target,orgin;
    public GameObject balls;
    public float timer,ti;

    void Start()
    {
    }


    void Update()
    {
    

        Vector3 vo = calculateThrow(target.position, orgin.position);
        transform.rotation = Quaternion.LookRotation(vo);
        timer -= Time.deltaTime;
        if (timer<0)
        {
            Rigidbody ball = Instantiate(balls, orgin.position, Quaternion.identity).GetComponent<Rigidbody>();

            ball.velocity = vo;
            timer = ti;
        }
    }




    Vector3 calculateThrow(Vector3 target, Vector3 orgin)
    {
        Vector3 dist = target - orgin;
        Vector3 distaneXZ = dist;
        distaneXZ.y = 0;

        float sy = dist.y;
        float sxz = distaneXZ.magnitude;

        float vxz = sxz/1;
        float vy = sy / 1 + .5f * Mathf.Abs(Physics.gravity.y);

        Vector3 result = distaneXZ.normalized;
        result *= vxz;
        result.y = vy;
        return result;

    }
}
