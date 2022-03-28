using UnityEngine;
using UnityEngine.UI;

public class MG_GameManager : MonoBehaviour
{

    public AudioSource theMusic;

    [SerializeField]
    private bool _startPlaying;
    [SerializeField]
    private MG_Scoller _scoller;



    [SerializeField]
    private int score;
    public Text txtScore;
    // public static MG_GameManager instance;



    [Header("Display at start")]
    public Text _txtKeyToStart;
    public Image _imageToStart;

    private void Start()
    {
        Time.timeScale = 0;
        _startPlaying = false;

        // instance = this;
        // _score = 0;
    }

    private void Update()
    {
        if (!_startPlaying)
        {
            if (Input.anyKeyDown)
            {
                // start scroll 
                _startPlaying = true;
                _scoller.setIsStart(true);

                // start game
                Time.timeScale = 1;
                theMusic.Play();

                // Destroy Obj dont need
                Destroy(_txtKeyToStart);
                Destroy(_imageToStart);
            }
        }
    }

    public void Hit(int scorePoint)
    {
        Debug.Log("Note hit one time");
        // if (score == 0)
        // {
        // scoreController.SetHealthBar(score, 200);
        // }

        // score += scorePoint;
        // txtScore.text = "Score: " + score;


        // scoreController.SetHealthBar(score, 200);
        // if (score == 50)
        // {
        // scoreController.turnOff_On();
        // }
    }

    public void Missed()
    {
        Debug.Log("Missed note");
    }
}
