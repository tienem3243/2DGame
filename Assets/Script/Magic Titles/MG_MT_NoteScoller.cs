using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_MT_NoteScoller : MonoBehaviour
{
    public float noteTempo;
    public bool isStart;
    public GameObject[] _prefab;

    public float timeWait = 0.0f;
    public float delayTime = 1.0f;
    public int countNote = 0;
    public int maxNote = 30;

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

            // Instantiate(_prefab, gameObject.transform.position, Quaternion.identity);
            // Instantiate(_prefab, new Vector3(-9, 0, 2), Quaternion.identity);

            // transform.position -= new Vector3(0f, noteTempo * Time.deltaTime, 0f);

            // waiting time
            if (Time.time > timeWait && countNote < maxNote)
            {
                int pos = Random.Range(0, 4);

                Debug.Log("Create new note at range : " + pos);

                var temp = Instantiate(_prefab[pos], new Vector3(-8 + (pos * 5), 10, 0), Quaternion.identity);
                temp.transform.parent = gameObject.transform;

                timeWait = Time.time + delayTime;
                countNote++;
            }

            gameObject.GetComponentInChildren<Transform>().position -=
                new Vector3(0f, noteTempo * Time.deltaTime, 0f);
        }
    }
}
