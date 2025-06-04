using UnityEngine;

public class PitTrigger : MonoBehaviour
{
    GameManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            manager = FindAnyObjectByType<GameManager>();

            if(manager != null)
            {
                manager.SpawnBall();
            }

            //Moment where ball needs to respawn
            Destroy(other.gameObject);
        }
       
    }

}
