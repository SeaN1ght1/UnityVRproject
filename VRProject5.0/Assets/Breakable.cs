using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public List<GameObject> breakablePieces;

    void Start()
    {
        foreach(var item in breakablePieces)
        {
            item.SetActive(false);
        }
    }

    // Update is called once per frame
    public void Break()
    {
        foreach(var item in breakablePieces)
        {
            item.SetActive(true);
            item.transform.parent = null;
        }

        gameObject.SetActive(false);
    }
}
