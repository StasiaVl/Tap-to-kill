using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : Thing
{
    private void OnMouseDown()
    {
        GameManager.instance.Attack();
        Destroy(gameObject);
    }
}
