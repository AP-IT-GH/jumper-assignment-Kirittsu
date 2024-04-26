using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Jumper agent;

    public float xSpeed;
    public float zSpeed;
    public float rotation;

    //When object get initialized
    void Awake()
    {
        agent = GameObject.Find("Agent").GetComponent<Jumper>();

        this.transform.localRotation = Quaternion.Euler(0, rotation, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.localPosition += new Vector3(xSpeed, 0, zSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Agent")
        {
            agent.Hit();
            Destroy(this.gameObject);
        }
        if (other.tag == "Wall")
        {
            agent.Reward();
            Destroy(this.gameObject);
        }
    }
}
