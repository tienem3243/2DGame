using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CamaraZoomOut : MonoBehaviour
{
    public CinemachineVirtualCamera _cam;
    public float _size = 10.0f;
    public float defaultSize = 5.0f;

    public float _sceneY = 1.0f;
    public float defaultSceneY = 0.65f;

    public bool _isStart = false;
    // public bool _isInRange = false;
    private void Start()
    {
        _cam = FindObjectOfType<CinemachineVirtualCamera>();
    }
    private void Update()
    {
        if (_isStart)
        {
            // change Camera size : zoom out
            if (_cam.m_Lens.OrthographicSize <= _size)
            {
                if (_cam.m_Lens.OrthographicSize >= _size - 0.1f)
                {
                    _cam.m_Lens.OrthographicSize = _size;
                }
                else
                {
                    _cam.m_Lens.OrthographicSize += Time.deltaTime;
                }
            }

            // make camera move up : Pos Y

            if (_cam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY <= _sceneY)
            {
                // _cam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY +=
                if (_cam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY >= _sceneY - 0.1f)
                {
                    _cam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = _sceneY;
                }
                else
                {
                    _cam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY += Time.deltaTime;
                }
            }

        }
        else
        {
            if (_cam.m_Lens.OrthographicSize >= defaultSize)
            {
                _cam.m_Lens.OrthographicSize -= Time.deltaTime;
            }
            if (_cam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY >= defaultSceneY)
            {
                _cam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        { _isStart = true; }
        // { cam.m_Lens.OrthographicSize = size; }
        // { cam.m_Lens.OrthographicSize}
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        { _isStart = false; }
        // { _cam.m_Lens.OrthographicSize = 5; }
    }
}
