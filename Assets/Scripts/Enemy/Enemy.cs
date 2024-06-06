namespace Enemy
{
    using UnityEngine;

    public class Enemy : MonoBehaviour
    {
        // Start is called before the first frame update
        private int _health;

        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0) Destroy(gameObject);
        }
    }
}