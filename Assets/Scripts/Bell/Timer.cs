using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    //[SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI timerText;
    private float time = 60f;
    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "60";
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0f){
            time = 0f;
            timerText.text = "0";
            return;
        }

        time -= Time.deltaTime;
        timerText.text = Mathf.CeilToInt(time).ToString();
    }
}
