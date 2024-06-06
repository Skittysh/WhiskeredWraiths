namespace PlayerStuff.Dash
{
    using System.Collections;
    using UnityEngine;

    public class DashSimple : Dash
    {
        private bool _isDashing;
        private Rigidbody2D _rb;
        private bool _canDash;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _canDash = true;
        }

        public override IEnumerator DoDash(Vector2 movementDirection, float dashSpeed, float dashTime,
            float dashCooldown)
        {
            _canDash = false;
            _isDashing = true;
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