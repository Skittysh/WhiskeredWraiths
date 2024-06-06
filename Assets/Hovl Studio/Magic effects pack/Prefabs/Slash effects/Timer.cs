using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText; 
    private float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        timeText.text = "Game Time: " + elapsedTime.ToString("0.00") + "s";
    }
}