using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
   Transform _transform;
    public Transform _laserFirePoint;
     [Range(0,200)] [SerializeField] private float defDistantRay=100;
    public LineRenderer _lineRenderer;
    [SerializeField] float _fireDelay;
    [SerializeField] float dame;
    private void Awake()
    {
      // transform.rotation = GetComponentInParent<Transform>().rotation;
        _lineRenderer.useWorldSpace = true;
        _transform = GetComponent<Transform>();
    }
    private void LateUpdate()
    {
        ShootLaser();  
    }
    public void ShootLaser()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(_laserFirePoint.position, _laserFirePoint.right);
        if (hitInfo)
        {
            _lineRenderer.SetPosition(0, _laserFirePoint.position);
            _lineRenderer.SetPosition(1, hitInfo.point);

        }
        else
        {
            _lineRenderer.SetPosition(0, _laserFirePoint.position);
            _lineRenderer.SetPosition(1, _laserFirePoint.position + _laserFirePoint.right * defDistantRay);
        }
    }
    void DealDame(float dame,RaycastHit2D hit)
    {
        if (hit.collider.CompareTag("Player"))
        {
                hit.collider.GetComponent<Player>().takeDamage(dame);       
        }
    }
}
