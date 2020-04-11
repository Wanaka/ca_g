using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScore : MonoBehaviour
{
    public static int coinValue = 0;
    TextMesh coinScore;

    // Start is called before the first frame update
    void Start()
    {
        coinScore = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        coinScore.text = coinValue.ToString();
    }
}
