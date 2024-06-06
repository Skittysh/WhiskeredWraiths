using System.Collections;
using UnityEngine;

namespace PlayerStuff
{
    public class TimeStop : MonoBehaviour
    {
        private float _speed;
        private bool _restoreTime;

        private void Start()
        {
            _restoreTime = false;
        }

        private void Update()
        {
            if (_restoreTime)
            {
                if (Time.timeScale < 1f)
                {
                    Time.timeScale += Time.deltaTime * _speed;
                }
                else
                {
                    Time.timeScale = 1f;
                    _restoreTime = false;
                }
            }
        }

        public void StopTime(float ChangeTime, int RestoreSpeed, float delay)
        {
            _speed = RestoreSpeed;

            if (delay > 0)
            {
                StopCoroutine(StartTimeAgain(delay));
                StartCoroutine(StartTimeAgain(delay));
            }
            else
            {
                _restoreTime = true;
            }

            Time.timeScale = ChangeTime;
        }

        IEnumerator StartTimeAgain(float amt)
        {
            yield return new WaitForSecondsRealtime(amt);
            _restoreTime = true;
        }
    }
}