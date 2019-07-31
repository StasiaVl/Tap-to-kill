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

    // Start is called before the first frame update
    void Start()
    {
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // bottom-left corner
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // top-right corner
        min.x += thing.GetComponent<Renderer>().bounds.size.x;
        max.x -= thing.GetComponent<Renderer>().bounds.size.x;
        min.y += thing.GetComponent<Renderer>().bounds.size.y;
        max.y -= thing.GetComponent<Renderer>().bounds.size.y;
        StartCoroutine(PutOnScreen());
    }

    //Generates objects
    IEnumerator PutOnScreen()
    {
        yield return new WaitForSeconds(startingOfset);

        GameObject newItem = Instantiate(thing) as GameObject;
        newItem.transform.position = new Vector2(UnityEngine.Random.Range(min.x, max.x), 
                                                    UnityEngine.Random.Range(min.y, max.y));
        newItem.transform.parent = transform;

        yield return new WaitForSeconds(timeToWait);
        if (timeToWait > minTime)
            timeToWait *= 0.9f;
        StartCoroutine(PutOnScreen());
    }
}
