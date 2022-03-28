using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MG_MT_GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public MG_MT_NoteScoller theBS;

    public int score;
    public Text txtScore;
    public Text txtKeyToStart;
    public static MG_MT_GameManager instance;
    public MG_MT_ScoreController scoreController;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreController.SetHealthBar(score, 200);
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.isStart = true;
                Destroy(txtKeyToStart);

                theMusic.Play();
            }
        }
    }

    public void NoteHit(int scorePoint)
    {
        Debug.Log("Note hit one time");
        if (score == 0)
        {
            scoreController.SetHealthBar(score, 200);
        }

        score += scorePoint;
        txtScore.text = "Score: " + score;


        scoreController.SetHealthBar(score, 200);
        if (score == 50)
        {
            scoreController.turnOff_On();
        }
    }

    public void NoteMiss()
    {
        Debug.Log("Missed note");
    }
}
