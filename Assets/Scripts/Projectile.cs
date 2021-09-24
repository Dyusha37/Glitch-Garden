using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;
    [SerializeField]
    float damage = 100f;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";
    private void Start()
    {
        CreateProjectileParent();
        transform.parent = projectileParent.transform;
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); 
    }
    public float GetDamage()
    {
        return damage;
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();
        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
