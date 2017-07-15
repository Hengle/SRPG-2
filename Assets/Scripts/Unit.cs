using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public Vector3 destination;

    public GameObject hexDistance;
    public GameObject currentHex;

    public int moveDistance;
    public float speed;


    // Use this for initialization
    void Start()
    {
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {       
        Vector2 dir = destination - transform.position;
        Vector2 velocity = dir.normalized * speed * Time.deltaTime;

        // Make sure the velocity doesn't actually exceed the distance we want.
        velocity = Vector2.ClampMagnitude(velocity, dir.magnitude);

        transform.Translate(velocity);
    }
}
