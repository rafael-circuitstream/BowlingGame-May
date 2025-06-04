using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    public float moveSpeed;
    public float throwForce;
    public Rigidbody myRigidbody;
    public GameObject arrow;

    private float horizontalInput;
    private bool thrown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (thrown)
        { 
            return;
        }

        MoveBall();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowBall();
        }
    }

    void MoveBall()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.position += transform.right * horizontalInput * Time.deltaTime * moveSpeed;
    }

    void ThrowBall()
    {
        arrow.SetActive(false);
        thrown = true;
        myRigidbody.AddForce(arrow.transform.forward * throwForce, ForceMode.Impulse);
        Invoke("ResetBall", 6);
    }

    void ResetBall()
    {
        //SPAWN BALL
        FindAnyObjectByType<GameManager>().SpawnBall();
        Destroy(gameObject);
    }
}
