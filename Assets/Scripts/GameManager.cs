using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public int randomNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randomNumber = Random.Range(0, 2200);
        Instantiate(ballPrefab, transform.position, ballPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
