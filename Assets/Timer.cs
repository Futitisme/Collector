using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public float MaxTime = 60f;
    [SerializeField] private float CountDown = 0;
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        CountDown = MaxTime;
        timerText.text = CountDown.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        CountDown -= Time.deltaTime;
        timerText.text = "Time left: " + Mathf.Round(CountDown).ToString();
        
        if(CountDown <= 0)
        {
            Coin.CoinCount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
