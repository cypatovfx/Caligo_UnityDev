using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    Lucio lucio;

    private void Awake()
    {
        lucio = GameObject.Find("Lucio").GetComponent<Lucio>();


    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lucio.isDead)
        {
            Destroy(gameObject);
        }
    }


    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.x -= lucio.velocity.x * Time.fixedDeltaTime;
        if (pos.x < -100)
        {
            Destroy(gameObject);
        }

        transform .position = pos;

    }
}
