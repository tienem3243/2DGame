using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabShoot : MonoBehaviour
{
    Transform _transform;
    public Transform _firepoint;
    [Range(0, 200)] [SerializeField] private float defDistantRay = 100;
    public LineRenderer _lineRenderer;
    [SerializeField] float _fireDelay;
    [SerializeField] float dame;
    [SerializeField] float sensivityRange;
    [SerializeField] LayerMask targetLayer;
    private void OnDrawGizmosSelected()
    {
        if (_firepoint != null)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(_firepoint.gameObject.transform.position, sensivityRange);
        }
    }
    private void Awake()
    { 
        _lineRenderer.useWorldSpace = true;
        _transform = GetComponent<Transform>();
    }
    private void Update()
    {
        DetectShoot();
    }
    public void Performshoot(Transform direction)
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(_firepoint.position, direction.position,defDistantRay);
            _lineRenderer.SetPosition(0, _firepoint.position);
            _lineRenderer.SetPosition(1, direction.position);
        Debug.DrawLine(_firepoint.position, direction.position);
        Debug.Log(hitInfo.collider.tag);
        StartCoroutine(ClearLine());
    }
    public void DetectShoot()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(_firepoint.position, sensivityRange,targetLayer);
        if(cols!=null)
        foreach(Collider2D col in cols)
        {
            if (col.CompareTag("Player"))
            {
                Performshoot(cols[0].GetComponent<Transform>());
            }
           
        }
       
    }
    void DealDame(float dame, RaycastHit2D hit)
    {
        if (hit.collider.CompareTag("Player"))
        {
            hit.collider.GetComponent<Player>().takeDamage(dame);
        }
    }
    IEnumerator ClearLine()
    {
        yield return new WaitForSeconds(0.5f);
        _lineRenderer.SetPosition(0,_firepoint.position);
        _lineRenderer.SetPosition(1,_firepoint.position);
    }
}
