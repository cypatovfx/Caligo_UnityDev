using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGround : MonoBehaviour
{
    Lucio lucio;

    public float groundHeight;
    public float groundRight;
    public float screenRight;
    new BoxCollider2D collider;

    bool didGenerateGround = false;

    public Obstacles boxTemplate;

    private void Awake()
    {
        lucio = GameObject.Find("Lucio").GetComponent<Lucio>();


        collider = GetComponent<BoxCollider2D>();
        screenRight = Camera.main.transform.position.x * 1;

    }





    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        groundHeight = transform.position.y + (collider.size.y / 2);
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.x -= lucio.velocity.x * Time.fixedDeltaTime;



        groundRight = transform.position.x + (collider.size.x / 2);

        if (groundRight < 0)
        {
           //  Destroy(gameObject);
           //  return;
        }


        if(lucio.isDead)
        {
            Destroy(gameObject);
        }

        if (!didGenerateGround)
        {


            if (groundRight < screenRight)
            {
                didGenerateGround = true;
                generateGround();
            }
        }

        transform.position = pos;
    }


    void generateGround()
    {
        GameObject go = Instantiate(gameObject);
        BoxCollider2D goCollider = go.GetComponent<BoxCollider2D>();
        Vector2 pos;

        float h1 = lucio.jumpVelocity * lucio.maxHoldJumpTime;
        float t = lucio.jumpVelocity / -lucio.gravity;
        float h2 = lucio.jumpVelocity * t + (0.5f * (lucio.gravity * (t * t)));
        float maxJumpHeight = h1 + h2;
        float maxY = maxJumpHeight * 0.7f;
        maxY += groundHeight;
        float minY = 1;
        float actualY = Random.Range(minY, maxY);



        pos.y = actualY - goCollider.size.y / 2;
        if (pos.y > 2.5f)
            pos.y = 2.5f;

        float t1 = t + lucio.maxHoldJumpTime;
        float t2 = Mathf.Sqrt((2.0f * (maxY - actualY)) / -lucio.gravity);
        float totalTime = t1 + t2;
        float maxX = totalTime * lucio.velocity.x;
        maxX *= 0.9f;
        float minX = screenRight + 5;
        float actualX = Random.Range(minX, maxX);

        pos.x = actualX + goCollider.size.x / 2;
        go.transform.position = pos;

        PGround goGround = go.GetComponent<PGround>();
        goGround.groundHeight = go.transform.position.y + (goCollider.size.y / 2);

        PGroundFall gFall = go.GetComponent<PGroundFall>();
        if (gFall != null)
        {
            Destroy(gFall);
            gFall = null;
        }


        if (Random.Range(0, 3) == 0)
        {
            gFall= go.AddComponent<PGroundFall>();
            gFall.fallSpeed = Random.Range(1.0f, 3.0f);
        }


        int obstalcesNum = Random.Range(0, 2);
        for (int i = 0; i < obstalcesNum; i++)
        {
            GameObject box = Instantiate(boxTemplate.gameObject);
            float y = goGround.groundHeight;
            float halfWidth = goCollider.size.x / 2 - 2;
            float left = go.transform.position.x - halfWidth;
            float right = go.transform.position.x + halfWidth;
            float x = Random.Range(left, right);
            Vector2 boxPos = new Vector2(x, y);
            box.transform.position = boxPos;


            if(gFall != null)
            {
                Obstacles obstacles = box.GetComponent<Obstacles>();
                gFall.obstacles.Add(obstacles);
            }
        }
    }

}