namespace Stats
{
    using UnityEngine;

    public class HeroStats : MonoBehaviour
    {
        [Header("Health settings")] [SerializeField]
        private int heroHealth = 10;

        [SerializeField] private int maxNumberOfHearts = 10;

        [Header("Movement settings")] [SerializeField]
        private float movementSpeed = 10f;

        [Header("Dash settings")] [SerializeField]
        private float dashSpeed = 20f;

        [SerializeField] private float dashTime = 0.1f;
        [SerializeField] private float dashCooldown = 1f;

        [Header("Range attack settings")] [SerializeField]
        private float attackCooldown;

        [SerializeField] private float projectileSpeed;
        [SerializeField] private int rangeAttackDamage;
        [SerializeField] private float bulletSize;

        [Header("Melee attack settings")] [SerializeField]
        private float attackRange;

        [SerializeField] private float attackMeleeCooldown;
        [SerializeField] private int meleeAttackDamage;

        public int HeroHealth
        {
            get => heroHealth;
            set => heroHealth = value;
        }

        public int MaxNumberOfHearts
        {
            get => maxNumberOfHearts;
            set => maxNumberOfHearts = value;
        }

        public float MovementSpeed
        {
            get => movementSpeed;
            set => movementSpeed = value;
        }

        public float DashSpeed
        {
            get => dashSpeed;
            set => dashSpeed = value;
        }

        public float DashTime
        {
            get => dashTime;
            set => dashTime = value;
        }

        public float DashCooldown
        {
            get => dashCooldown;
            set => dashCooldown = value;
        }

        public float AttackCooldown
        {
            get => attackCooldown;
            set => attackCooldown = value;
        }

        public float ProjectileSpeed
        {
            get => projectileSpeed;
            set => projectileSpeed = value;
        }

        public int RangeAttackDamage
        {
            get => rangeAttackDamage;
            set => rangeAttackDamage = value;
        }

        public float BulletSize
        {
            get => bulletSize;
            set => bulletSize = value;
        }

        public float AttackRange
        {
            get => attackRange;
            set => attackRange = value;
        }

        public int MeleeAttackDamage
        {
            get => meleeAttackDamage;
            set => meleeAttackDamage = value;
        }

        public float AttackMeleeCooldown
        {
            get => attackMeleeCooldown;
            set => attackMeleeCooldown = value;
        }
    }
}