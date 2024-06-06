using System;

namespace Bullet
{
    using Enemy;
    using Stats;
    using UnityEngine;

    public class MeleeHit : MonoBehaviour
    {
        [SerializeField] private HeroStats heroStats;
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("hit enemy");
                var enemy = collision.gameObject.GetComponent<EnemyDeath>();
                if (enemy != null)
                {
                    enemy.TakeDamage(heroStats.MeleeAttackDamage);
                    
                }
            }
        }
    }
}