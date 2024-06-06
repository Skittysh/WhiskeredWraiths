namespace PlayerStuff.Dash
{
    using System.Collections;
    using UnityEngine;
    using Stats;

    public class DashProjectile : Dash
    {
        private bool _isDashing;
        private Rigidbody2D _rb;
        private bool _canDash;
        private Transform _firePoint;
        private Camera _virtualCamera;
        private HeroStats _heroStats;


        private GameObject _projectilePrefab;

        private void Shoot()
        {
            Vector2 mousePosition = _virtualCamera.ScreenToWorldPoint(Input.mousePosition);
            var direction = mousePosition - (Vector2)_firePoint.position;
            direction.Normalize();
            var projectile = Instantiate(_projectilePrefab, _firePoint.position, _firePoint.rotation);
            var projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
            projectileRigidbody.velocity = direction * _heroStats.ProjectileSpeed;
        }

        private void Start()
        {
            _projectilePrefab = GameObject.Find("projectileBullet");
            _firePoint = GameObject.Find("Hero").transform;
            _virtualCamera = GameObject.Find("Camera").GetComponent<Camera>();
            _heroStats = GetComponent<HeroStats>();
            _rb = GetComponent<Rigidbody2D>();
            _canDash = true;
        }

        public override IEnumerator DoDash(Vector2 movementDirection, float dashSpeed, float dashTime,
            float dashCooldown)
        {
            _canDash = false;
            _isDashing = true;
            Shoot();
            _rb.velocity = new Vector2(movementDirection.x * dashSpeed, movementDirection.y * dashSpeed);
            yield return new WaitForSeconds(dashTime);
            _isDashing = false;
            yield return new WaitForSeconds(dashCooldown);
            _canDash = true;
        }

        public override bool IsDashing()
        {
            return _isDashing;
        }

        public override bool CanDash()
        {
            return _canDash;
        }
    }
}