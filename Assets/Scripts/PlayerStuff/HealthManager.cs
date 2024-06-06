namespace PlayerStuff
{
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using System.Collections;
    using Unity.VisualScripting;
    using Stats;

    public class HealthManager : MonoBehaviour
    {
        [SerializeField] private HeroStats heroStats;
        private GameObject _playerObject;
        private GameObject _cameraTag;
        private GameObject _ui;

        private void Start()
        {
            _playerObject = GameObject.FindWithTag("Player");
            _cameraTag = GameObject.FindWithTag("Main Camera");
            _ui = GameObject.FindWithTag("UITag");
        }

        private bool Immune { get; set; }

        public void Heal(int heal)
        {
            if (heroStats.HeroHealth == heroStats.MaxNumberOfHearts * 2) return;
            heroStats.HeroHealth += heal;
        }

        private void ResolveTakeDamage(int damage)
        {
            heroStats.HeroHealth -= damage;
            if (heroStats.HeroHealth <= 0) StartCoroutine(Dying());
        }

        public void TakeDamage(int damage)
        {
            if (Immune == false)
            {
                ResolveTakeDamage(1);
                Immune = true;
                StartCoroutine(Waiting());
            }
        }

        private IEnumerator Waiting()
        {
            yield return new WaitForSeconds(0.5f);
            Immune = false;
        }

        private IEnumerator Dying()
        {
            yield return new WaitForNextFrameUnit();
            Immune = false;
            Destroy(gameObject);
            Destroy(_playerObject);
            Destroy(_cameraTag);
            Destroy(_ui);
        }
    }
}