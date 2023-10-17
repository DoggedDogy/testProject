using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private string ignoreTag;
    private Collider2D collider;

    [SerializeField] private float liveTime;
    public void Awake()
    {
        collider = GetComponentInChildren<Collider2D>();
        Invoke("Delete", liveTime);
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        collider.isTrigger = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<HealthController>(out HealthController healthController))
        {
            healthController.ChangeHealth(-damage);
            Destroy(gameObject);
        }
    }
    public void Delete()
    {
        Destroy(gameObject);
    }
}
