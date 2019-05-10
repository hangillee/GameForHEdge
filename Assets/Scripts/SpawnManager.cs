using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    //public GameObject PlayerAnswer;
    //생성된 소주
    public GameObject[] GenerateBottles = new GameObject[3];
    //소주 목록
    public GameObject[] AlcoholBottles;
    public GameObject panel;
    public Text resultText;

    public static int isGameOver = 0;
    public int[] realAnswer = new int[3];
    public int playerAnswer;
    public string playerDirectionSelect;
    public int random;
    public static int score = 0;
    public int speed = 7;
    public int index = 0;

    // Start is called before the first frame updateor
    void Start()
    {
        playerAnswer = ButtonManager.playerSelect;
        GenerateAlcohol();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
        {
            Debug.Log("왼쪽");
            playerDirectionSelect = "Left";
            if(isGameOver != 1)
            {
                OnKeyInput();
            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) == true)
        {
            playerDirectionSelect = "Right";
            Debug.Log("오른쪽");
            if(isGameOver != 1)
            {
                OnKeyInput();
            }
        }
    }
    void OnKeyInput()
    {
        float moveSpeed = Time.deltaTime * speed;
        Debug.Log("반복문 접근");
        if (playerDirectionSelect == "Left")
        {
            Debug.Log(playerDirectionSelect);
            Debug.Log("진짜 답" + realAnswer[0]);
            Debug.Log("사용자 답 " + playerAnswer);
            if (realAnswer[index] != playerAnswer)
            {
                isGameOver = 1;
                Debug.Log("틀림!");
                panel.SetActive(true);
                //Destroy(GenerateBottles[index]);
                resultText.text = "당신의 점수는 " + score + "병!";
            }
            else
            {
                GenerateBottles[index].transform.Translate(Vector3.left * moveSpeed);
                Destroy(GenerateBottles[index]);
                score += 1;
                index += 1;
                Debug.Log(index);
                if(index == 3)
                {
                    index = 0;
                    GenerateAlcohol();
                }
            }

        }

        if (playerDirectionSelect == "Right")
        {
            if (realAnswer[index] == playerAnswer)
            {
                isGameOver = 1;
                Debug.Log("틀림!");
                //Destroy(GenerateBottles[index]);
                panel.SetActive(true);
                resultText.text = "당신의 점수는 " + score + "병!";
            }
            else
            {
                GenerateBottles[index].transform.Translate(Vector3.right * moveSpeed);
                Destroy(GenerateBottles[index]);
                score += 1;
                index += 1;
                if (index == 3)
                {
                    index = 0;
                    GenerateAlcohol();
                }
            }
        }

    }
    void GenerateAlcohol()
    {
        for (int i = 0; i < 3; i++)
        {
            random = Random.Range(0, 2);
            GenerateBottles[i] = (GameObject)Instantiate(AlcoholBottles[random], new Vector3(0, i, 0), Quaternion.identity);
            GenerateBottles[i].GetComponent<SpriteRenderer>().sortingOrder = -i;

            if (random == 0)
            {
                //AlcoholBottles[0]일 때 답 realAnswer[]에 답 0
                realAnswer[i] = 0;
            }
            else
            {
                //AlcoholBottles[1]일 때 답 realAnswer[]에 답 1
                realAnswer[i] = 1;
            }
        }
    }
}