using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTrap : MonoBehaviour
{
   Transform _transform;
    public Transform _laserFirePoint;
     [Range(0,200)] [SerializeField] private float defDistantRay=100;
    public LineRenderer _lineRenderer;

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
        }
        else
        {
            Draw2DRay(_laserFirePoint.position, _laserFirePoint.transform.right * defDistantRay);
        }
    }
    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        _lineRenderer.SetPosition(0, startPos);
        _lineRenderer.SetPosition(1, endPos);
    }
}
