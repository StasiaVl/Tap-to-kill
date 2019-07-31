using UnityEngine;

public class Ally : Thing
{
    [SerializeField]
    private int points = -200;

    public void Awake()
    {
        costOfTap = points;
    }
}
