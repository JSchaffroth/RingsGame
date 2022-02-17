using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHeart : MonoBehaviour
{
    private int pattern;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        pattern = Random.Range(0, 4);
        //transform.GetChild(0).GetComponent<PowerupController>().setPattern(pattern);
        rb.AddForce(transform.TransformVector(0, 0, -1) * 500);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
