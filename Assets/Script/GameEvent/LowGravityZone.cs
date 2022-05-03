using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowGravityZone : MonoBehaviour
{
    [SerializeField]
    [Tooltip("How much gravity force effect")] private float gravityForce;

    private float base_gravity;
    private void OnTriggerEnter2D(Collider2D collision)
    {
            base_gravity = collision.GetComponent<Rigidbody2D>().gravityScale;
            collision.GetComponent<Rigidbody2D>().gravityScale = -gravityForce;
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().gravityScale = base_gravity;
    }
}
