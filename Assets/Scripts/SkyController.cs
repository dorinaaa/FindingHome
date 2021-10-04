using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkyController : MonoBehaviour
{
    private Transform playerPosition;
    private Vector3 maxDistance;
    public GameObject[] alwaysOnScene;
   

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        maxDistance = transform.position - playerPosition.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerPosition.position + maxDistance;
        
    }
}
