using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 2f;
    public float fireRadius;

    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private InventoryItemData ammoItem;
    [SerializeField] private GameObject fireReferenceObject;
    private Animator animator;
    private Rigidbody2D rb;
    private bool rFacing = true;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        fireReferenceObject.transform.localScale = new Vector3(fireRadius, fireRadius, 0);
    }

    void FixedUpdate()
    {
        // Move the player
        rb.velocity = _joystick.Direction * moveSpeed;

        // Update the animator state based on movement and shooting
        if (_joystick.Direction.magnitude > 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        if (_joystick.Horizontal > 0 && !rFacing)
        {
            Flip();
        }
        if (_joystick.Horizontal < 0 && rFacing)
        {
            Flip();
        }
    }

    public void Shoot()
    {
        if (inventoryManager.TryGet(ammoItem, out int stack) && stack > 0 && FindClosestEnemy(out Vector2 distance))
        {
            inventoryManager.Remove(ammoItem, 1);
            animator.SetTrigger("isShooting");
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(distance * bulletForce, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<ItemObject>(out ItemObject item))
        {
            item.OnHandlePickupItem();
        }
    }
    void Flip()
    {
        rFacing = !rFacing;
        transform.Rotate(0f, 180f, 0f);
    }
    bool FindClosestEnemy(out Vector2 distance)
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Collider2D closestEnemy = null;
        Collider2D[] allEnemies= Physics2D.OverlapCircleAll(this.transform.position, fireRadius);
        foreach (Collider2D currentEnemy in allEnemies)
        {
            if (currentEnemy.gameObject.CompareTag("Enemy"))
            {
                float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
                if (distanceToEnemy < distanceToClosestEnemy)
                {
                    distanceToClosestEnemy = distanceToEnemy;
                    closestEnemy = currentEnemy;
                }
            }
        }
        distance = new Vector2();
        if (closestEnemy != null)
        {
            Vector2 heading = closestEnemy.transform.position - firePoint.transform.position;
            distance = heading / heading.magnitude;
        }
        if (distanceToClosestEnemy <= fireRadius*20)
            return true;
        else
            return false;
    }
}