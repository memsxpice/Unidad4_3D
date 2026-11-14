using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int bestScore;
    public int currentScore;
    public int currentLevel = 0;
    public static GameManager singleton;
    
    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }else if (singleton!=this)
        {
            Destroy(gameObject);
        }

        bestScore = PlayerPrefs.GetInt("HighScore");
    }

    public void NextLevel()
    {
        currentLevel++;
        FindAnyObjectByType<BallControl>().ResetBall();
        FindAnyObjectByType<HelixController>().LoadStage(currentLevel);
        Debug.Log("Pasamos de nivel");
    }

    public void Restartlevel()
    {
        Debug.Log("Restart del nivel");
        singleton.currentScore = 0;
        FindAnyObjectByType<BallControl>().ResetBall();
        FindAnyObjectByType<HelixController>().LoadStage(currentLevel);

    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        if (currentScore>bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }

}
