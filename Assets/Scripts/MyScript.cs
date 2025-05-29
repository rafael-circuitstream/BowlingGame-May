using UnityEngine;

public class MyScript : MonoBehaviour
{
    public GameObject ball;

    public float timer;

    public bool isTimerRunning;
    public bool testBool;
    public Vector3 testValue;


    void Start()
    {

        //ball.SetActive(false);
        //ball.name = "Rafael";
        //
        //ball.transform.SetParent(transform);
    }

    // Update is called once per frame
    void Update()
    {

        ball.transform.Rotate(testValue * Time.deltaTime);

        if (timer > 3 || testBool)
        {
            if(isTimerRunning)
            {
                Debug.Log("Timer has reached 3 seconds");
                isTimerRunning = false;
            }
            
        }
        else
        {
            timer = timer + Time.deltaTime;
        }

    }
}

