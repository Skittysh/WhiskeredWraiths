namespace PlayerStuff.Attack
{
    using UnityEngine;
    using Stats;

    public class AttackMelee : AttackBase
    {
        public LayerMask enemyLayer;
        public HeroStats heroStats;
        private float _lastAttackTime;
        private GameObject _projectilePrefab;
        private Transform _firePoint;
        private Camera _virtualCamera;
        private HeroStats _heroStats;

        private void Start()
        {
            _projectilePrefab = GameObject.Find("Stone slash");
            _firePoint = GameObject.Find("Hero").transform;
            _virtualCamera = GameObject.Find("Camera").GetComponent<Camera>();
            _heroStats = GetComponent<HeroStats>();
        }

        private void Awake()
        {
            heroStats = gameObject.GetComponent<HeroStats>();
        }

        public override void Attack()
        {
            if (IsAttacking())
            {
                if (CanAttack())
                {
                    Fire();
                }
            }
        }

        private bool IsAttacking()
        {
            return Input.GetMouseButtonDown(1);
        }

      private bool CanAttack()
{
    if (Time.time - _lastAttackTime >= _heroStats.AttackMeleeCooldown || _lastAttackTime == 0)
    {
        _lastAttackTime = Time.time;
        return true;
    }

    return false;
}

private void Fire()
{
    // Only proceed if Time.timeScale is 1
    Time.timeScale  = 1f;

    Vector2 mousePosition = _virtualCamera.ScreenToWorldPoint(Input.mousePosition);
    var direction = mousePosition - (Vector2)_firePoint.position;
    direction.Normalize();

    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

    var projectile = Instantiate(_projectilePrefab, _firePoint.position, Quaternion.Euler(angle - 160, -90, -90));

    Destroy(projectile, 0.3f);
}
    }
}