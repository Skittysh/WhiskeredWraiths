namespace PlayerStuff
{
    using UnityEngine;
    using Stats;

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private HeroStats heroMovementStats;
        private Rigidbody2D _rb;
        private Vector2 _movementDirection;
        private Dash.Dash _movementDash;
        private SpriteRenderer _spriteRenderer; // 

        private static PlayerMovement Instance { get; set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _movementDash = gameObject.AddComponent<Dash.DashSimple>();
            _rb = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>(); // Initialize SpriteRenderer
        }

        // Update is called once per frame
        private void Update()
        {
            if (_movementDash.IsDashing()) return;

            _movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            if (Input.GetKeyDown(KeyCode.Space) && _movementDash.CanDash())
                StartCoroutine(_movementDash.DoDash(_movementDirection, heroMovementStats.DashSpeed,
                    heroMovementStats.DashTime, heroMovementStats.DashCooldown));
        }

        private void FixedUpdate()
        {
            if (_movementDash.IsDashing()) return;

            if (_movementDirection.x != 0 && _movementDirection.y != 0)
                _rb.velocity = _movementDirection * heroMovementStats.MovementSpeed * 1.4f;
            else
                _rb.velocity = _movementDirection * heroMovementStats.MovementSpeed;

            // Flip the sprite based on the direction of movement
            if (_movementDirection.x < 0)
                _spriteRenderer.flipX = false;
            else if (_movementDirection.x > 0)
                _spriteRenderer.flipX = true;
        }

        public void MovementSpeedBuff(float msBuff)
        {
            heroMovementStats.MovementSpeed += msBuff;
        }

        public float GetMS()
        {
            return heroMovementStats.MovementSpeed;
        }

        public void MakeDash<T>() where T : Dash.Dash
        {
            _movementDash = gameObject.AddComponent<T>();
        }
    }
}