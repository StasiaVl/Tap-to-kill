using UnityEngine.UI;
using UnityEngine;

public enum GameStatus
{
    menu, play, pause, gameover
}


public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject toKill;
    [SerializeField]
    private GameObject notToKill;
    [SerializeField]
    private Text playersScore;
    [SerializeField]
    private Text timeLeft;
    [SerializeField]
    private Button PauseBtn;
    [SerializeField]
    private Button PlayBtn;
    [SerializeField]
    private Button QuitBtn;
    [SerializeField]
    private Button MenuBtn;

    private int score = 0;
    private float timer;
    private GameStatus currentState = GameStatus.menu;
    public GameStatus CurrentState { get { return currentState; } }

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
        if (currentState == GameStatus.play)
        {
            timer -= Time.deltaTime;
            timeLeft.text = timer < 10 ? "Time: 0:0" + (int)timer : "Time: 0:" + (int)timer;
            if (timer <= 0)
            {
                GameOver();
            }
        }


    }

    public void AddPoints(int points)
    {
        score += points;
        playersScore.text = "Score: " + score;
    }

    public void BeginGame()
    {
        currentState = GameStatus.play;
        PlayBtn.GetComponent<Button>().interactable = false;
        PlayBtn.gameObject.SetActive(false);
        QuitBtn.GetComponent<Button>().interactable = false;
        QuitBtn.gameObject.SetActive(false);
        playersScore.text = "Score: 0";
        timeLeft.text = "Time: 1:00";
        GameObject bad = Instantiate(toKill) as GameObject;
        GameObject good = Instantiate(notToKill) as GameObject;
        timer = 60;
        score = 0;
        Destroy(bad, timer);
        Destroy(good, timer);
    }

    public void GameOver()
    {
        currentState = GameStatus.gameover;
        Debug.Log("GAME OVER");
        ToMenu();
    }

    public void ToMenu()
    {
        currentState = GameStatus.menu;
        PlayBtn.GetComponent<Button>().interactable = true;
        PlayBtn.gameObject.SetActive(true);
        QuitBtn.GetComponent<Button>().interactable = true;
        QuitBtn.gameObject.SetActive(true);

    }

    public void Pause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            currentState = GameStatus.play;
        }
        else
        {
            Time.timeScale = 0;
            currentState = GameStatus.pause;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
