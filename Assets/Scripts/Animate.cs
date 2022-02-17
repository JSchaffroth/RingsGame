using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    private int pattern;
    private float initx;
    private float inity;

    // Start is called before the first frame update
    void Start()
    {
        initx = transform.position.x;
        inity = transform.position.y;
        this.transform.position = new Vector2(initx, inity);
        pattern = Random.Range(0, 4);
        transform.GetChild(0).GetComponent<RingAI>().setPattern(pattern);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -10)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
