using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalScore;
    public int currentScore;
    public int currentThrow;
    public Pin[] listOfPins;
    public GameObject ballPrefab;

    private FrameManager frameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        frameManager = FindAnyObjectByType<FrameManager>();

        currentThrow = 1;
        SpawnBall();
    }

    public void FinishThrow()
    {
        //here could be a new throw
        //PrepareNewThrow();
        //SpawnBall()
        Invoke("PrepareNewThrow", 3f);
        Invoke("SpawnBall", 3.1f);
    }

    public void SpawnBall()
    {
        //here could be a new throw
        if(frameManager.isGameOver == false)
        {
            Instantiate(ballPrefab, transform.position, ballPrefab.transform.rotation);
        }
       
    }

    void PrepareNewThrow()
    {
        foreach (Pin variablePin in listOfPins)
        {
            if (variablePin.isFallen && variablePin.gameObject.activeInHierarchy)
            {
                Debug.Log("Fallen");
                currentScore++;
                variablePin.gameObject.SetActive(false);
            }
        }

        currentThrow++;

        if (currentThrow > 2 || currentScore == 10)
        {
            totalScore += currentScore;
            ResetFrame();
        }

        //set a new throw
    }

    void ResetFrame()
    {
        //
        frameManager.NextFrame();
        currentThrow = 1;
        currentScore = 0;

        foreach(Pin temporaryPin in listOfPins)
        {

            temporaryPin.ResetPin();
        }
    }

}
