using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Monster : MonoBehaviour
{

    public float spd = 5.0f;
    public GameObject target;
    public GameObject prefabsExplosion;
    Vector3 direct = Vector3.down;

    
    private void Start()
    {
        int rndNum = Random.Range(0,10);
        if(rndNum < 3)
        {
            GameObject target = GameObject.Find("Character");
            direct = target.transform.position - transform.position;
            direct.Normalize();
            
        }
    }
    
    private void Update()
    {
        transform.position = transform.position + direct * spd * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            
            GameObject gameManager = GameObject.Find("ScoreManager");
            
            ScoreManager scoreManager = gameManager.GetComponent<ScoreManager>();
            //1점 추가
            scoreManager.nowScore++;

            //점수를 가지고 UI text 에 표시
            scoreManager.nowScoreUI.text = "NowScore : " + scoreManager.nowScore;

            if(scoreManager.nowScore > scoreManager.bestScore)
            {
                scoreManager.bestScore = scoreManager.nowScore;
                scoreManager.bestScoreUI.text = "Best Score : " + scoreManager.bestScore;

                PlayerPrefs.SetInt("BestScore", scoreManager.bestScore);
            }
            
            GameObject explosionObj = Instantiate(prefabsExplosion);
            explosionObj.transform.position = transform.position;

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
       

    }
}
