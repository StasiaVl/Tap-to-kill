using UnityEngine;

public class Enemy : Thing
{
    private int pointsTap = 30;
    private int pointsNot = -50;

    private float timer;
    
    public void Awake()
    {
        timer = lifeDuration;
        costOfTap = pointsTap;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= Time.deltaTime)
        {
            GameManager.instance.AddPoints(pointsNot);
        }
    }
}
