using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class legPos : MonoBehaviour
{
    public Transform  orgin, spiderBody;
    private Vector3 target;
    public int rayDist;
    public LayerMask layer;
    public float distRange,distance;

    void Start()
    {
        orgin = GetComponent<Transform>();

    }

   

    void Update()
    {

        target = spiderBody.position;
    }
    private void FixedUpdate()
    {
        distance = Vector3.Magnitude(transform.position - target);
        if (distance>distRange)
        {
            goNewPos();
        }
    }

    public void goNewPos()
    {
        Vector3 orgPos= (target - orgin.position);
        Vector3 midPos = (orgPos/2) + orgin.position;
        midPos.y =1.5f;
        transform.DOMove(midPos, .4f).OnComplete(() => {
            transform.DOMove(target, .4f).OnComplete(() => {
                orgin.position = target;
                target = newTargetPos();
            });
        });
       
    }




    public Vector3 newTargetPos()
    {
        Vector3 newTarget;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.forward,out hit,rayDist,layer))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.black);
            if (hit.collider.gameObject.tag=="circle")
            {
                spiderBody.position = hit.point;
                Debug.Log(hit.point);
            }
        }
      
        newTarget = spiderBody.position;



        return newTarget;
    }


}
