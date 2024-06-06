namespace Enemy
{
    using UnityEngine;

    public class EnemyShootMovement : MonoBehaviour
    {
        public Transform player;
        private Rigidbody2D _rb;
        public float moveSpeed = 4f;
        private Vector2 _movement;
        private float _timeAlive;
        public float stoppingDistance = 3f;
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            GameObject playerObject = GameObject.FindWithTag("Player");
            player = playerObject.transform;
            _timeAlive = 0f;
        }

        private void Update()
        {
            var direction = player.position - transform.position;
            float distance = direction.magnitude;

            if (distance > stoppingDistance)
            {
                direction.Normalize();
                _movement = direction;
                _timeAlive += Time.deltaTime;
                moveSpeed = 5f + (_timeAlive / 2f);
            }
            else
            {
                _movement = Vector2.zero;
            }
        }

        private void FixedUpdate()
        {
            MoveCharacter(_movement);
        }

        private void MoveCharacter(Vector2 direction)
        {
            Vector2 currentPosition = transform.position;
            Vector2 nextPosition = currentPosition + direction * (moveSpeed * Time.deltaTime);
            _spriteRenderer.flipX = nextPosition.x < currentPosition.x;
            _rb.MovePosition(nextPosition);
        }
    }
}