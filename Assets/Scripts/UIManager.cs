using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameOverUI()
    {
        StartCoroutine(GameOverPanel());
    }
    IEnumerator GameOverPanel()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        GameOver.SetActive(true);
    }
}
