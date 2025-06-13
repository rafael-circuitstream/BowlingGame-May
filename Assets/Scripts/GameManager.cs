using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalScore;
    public int currentScoreAtFrame;

    public int firstThrowScore;
    public int secondThrowScore;

    public int currentThrow;
    public Pin[] listOfPins;
    public GameObject ballPrefab;

    private FrameManager frameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        frameManager = FindAnyObjectByType<FrameManager>();
        frameManager.gameManager = this;
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
                currentScoreAtFrame++;
                variablePin.gameObject.SetActive(false);
            }
        }

        if(currentThrow == 1)
        {
            firstThrowScore = currentScoreAtFrame;
            frameManager.UpdateFirstThrowText();
        }
        else if(currentThrow == 2)
        {
            secondThrowScore = currentScoreAtFrame - firstThrowScore;
            frameManager.UpdateSecondThrowText();
        }


        currentThrow++;

        if (currentThrow > 2 || currentScoreAtFrame == 10)
        {
            totalScore += currentScoreAtFrame;
            ResetFrame();
        }

        //set a new throw
    }

    void ResetFrame()
    {
        //
        frameManager.NextFrame();
        currentThrow = 1;
        currentScoreAtFrame = 0;

        firstThrowScore = 0;
        secondThrowScore = 0;

        foreach(Pin temporaryPin in listOfPins)
        {

            temporaryPin.ResetPin();
        }
    }

}
