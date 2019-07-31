using UnityEngine.UI;
using UnityEngine;

public enum GameStatus
{
    menu, play, gameover
}


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text playersScore;
    
    private int score = 0;

    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        playersScore.text = "Score: " + score;
    }

    public void AddPoints(int points)
    {
        score += points;
        Debug.Log(score);
        if (score < 0)
            GameOver();
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
