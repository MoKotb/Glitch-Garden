using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float projectileSpeed = 5f;
    [SerializeField]
    float projectileDamage = 50f;

    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();
        Attacker attacker = collision.GetComponent<Attacker>();
        if (health && attacker)
        {
            health.DealDamage(projectileDamage);
            Destroy(gameObject);
        }
    }
}
