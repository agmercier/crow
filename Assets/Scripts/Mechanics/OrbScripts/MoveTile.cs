using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTile : MonoBehaviour
{

    public Transform target;
    public float speed;
    public bool move;

    void Start()
    {
        move = false;
    }
    void FixedUpdate()
    {
        if (transform.position != target.position && move)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().MovePosition(pos);
        }
      
    }
}
