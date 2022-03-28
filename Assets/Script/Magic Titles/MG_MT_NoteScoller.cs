using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_MT_NoteScoller : MonoBehaviour
{
    public float noteTempo;
    public bool isStart;

    // Start is called before the first frame update
    void Start()
    {
        noteTempo /= 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            //     if (Input.anyKeyDown)
            //     {
            //         isStart = true;
            //     }
            // }
            // else
            // {
            transform.position -= new Vector3(0f, noteTempo * Time.deltaTime, 0f);
        }
    }
}
