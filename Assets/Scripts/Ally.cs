using UnityEngine;

public class Ally : Thing
{
    private int points = -100;

    public void Awake()
    {
        costOfTap = points;
    }
}
