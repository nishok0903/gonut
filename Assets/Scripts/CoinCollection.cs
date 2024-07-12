using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    public AudioSource coinCollectionAudio;

    private void Start()
    {
        coinCollectionAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().Play("Coin");
        Destroy(gameObject);
        UIManagementScript.coinsCollected += 1;
    }
}