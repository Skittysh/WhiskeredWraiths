namespace Enemy
{
    using UnityEngine;
    using PlayerStuff;


    public class EnemyMain : MonoBehaviour
    {
        private HealthManager _healthManager;
        private void Start()
        {
            var playerObject = GameObject.FindWithTag("Player");
            _healthManager = playerObject.GetComponent<HealthManager>();
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) _healthManager.TakeDamage(1);
        }
        
        
        
        
    }
}