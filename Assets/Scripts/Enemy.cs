using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Thing
{

    private float timer;

    // Start is called before the first frame update
    public override void Start()
    {
        timer = lifeDuration;    
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            GameManager.instance.Attack();
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
