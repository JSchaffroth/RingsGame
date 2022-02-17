using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometController : MonoBehaviour
{
    public Rigidbody rb;
    public int speed;
    private float initx;
    private float inity;

    // Start is called before the first frame update
    void Start()
    {
        initx = transform.position.x;
        inity = transform.position.y;
        speed = 5;
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(-50, 50, 0);
        rb.AddForce(transform.TransformVector(-initx, -inity, 0) * 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            AudioManager.instance.playSound("Crash");
            Destroy(gameObject);
        }
    }

}
