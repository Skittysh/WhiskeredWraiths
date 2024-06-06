namespace PlayerStuff
{
    using UnityEngine;
    using Attack;
    using UnityEngine.UI;
    using System.Collections;


    public class Player : MonoBehaviour
    {
        private AttackBase _leftClickAttack;
        private AttackBase _rightClickAttack;
        public Image screenOverlay;
        public bool isDimming;

        private void Start()
        {
            _leftClickAttack = gameObject.AddComponent<AttackRange>();
            _rightClickAttack = gameObject.AddComponent<AttackMelee>();
        }

        private void Update()
        {
            _leftClickAttack.Attack();
            _rightClickAttack.Attack();
        }
        
        public void MakeAttack<T>() where T : Attack.AttackBase
        {
            _leftClickAttack = gameObject.AddComponent<T>();
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnBulleter"))
            {
                if (!isDimming) 
                {
                    collision.gameObject.GetComponent<TimeStop>().StopTime(0.05f, 10, 0.1f);
                    StartCoroutine(DimScreen());
                }
            }
        }
        
        
        private IEnumerator DimScreen()
        {
            isDimming = true;
            float duration = 0.05f;
            float currentTime = 0;

            while (currentTime < duration)
            {
                float alpha = currentTime / duration;
                screenOverlay.color = new Color(1, 0, 0, alpha/2);
                currentTime += Time.deltaTime;
                yield return null;
            }
            currentTime = 0;

            while (currentTime < duration)
            {
                float alpha = 0.5f - (currentTime / duration);
                screenOverlay.color = new Color(1, 0, 0, alpha);
                currentTime += Time.deltaTime;
                
            }
            
            isDimming = false;
            Time.timeScale = 1f;
            yield return null;
        }
        
    }
}