using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffset;
    private int asteroidsTimeShown = 0;
    private ParticleSystem asteroids;
    public List<GameObject> objectsInScene;

    // Start is called before the first frame update
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.frameCount > 2)
            recreateObjects();
        for (int i = 0; i < objectsInScene.Count; i++)
            rotateObjects(objectsInScene[i]);
        roatateGalaxy();
        increaseDifficulty();
        transform.position = lookAt.position + startOffset;
    }

    private void recreateObjects()
    {
        for (int i = 0; i < objectsInScene.Count; i++)
        {
           
            Renderer rend = objectsInScene[i].GetComponent<Renderer>();
            Vector3 originalScale = objectsInScene[i].transform.localScale;
            Vector3 scale = Vector3.Lerp(Vector3.zero, originalScale, Time.deltaTime * 10); ;
            if (!rend.isVisible)
            {
                if (objectsInScene[i].tag == "PS Asteroids")
                {
                   
                    asteroidsTimeShown += 1;
                    Vector3 replaceas = objectsInScene[i].transform.position;
                    replaceas.z = objectsInScene[i].transform.position.z + 500f;
                    objectsInScene[i].transform.position = replaceas;

                } else
                {
                    Vector3 replace = objectsInScene[i].transform.position;
                    replace.z = objectsInScene[i].transform.position.z + 200f;
                    objectsInScene[i].transform.position = replace;
                    //objectsInScene[i].transform.localScale = Vector3.zero;
                }

            }
        }
    }

    private void rotateObjects(GameObject game)
    {

        if (game.tag != "PS Asteroids")
            game.transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
    }

    private void roatateGalaxy()
    {
        
            GameObject.FindGameObjectWithTag("Large Galaxy").
            transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime * 0.08f);
    }

    private void increaseDifficulty()
    {
        GameObject ps = GameObject.FindGameObjectWithTag("PS Asteroids");
        asteroids = ps.GetComponent<ParticleSystem>();
        var main = asteroids.main;

        if (asteroidsTimeShown <= 1)
        {
            main.maxParticles = 100;
        }
        else if (asteroidsTimeShown == 2)
        {
            //ps.transform.Rotate(new Vector3(0, 0, -30) * Time.deltaTime);
            main.maxParticles = 200;
            main.startSize = 700;
        }
        else if (asteroidsTimeShown == 3)
        {
            ps.transform.Rotate(new Vector3(0, 0, -30) * Time.deltaTime);
        }
        else if (asteroidsTimeShown == 4)
        {
            ps.transform.Rotate(new Vector3(0, 0, -30) * Time.deltaTime * 3);
        } else
        {
            main.maxParticles = 300;
            var newScale = ps.transform.localScale;
            newScale.x = 20;
            newScale.y = 10;
            newScale.z = 25;
            ps.transform.localScale = newScale; 
            ps.transform.Rotate(new Vector3(0, 0, -30) * Time.deltaTime * 3);
        } 
    }
}
