using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float smoothTime = 0.25f;
    [SerializeField] private Transform target;
    
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}