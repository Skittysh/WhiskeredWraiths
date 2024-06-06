namespace PlayerStuff
{
    using UnityEngine;
    using UnityEngine.UI;
    using Stats;

    public class Health : MonoBehaviour
    {
        [SerializeField] private HeroStats hpStats;
        [SerializeField] private Image[] hearts;
        [SerializeField] private Sprite fullHearts;
        [SerializeField] private Sprite halfHearts;
        [SerializeField] private Sprite emptyHearts;


        private readonly int _maxHealth = 10;


        private void Update()
        {
            hpStats.MaxNumberOfHearts = hpStats.MaxNumberOfHearts > _maxHealth ? _maxHealth : hpStats.MaxNumberOfHearts;
            hpStats.HeroHealth = hpStats.HeroHealth > 2 * hpStats.MaxNumberOfHearts
                ? 2 * hpStats.MaxNumberOfHearts
                : hpStats.HeroHealth;

            for (var heartIteraor = 0; heartIteraor < hearts.Length; heartIteraor++)
            {
                hearts[heartIteraor].sprite = hpStats.HeroHealth % 2 != 0 && heartIteraor == hpStats.HeroHealth / 2
                    ? halfHearts
                    : heartIteraor < hpStats.HeroHealth / 2
                        ? fullHearts
                        : emptyHearts;

                hearts[heartIteraor].enabled = heartIteraor < hpStats.MaxNumberOfHearts;
            }
        }
    }
}