using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spider : MonoBehaviour
{
    public Transform player;

    void Start()
    {

    }

    void Update()
    {
        transform.LookAt(new Vector3(-player.position.x+3,transform.position.y,-player.position.z));
    }
}
