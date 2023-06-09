using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    Lucio lucio;
    Text distanceText;

    private void Awake() 
    {
       lucio = GameObject.Find("Lucio").GetComponent<Lucio>();
        distanceText = GameObject.Find("DistanceText").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int distance = Mathf.FloorToInt(lucio.distance);
        distanceText.text = distance + " m"; 
    }
}
