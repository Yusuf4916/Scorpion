using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScorpionTail : MonoBehaviour
{
    public Transform player,tail;
    private float dist, timer;


    private void FixedUpdate()
    {
        dist = Vector3.Distance(player.position, tail.transform.position);
        timer += Time.deltaTime;
        if (dist < 13 )
        {
            if (timer > 3)
            {
                Attack();
                timer = 0;
            }
            
        }
        else
        {
            transform.position = tail.position;
        }
    }

    private void Attack()
    {
        transform.parent = null;
        transform.DOMove(player.position, .5f).OnComplete(()=> {
            transform.DOMove(tail.position, .5f);
            transform.parent = tail;
            
        });
       
    }
}
