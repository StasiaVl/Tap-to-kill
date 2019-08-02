using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceThing : MonoBehaviour
{
    [SerializeField]
    private float startingOfset = 0;
    [SerializeField]
    private float timeToWait = 2;
    [SerializeField]
    private float minTime = 0.2f;
    [SerializeField]
    private GameObject thing;

    private Vector2 max;
    private Vector2 min;
    private float x;
    private float y;
    private float width;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // bottom-left corner
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // top-right corner
        width = thing.GetComponent<Renderer>().bounds.size.x;
        height = thing.GetComponent<Renderer>().bounds.size.y;
        min.x += width;
        max.x -= width;
        min.y += height;
        max.y -= height;
        StartCoroutine(PutOnScreen());
    }

    //Generates objects
    IEnumerator PutOnScreen()
    {
        yield return new WaitForSeconds(startingOfset);

        do
        {
            x = Random.Range(min.x, max.x);
            y = Random.Range(min.y, max.y);
        }
        while (Physics2D.OverlapCircle(new Vector3(x, y, 8), height) != null);

        GameObject newItem = Instantiate(thing) as GameObject;
        newItem.transform.position = new Vector3(x, y, 8);
        newItem.transform.parent = transform;

        yield return new WaitForSeconds(timeToWait);    
        if (timeToWait > minTime)
            timeToWait *= 0.9f;
        
        StartCoroutine(PutOnScreen());
    }
}
