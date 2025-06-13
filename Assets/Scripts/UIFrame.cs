using UnityEngine;
using TMPro;

public class UIFrame : MonoBehaviour
{
    public TextMeshProUGUI frameNumber;
    public TextMeshProUGUI firstThrowText;
    public TextMeshProUGUI secondThrowText;
    public TextMeshProUGUI totalScoreAtFrame;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int frameIndex = transform.GetSiblingIndex() + 1;
        frameNumber.text = frameIndex.ToString();

        firstThrowText.text = "";
        secondThrowText.text = "";
        totalScoreAtFrame.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
