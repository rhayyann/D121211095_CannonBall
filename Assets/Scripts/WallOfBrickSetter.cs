using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOfBrickSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GameManager.Instance.wallOfBricks.Add(transform);
        GameManager.Instance.fallenBrickNeeded += transform.childCount;
        GameManager.Instance.SetAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
