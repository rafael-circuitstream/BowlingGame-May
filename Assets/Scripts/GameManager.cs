using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentScore;
    public Pin[] listOfPins;
    public GameObject ballPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnBall();
    }

    public void SpawnBall()
    {
        Invoke("PrepareNewThrow", 2f);

        Instantiate(ballPrefab, transform.position, ballPrefab.transform.rotation);
    }

    void PrepareNewThrow()
    {
        foreach (Pin variablePin in listOfPins)
        {
            if (variablePin.isFallen && variablePin.gameObject.activeInHierarchy)
            {
                currentScore++;
                variablePin.gameObject.SetActive(false);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
