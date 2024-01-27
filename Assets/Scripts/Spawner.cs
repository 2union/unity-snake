using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void Spawn(GameObject obj)
    {
        Bounds bounds = this.gameObject.GetComponent<BoxCollider2D>().bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        
        Instantiate(obj, new Vector3(Mathf.Round(x), Mathf.Round(y), 0), Quaternion.identity);
    }
}
