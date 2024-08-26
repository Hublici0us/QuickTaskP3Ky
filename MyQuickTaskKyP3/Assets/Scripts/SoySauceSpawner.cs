using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoySauceSpawner : MonoBehaviour
{
    public GameObject soySauce;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnSauce", 2, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnSauce()
    {
        Instantiate(soySauce, new Vector3(Random.Range(-22, 30), 45, 0), Quaternion.identity);
    }
}
