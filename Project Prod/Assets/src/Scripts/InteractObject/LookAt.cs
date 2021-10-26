using UnityEngine;

public class LookAt : MonoBehaviour
{
    //Camera to watch.
    private GameObject cameraToLookAt;
    void Start()
    {
        cameraToLookAt = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void LateUpdate()
    {
        transform.LookAt(cameraToLookAt.transform);
        transform.rotation = Quaternion.LookRotation(cameraToLookAt.transform.forward);
    }
}
