using UnityEngine;

public class FrameManager : MonoBehaviour
{
    public int maxAmountOfFrames;
    public int currentFrame;
    public bool isGameOver;

    public UIFrame[] listOfFrames;
    public GameObject strikeMessage;
    public GameObject spareMessage;

    public GameManager gameManager;

    private void Start()
    {
        currentFrame = 1;
    }

    public void NextFrame()
    {

        listOfFrames[currentFrame - 1].totalScoreAtFrame.text = gameManager.totalScore.ToString();

        currentFrame++;
        if(currentFrame > maxAmountOfFrames)
        {
            isGameOver = true;
        }

    }

    public void UpdateFirstThrowText()
    {
        if(gameManager.firstThrowScore == 10)
        {
            listOfFrames[currentFrame - 1].secondThrowText.text = "X";
            strikeMessage.SetActive(true);
            Invoke("ResetMessages", 3f);
        }
        else
        {
            listOfFrames[currentFrame - 1].firstThrowText.text = gameManager.firstThrowScore.ToString();
        }
        
    }

    public void UpdateSecondThrowText()
    {
        if (gameManager.firstThrowScore + gameManager.secondThrowScore == 10)
        {
            listOfFrames[currentFrame - 1].secondThrowText.text = "/";
            spareMessage.SetActive(true);
            Invoke("ResetMessages", 3f);
        }
        else
        {
            listOfFrames[currentFrame - 1].secondThrowText.text = gameManager.secondThrowScore.ToString();
        }
       
    }

    void ResetMessages()
    {
        strikeMessage.SetActive(false);
        spareMessage.SetActive(false);
    }
}
