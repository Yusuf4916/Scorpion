using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class legPositionNew : MonoBehaviour
{
    public LayerMask mask;
    private void Update()
    {
        if (Physics.Raycast(transform.position,transform.forward,out RaycastHit hit,10,mask))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance,Color.black);

        }
    }

}
