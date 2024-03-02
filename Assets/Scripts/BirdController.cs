using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameController gameController;
    public GameObject gunPrefab;
    public float timeBetweenShots = 0.5f;
    private float timeOfLastShot = 0;
    public Text scoreText;
    public Text highScoreText;
    public int score = 0;
    private int highScore;

    public float flapForce = 5;
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * flapForce;
        }
        // Shoot the gun when the player presses Fire3
        if (Input.GetButtonDown("Fire3") && Time.time > timeOfLastShot + timeBetweenShots)
        {
            ShootGun();
            timeOfLastShot = Time.time;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Pipe"))
        {
            Destroy(gameObject);
            gameController.GameOver();
        }
        else if (collision.gameObject.CompareTag("ScoreZone"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            IncrementScore();
        }
    }
        // Call this method when the bird clears a pipe
    public void IncrementScore()
    {
        score++;
        UpdateScoreText();
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            UpdateHighScoreText();
        }
    }
    public void DecreaseScore()
    {
        score--;
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        scoreText.text = "  Score: " + score;
    }
    private void UpdateHighScoreText()
    {
        highScoreText.text = "  High Score: " + highScore;
        Debug.Log(highScoreText.text);
    }
    private void ShootGun()
    {
        Instantiate(gunPrefab, transform);
    }
}
