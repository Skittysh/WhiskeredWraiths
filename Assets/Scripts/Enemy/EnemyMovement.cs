namespace Enemy
{
    using UnityEngine;

    public class EnemyMovement : MonoBehaviour
    {
        public Transform player;
        private Rigidbody2D _rb;
        public float moveSpeed = 5f;
        private Vector2 _movement;
        private float _timeAlive;
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
            direction.Normalize();
            _movement = direction;
            _timeAlive += Time.deltaTime;
            moveSpeed = 5f + (_timeAlive / 2f);
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