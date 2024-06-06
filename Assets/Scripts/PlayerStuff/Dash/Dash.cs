namespace PlayerStuff.Dash
{
    using System.Collections;
    using UnityEngine;

    public abstract class Dash : MonoBehaviour
    {
        public abstract IEnumerator DoDash(Vector2 movementDirection, float dashSpeed, float dashTime,
            float dashCooldown);

        public abstract bool IsDashing();
        public abstract bool CanDash();
    }
}