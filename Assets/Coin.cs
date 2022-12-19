using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public static int CoinCount = -1;
    public int speed;
    public AudioSource coinSound;
    public Text TextCoin;
    // Start is called before the first frame update
    void Start()
    {
        ++Coin.CoinCount;
    }

    // Update is called once per frame
    void OnDestroy()
    {
        --Coin.CoinCount;

        if(Coin.CoinCount <= 0)
        {
            GameObject Timer = GameObject.Find("LevelTimer");
            Destroy(Timer);
            GameObject[] FireworkSystems = 
                GameObject.FindGameObjectsWithTag("Fireworks");
                if (FireworkSystems.Length <= 0) { return; }
            foreach(GameObject GO in FireworkSystems)
            {
                GO.GetComponent<ParticleSystem>().Play();
            }
        }
    }

    void OnTriggerEnter(Collider Col)
    {
        if(Col.CompareTag("Player"))
        {
            Destroy(gameObject);
            coinSound.Play();
        }
    }

    void Update(){
        transform.Rotate(0, speed, 0, Space.World);
        TextCoin.text = "Coins left: " + Coin.CoinCount.ToString(); 
    }

}
