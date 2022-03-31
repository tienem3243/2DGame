using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcadeTrigger : MonoBehaviour
{
    [SerializeField] string nameGame;
    [SerializeField] bool isPlaying;
    private void Start()
    {
        isPlaying = false;
    }
    private void Update()
    {
        if (isPlaying&& Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene(nameGame);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlaying = !isPlaying;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlaying = !isPlaying;
        }
    }

}
