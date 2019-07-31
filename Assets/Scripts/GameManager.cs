using UnityEngine.UI;
using UnityEngine;

public enum GameStatus
{
    menu, play, gameover
}


public class GameManager : MonoBehaviour
{
    private int lifes = 3;

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
        
    }

    public void Attack()
    {
        if (--lifes == 0)
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
