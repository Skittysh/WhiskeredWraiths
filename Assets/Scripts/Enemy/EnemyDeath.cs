namespace Enemy
{
    using UnityEngine;

    public class EnemyDeath : MonoBehaviour
    {
        // Start is called before the first frame update
        public int health;

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0) Destroy(gameObject);
        }
    }
}