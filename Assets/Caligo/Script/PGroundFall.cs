using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGroundFall : MonoBehaviour
{

    bool isFalling = false;
    public float fallSpeed = 1;

    public Lucio lucio;
    public List<Obstacles> obstacles = new List<Obstacles>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
        if(isFalling)
        {
            Vector2 pos = transform.position;
            float fallAmount = fallSpeed * Time.fixedDeltaTime;
            pos.y -= fallAmount;

            if(lucio != null)
            {
                lucio.groundHeight -= fallAmount;
                Vector2 lucioPos = lucio.transform.position;
                lucioPos.y -= fallAmount;
                lucio.transform.position = lucioPos;
            }

            foreach(Obstacles obstacles in obstacles)
            {
                if (obstacles != null)
                {

                }
                Vector2 obstaclesPos = obstacles.transform.position;
                obstaclesPos.y -= fallAmount;
                obstacles.transform.position = obstaclesPos;
            }
                transform.position = pos;
        }

        else
        {
            if(lucio != null)
            {
                isFalling = true;
            }
        }

    }
}
