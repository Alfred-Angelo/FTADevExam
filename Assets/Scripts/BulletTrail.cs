using UnityEngine;

public class BulletTrail : MonoBehaviour
{
    [SerializeField] private float speed = 40f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float progress;

    private void Start()
    {
        startPosition = transform.position.WithAxis(VectorsExtension.Axis.Z, -1);
    }

    private void Update()
    {
        progress += Time.deltaTime * speed;
        transform.position = Vector3.Lerp(startPosition, targetPosition, progress);
    }

    public void SetTargetPosition(Vector3 targetPos)
    {
        targetPosition = targetPos.WithAxis(VectorsExtension.Axis.Z, -1);
    }
}