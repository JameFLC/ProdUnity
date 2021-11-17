using UnityEngine;

public class LookAt : MonoBehaviour
{
    //Camera to watch.
    [SerializeField]
    private Camera cameraToLookAt;
    void Start()
    {
        if (cameraToLookAt == null)
        {
            cameraToLookAt = Camera.main;
        }
    }

    void LateUpdate()
    {
        transform.LookAt(cameraToLookAt.transform);
        transform.rotation = Quaternion.LookRotation(cameraToLookAt.transform.forward);
    }
}
