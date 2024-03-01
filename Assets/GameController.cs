using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text restartButtonText;
    public float restartDelay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        // Set the restart button text after a delay
        StartCoroutine(SetRestartButtonText());
    }

    IEnumerator SetRestartButtonText()
    {
        yield return new WaitForSeconds(restartDelay);

        string[] messages = {
            "Please Restart??",
            "What are you scared of?",
            "Pipes got you pressed?",
            "Just press the button!",
        };

        while (true)
        {
            foreach (string message in messages)
            {
                restartButtonText.text = message;
                yield return new WaitForSeconds(restartDelay);
                restartDelay -= 0.1f; // Decrease restart delay each loop
            }
        }
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
