using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    public Text timerText;
    public Text resultText;
    public GameObject panel;

    public float time;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    IEnumerator Timer()
    {
        while(SpawnManager.isGameOver != 1)
        {
            if (time > 0)
            {
                time -= 1;
                timerText.text = "제한 시간 : " + time;
            }
            else
            {
                timerText.text = "제한 시간 초과!";
                panel.SetActive(true);
                resultText.text = "당신의 점수는 " + SpawnManager.score + "병!";
                SpawnManager.isGameOver = 1;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}