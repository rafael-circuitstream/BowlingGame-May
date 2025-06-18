using UnityEngine;

public class CloseUpTrigger : MonoBehaviour
{
    public GameObject closeUpCamera;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            closeUpCamera.SetActive(true);
            Invoke("TurnOffCamera", 3.5f);
        }
    }

    void TurnOffCamera()
    {
        closeUpCamera.SetActive(false);
    }
}
