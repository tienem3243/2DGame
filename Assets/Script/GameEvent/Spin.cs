using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [Range(90,360)]
    public float speed=90f;
    public Transform target;
    private Rigidbody2D _rig;
    public Transform owner;
    // Update is called once per frame
    void Update()
    {
        if(target!=null)
        transform.position = Vector2.MoveTowards(transform.position, target.position, 0.1f);
        transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
        
    }
}
