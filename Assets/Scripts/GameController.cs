using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public int score = 0;
    public UnityEngine.UI.Text scoreText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            score++;
            Destroy(other.gameObject);
            UpdateScoreUI();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}