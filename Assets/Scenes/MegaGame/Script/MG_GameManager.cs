using UnityEngine;
using UnityEngine.UI;

public class MG_GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _startPlaying;
    [SerializeField]
    private MG_Scoller _scoller;
    // [SerializeField]
    // private int _score;

    [Header("Display at start")]
    public Text _txtKeyToStart;
    public Image _imageToStart;

    private void Start()
    {
        Time.timeScale = 0;
        _startPlaying = false;
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

                // Destroy Obj dont need
                Destroy(_txtKeyToStart);
                Destroy(_imageToStart);
            }
        }
    }

}
