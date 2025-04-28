using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private InputAction playerControls;

    private Vector2 moveDirection = Vector2.zero;
    private Vector3 lookDirection;
    private float lookAngle;

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        moveDirection = playerControls.ReadValue<Vector2>();
        transform.position += new Vector3(moveDirection.x * moveSpeed * Time.deltaTime, moveDirection.y * moveSpeed * Time.deltaTime, 0);
        lookDirection = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(lookAngle, Vector3.forward);
    }
}