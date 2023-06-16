using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class TapJump : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D BoxCollider2D;
    public float jumpPower;
    public bool canJump = true;
    Vector2 startPoint, endPoint;

        // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D Collider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Began) 
      {
            startPoint = Input.GetTouch(0).position;
      }
    
      if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) 
      {
            endPoint = Input.GetTouch(0).position;  
      }
    
      if (endPoint.y > startPoint.y && rb.velocity.y == 0)
      {
            canJump = true;
            endPoint = Vector2.zero;
            startPoint = Vector2.zero;
      }
    }

}
