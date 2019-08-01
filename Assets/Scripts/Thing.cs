using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{
    [SerializeField]
    protected float lifeDuration = 3;

    protected int costOfTap;

    // Start is called before the first frame update
    public virtual void Start()
    {
        Destroy(gameObject, lifeDuration);
    }

    private void OnMouseDown()
    {
        if (GameManager.instance.CurrentState.Equals(GameStatus.play))
        {
            GameManager.instance.AddPoints(costOfTap);
            Destroy(gameObject);
        }
        
    }
}
