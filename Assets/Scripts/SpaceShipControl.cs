using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipControl : MonoBehaviour
{
    private CharacterController controller;
    public float speed;

    private Vector3 levizja;
    private float maxRight = 20.0f;
    private float maxLeft = -20.0f;
    private float maxUp = 20.0f;
    private float maxDown = -20.0f;

    private bool fund = false;

    private GameObject[] planets;

    // Start is called before the first frame update
    void Start()
    {

        controller = GetComponent<CharacterController>();
        planets = GameObject.FindGameObjectsWithTag("Planet");
    }

    // Update is called once per frame
    void Update()
    {
        if (fund)
            return;

        levizja = Vector3.zero;
        levizja.x = Input.GetAxis("Horizontal");
        levizja.y = Input.GetAxis("Vertical");
        levizja.z = 1.0f;
        setBoundaries();
        controller.Move(levizja * speed * Time.deltaTime);
        rotateShip();

    }

    private void setBoundaries()
    {
        if (transform.position.x > maxRight)
        {
            levizja.x = -0.1f;
        }
        else if (transform.position.x < maxLeft)
        {
            levizja.x = 0.1f;
        }

        if (transform.position.y > maxUp)
        {
            levizja.y = -0.1f;
        }
        else if (transform.position.y < maxDown)
        {
            levizja.y = 0.1f;
        }
    }

    private void rotateShip()
    {


        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(40.0f, 180.0f, 0.0f), Time.deltaTime * 2);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0.0f, 180.0f, 0.0f), Time.deltaTime * 2);

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(30.0f, 150.0f, 0.0f), Time.deltaTime * 2);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(30.0f, 210.0f, 0.0f), Time.deltaTime * 2);
        }
    }

    private void OnParticleCollision(GameObject particle)
    {

        fund = true;
    }

    public bool TheEnd()
    {
        return fund;
    }
}
