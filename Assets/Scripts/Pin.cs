using UnityEngine;

public class Pin : MonoBehaviour
{
    public Rigidbody myRigidbody;
    public bool isFallen;
    private Vector3 originalPosition;
    private Quaternion originalQuaternion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPosition = transform.position;
        originalQuaternion = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {   
        if(transform.rotation.eulerAngles.x > 10 && transform.rotation.eulerAngles.x < 350)
        {
            isFallen = true;
        }
        else if (transform.rotation.eulerAngles.z > 10 && transform.rotation.eulerAngles.z < 350)
        {
            isFallen = true;
        }
        else
        {
            isFallen = false;
        }
    }

    public void ResetPin()
    {
        myRigidbody.linearVelocity = Vector3.zero;
        myRigidbody.angularVelocity = Vector3.zero;

        transform.position = originalPosition;
        transform.rotation = originalQuaternion;

        gameObject.SetActive(true);


        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.CompareTag("Player"))
        {
            Debug.Log(gameObject.name + " was hit");
        }
        
    }
}
