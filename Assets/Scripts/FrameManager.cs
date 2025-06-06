using UnityEngine;

public class FrameManager : MonoBehaviour
{
    public int maxAmountOfFrames;
    public int currentFrame;
    public bool isGameOver;
    private void Start()
    {
        currentFrame = 1;
    }

    public void NextFrame()
    {
        currentFrame++;
        if(currentFrame > maxAmountOfFrames)
        {
            isGameOver = true;
        }
    }

}
