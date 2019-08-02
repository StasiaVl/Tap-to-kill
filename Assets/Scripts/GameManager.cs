using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;

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
    private GameObject tutorail;
    [SerializeField]
    private Text playersScore;
    [SerializeField]
    private Text timeLeft;
    [SerializeField]
    private Text finTxt;
    [SerializeField]
    private Button PauseBtn;
    [SerializeField]
    private Button ResumeBtn;
    [SerializeField]
    private Button PlayBtn;
    [SerializeField]
    private Button RestartBtn;
    [SerializeField]
    private Button QuitBtn;
    [SerializeField]
    private Button MenuBtn;

    private int score = 0;
    private float timer;
    private GameObject bad;
    private GameObject good;
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

        NetworkManager.singleton.StartServer();
    }

    // Use this for initialization
    void Start()
    {
        NetworkManager.singleton.StartClient();
        if (NetworkManager.singleton.client != null)
            ToMenu();
        else
            Debug.Log("ERROR: No client");
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
        Time.timeScale = 1;
        if (bad != null)
            Destroy(bad);
        if (good != null)
            Destroy(good);
        tutorail.SetActive(false);
        PlayBtn.gameObject.SetActive(false);
        QuitBtn.gameObject.SetActive(false);
        MenuBtn.gameObject.SetActive(false);
        RestartBtn.gameObject.SetActive(false);
        ResumeBtn.gameObject.SetActive(false);
        PauseBtn.gameObject.SetActive(true);
        playersScore.text = "Score: 0";
        timeLeft.text = "Time: 1:00";
        finTxt.text = "";
        bad = Instantiate(toKill) as GameObject;
        good = Instantiate(notToKill) as GameObject;
        timer = 60;
        score = 0;
        Destroy(bad, timer);
        Destroy(good, timer);
    }

    public void GameOver()
    {
        currentState = GameStatus.gameover;
        playersScore.text = "";
        timeLeft.text = "";
        finTxt.text = "Time is out!\nYour score is " + score;
        PauseBtn.gameObject.SetActive(false);
        MenuBtn.gameObject.SetActive(true);
        RestartBtn.gameObject.SetActive(true);
    }

    public void ToMenu()
    {
        currentState = GameStatus.menu;
        if (bad != null)
            Destroy(bad);
        if (good != null)
            Destroy(good);
        PlayBtn.gameObject.SetActive(true);
        QuitBtn.gameObject.SetActive(true);
        ResumeBtn.gameObject.SetActive(false);
        MenuBtn.gameObject.SetActive(false);
        RestartBtn.gameObject.SetActive(false);
        tutorail.SetActive(true);
        playersScore.text = "";
        timeLeft.text = "";
        finTxt.text = "";
    }

    public void Pause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            currentState = GameStatus.play;
            ResumeBtn.gameObject.SetActive(false);
            MenuBtn.gameObject.SetActive(false);
            RestartBtn.gameObject.SetActive(false);
            PauseBtn.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 0;
            currentState = GameStatus.pause;
            ResumeBtn.gameObject.SetActive(true);
            MenuBtn.gameObject.SetActive(true);
            RestartBtn.gameObject.SetActive(true);
            PauseBtn.gameObject.SetActive(false);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
