using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float Speed = 2F;
    [SerializeField] private float distanceBetween = 20F;
    [SerializeField] private GameObject slash;
    [SerializeField] private GameObject slashPoint;

    private float distance;
    private GameObject target;
    private bool rFacing = true;
    private Animator animator;
    private bool readyToStrike = true;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            distance = Vector2.Distance(transform.position, target.transform.position);
            direction = target.transform.position - transform.position; 
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (distance < 2)
            {
                if (readyToStrike)
                {
                    readyToStrike = false;
                    animator.SetTrigger("IsStriking");
                    Invoke("Strike", 0.75F);
                }
                animator.SetBool("IsWalking", false);
            }
            if (distance < distanceBetween && 2 < distance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Speed * Time.deltaTime);
                animator.SetBool("IsWalking", true);
                if (rFacing && transform.position.x > target.transform.position.x)
                {
                    Flip();
                }
                if (!rFacing && transform.position.x < target.transform.position.x)
                {
                    Flip();
                }
            }
            if (distance > distanceBetween)
            {
                target = null;
                animator.SetBool("IsWalking", false);
            }
        }
    }
    void Strike()
    {
        Instantiate(slash, slashPoint.transform.position, slashPoint.transform.rotation);
        readyToStrike = true;
    }
    void Flip()
    {
        rFacing = !rFacing;
        transform.Rotate(0f, 180f, 0f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            target = other.gameObject;
    }
}
