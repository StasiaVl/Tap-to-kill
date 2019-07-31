using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{
    [SerializeField]
    protected float lifeDuration = 3;

    // Start is called before the first frame update
    public virtual void Start()
    {
        Destroy(gameObject, lifeDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
