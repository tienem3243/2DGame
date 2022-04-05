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
        _transform = GetComponent<Transform>();
    }
    private void LateUpdate()
    {
        ShootLaser();
        
        
    }
    public void ShootLaser()
    {
        if (Physics2D.Raycast(_transform.position, transform.right))
        {
            RaycastHit2D _hit = Physics2D.Raycast(_laserFirePoint.position, transform.right);
            Draw2DRay(_laserFirePoint.position, _hit.point);
            Debug.DrawLine(_laserFirePoint.position, _hit.point);
            DealDame(dame,_hit);
        }
        else
        {
            Draw2DRay(_laserFirePoint.position, _laserFirePoint.transform.right * defDistantRay);
            Debug.DrawLine(_laserFirePoint.position, _laserFirePoint.transform.right * defDistantRay);
        }
    }
    void Draw2DRay(Vector3 startPos, Vector3 endPos)
    {
        _lineRenderer.SetPosition(0, startPos);
        _lineRenderer.SetPosition(1, endPos);
    }
    void DealDame(float dame,RaycastHit2D hit)
    {
        if (hit.collider.CompareTag("Player"))
        {
                hit.collider.GetComponent<Player>().takeDamage(dame);
  
            
        }
    }
}
