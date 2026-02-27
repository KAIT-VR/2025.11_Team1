using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject ResultManager;
    [SerializeField] GameObject resultPanel;
    [SerializeField] GameObject Timer;
    [SerializeField] GameObject Spawnner;

    void Start()
    {
        ResultManager.SetActive(false);
        resultPanel.SetActive(false);
        Timer.SetActive(false);
        Spawnner.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "mikan")
        {
            ResultManager.SetActive(true);
            Timer.SetActive(true);
            Spawnner.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
