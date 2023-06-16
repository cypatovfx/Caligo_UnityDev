using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    Lucio lucio;
    Text distanceText;

    GameObject results;
    Text finalDistanceText;


    ParticleSystem resultsParticleSystem;

    ParticleSystem distanceParticles;

    GameObject glitchSphere;


    private void Awake()
    {
        lucio = GameObject.Find("Lucio").GetComponent<Lucio>();
        distanceText = GameObject.Find("DistanceText").GetComponent<Text>();

        results = GameObject.Find("Results");
        finalDistanceText = GameObject.Find("FinalDistanceText").GetComponent<Text>();
        results.SetActive(false);
        glitchSphere = GameObject.Find("GlitchSphere");
        glitchSphere.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        resultsParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        int distance = Mathf.FloorToInt(lucio.distance);
        distanceText.text = distance + " m";

        if (lucio.isDead)
        {
            results.SetActive(true);
            glitchSphere.SetActive(false);
            finalDistanceText.text = distance + " m";
            Destroy(distanceText);
            Destroy(distanceParticles);


        }
    }


    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }

}

