using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathController : MonoBehaviour
{
    public Animator _animator;
    public Transform[] waypoints;
    private int _currentWaypointIndex = 0;

    [SerializeField]
    private float _speed = 5f;

    [SerializeField]
    private float _waitTime = 1f; // in seconds
    private float _waitCounter = 0f;
    private bool _waiting = false;

    private bool m_FacingRight = true;  // For determining which way the player is currently facing.

    private void OnDrawGizmosSelected()
    {
       for(int i=0;i<waypoints.Length-1;i++)
        {
            Debug.DrawLine(waypoints[i].position,waypoints[i+1].position,Color.green);
        }
    }
    private void Update()
    {
        
        
        if (waypoints.Length > 0)
        {
            if (_waiting)
            {
                _waitCounter += Time.deltaTime;
                if (_waitCounter < _waitTime)
                    return;
                _waiting = false;
                _animator.SetBool("IsRun", true);
            }

            Transform wp = waypoints[_currentWaypointIndex];
            if (Vector3.Distance(transform.position, wp.position) < 0.01f)
            {
                transform.position = wp.position;
                _waitCounter = 0f;
                _waiting = true;

                _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;

                _animator.SetBool("IsRun", false);
                Flip();

            }
            else
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    wp.position,
                    _speed * Time.deltaTime);



                // for 3D
                // transform.LookAt(wp.position);
            }
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
