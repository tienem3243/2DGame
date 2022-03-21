using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [Tooltip("Vcam you want to controll")]
    public CinemachineVirtualCamera vcam;
    [Tooltip("Main target")]
    public Transform FocusPoint; //main target cammera
    [Tooltip("Forcus target you need to zoom")] 
    public Transform ZoomTarget; // target that make camera zoom when main target going to near it
    //this is distance of two target
    private float distance;
    [Tooltip("Minimum value fov can reach")]
    [SerializeField] float MinFOV;
    [Tooltip("Maximum value fov can reach")]
    [SerializeField] float MaxFOV;
    [Tooltip("Base fov")]
    [SerializeField] float _FOV;
    private void Start()
    {
        Debug.Log(vcam.m_Lens.FieldOfView);
        //set up field of view
        vcam.m_Lens.FieldOfView = _FOV;
    }
    private void Update()
    {
        //measure distance
        distance = Vector2.Distance(FocusPoint.position, ZoomTarget.position);
        CameraZoomBaseOn(distance);
        //todo alway look at zoomdistance

    }
    public void CameraZoomBaseOn(float distance)
     {
        Debug.Log(" distance " + distance + " " + "fov" + vcam.m_Lens.FieldOfView);
       float ZoomVar= _FOV* distance / 20f;//The recipe that callculate next FOV value
        if (ZoomVar >= MinFOV&& ZoomVar <= MaxFOV)
        {
            vcam.m_Lens.FieldOfView = ZoomVar;
        }
     
    
    }
}
