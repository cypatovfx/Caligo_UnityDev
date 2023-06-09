using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{

    float depth = 8;

    Lucio lucio;

    private void Awake() 
    {
       lucio = GameObject.Find("Lucio").GetComponent<Lucio>();

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float realVelocity = lucio.velocity.x / depth;
        Vector2 pos = transform.position;

        pos.x -= realVelocity * Time.fixedDeltaTime;

        if (pos.x <= -25)
            pos.x = 20;

        transform.position = pos;
    }
}
