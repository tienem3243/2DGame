using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VcamConponentSetup : MonoBehaviour
{
    public PolygonCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<CinemachineConfiner>().GetComponent<CinemachineConfiner>().m_BoundingShape2D = col;
    }

}
