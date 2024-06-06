namespace Bullet
{
    using Enemy;
    using Stats;
    using UnityEngine;

    public class BulletHit : MonoBehaviour
    {
        [SerializeField] private HeroStats heroRangeDamageStats;
        [SerializeField] public LayerMask enemyLayer;

        // Update is called once per frame
        private void Update()
        {
            var hitColliders = new Collider2D[10]; // Adjust the size as needed
            var numColliders = Physics2D.OverlapCircleNonAlloc(transform.position, heroRangeDamageStats.BulletSize,
                hitColliders, enemyLayer);

            for (var i = 0; i < numColliders; i++)
            {
                var enemy = hitColliders[i].GetComponent<EnemyDeath>();
                if (enemy != null)
                {
                    enemy.TakeDamage(heroRangeDamageStats.RangeAttackDamage);
                    Destroy(gameObject);
                }
            }
        }
    }
}