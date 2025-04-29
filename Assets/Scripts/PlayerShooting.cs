using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject bulletTrail;
    [SerializeField] private float weaponRange = 20f;
    [SerializeField] private Animator shootingFlashAnimator;
    [SerializeField] private float cooldown = 0.3f;
    
    private PlayerInputActions playerControls;
    private InputAction shoot;
    private Ray ray;
    private RaycastHit2D[] hits = new RaycastHit2D[10];
    private bool inCooldown;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        shoot = playerControls.Player.Fire;
        shoot.Enable();
        shoot.performed += Shoot;
    }

    private void OnDisable()
    {
        shoot.Disable();
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        if (inCooldown) return;

        StartCoroutine(CooldownTimer());
        
        shootingFlashAnimator.SetTrigger("Shoot");

        Physics2D.RaycastNonAlloc(transform.position, Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position), hits);

        GameObject trail = Instantiate(bulletTrail, shootingPoint.position, transform.rotation);

        BulletTrail trailScript = trail.GetComponent<BulletTrail>();

        if (hits.Length <= 0) return;
        
        foreach (RaycastHit2D raycastHit2D in hits)
        {
            if (raycastHit2D.collider && raycastHit2D.collider.gameObject != gameObject)
            {
                trailScript.SetTargetPosition(raycastHit2D.point);
                
                Array.Clear(hits, 0, hits.Length);
                
                return;
            }

            Vector3 endPosition = shootingPoint.position + transform.right * weaponRange;
            
            trailScript.SetTargetPosition(endPosition);
        }
    }

    private IEnumerator CooldownTimer()
    {
        inCooldown = true;
        
        yield return new WaitForSeconds(cooldown);
        
        inCooldown = false;
    }
}