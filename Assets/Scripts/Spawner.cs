using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject blue;
    public GameObject red;
    private static List<GameObject> ballList;
    private List<bool> isBlueList;
    private int score;
    private GameObject panel;
    private Text text;
    private Text theScore;

    public static List<GameObject> GetList()
    {
        return ballList;
    }

    public void ButtonBlueOnClick()
    {
        if (isBlueList[0])
        {
            Debug.Log("blue");

            GameObject temp = ballList[0];
            ballList.Remove(ballList[0]);
            isBlueList.Remove(isBlueList[0]);
            Destroy(temp);

            float y = ballList[ballList.Count-1].transform.position.y;
            ballList.Add(Instantiate(RandomObject(), new Vector2(0, y + 2.5f), Quaternion.identity));

            ++score;
            text.text = "Your score: " + score;
            theScore.text = score.ToString();
        }
        else
        {
            for (int i = 0; i < 15; ++i)
            {
                GameObject temp = ballList[0];
                ballList.Remove(ballList[0]);
                isBlueList.Remove(isBlueList[0]);
                Destroy(temp);
            }
            panel.SetActive(true);
        }
    }

    public void ButtonRedOnClick()
    {
        if (!isBlueList[0])
        {
            Debug.Log("red");

            GameObject temp = ballList[0];
            ballList.Remove(ballList[0]);
            isBlueList.Remove(isBlueList[0]);
            Destroy(temp);

            float y = ballList[ballList.Count-1].transform.position.y;
            ballList.Add(Instantiate(RandomObject(), new Vector2(0, y + 2.5f), Quaternion.identity));

            ++score;
            text.text = "Your score: " + score;
            theScore.text = score.ToString();
        }
        else
        {
            for (int i = 0; i < 15; ++i)
            {
                GameObject temp = ballList[0];
                ballList.Remove(ballList[0]);
                isBlueList.Remove(isBlueList[0]);
                Destroy(temp);
            }
            panel.SetActive(true);
        }
    }

    GameObject RandomObject()
    {
        if (Random.Range(0,2) == 0)
        {
            isBlueList.Add(true);
            return blue;
        }
        else
        {
            isBlueList.Add(false);
            return red;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ballList = new List<GameObject>();
        isBlueList = new List<bool>();
        score = 0;
        panel = GameObject.Find("Panel");
        text = GameObject.Find("Score").GetComponent<Text>();
        theScore = GameObject.Find("TheScore").GetComponent<Text>();

        for (int i = 0; i < 15; ++i)
        {
            ballList.Add(Instantiate(RandomObject(), new Vector2(0, (i + 1) * 4), Quaternion.identity));
        }

        panel.SetActive(false);
        text.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        ballList[0].GetComponent<Rigidbody2D>().mass = 6;
        ballList[1].GetComponent<Rigidbody2D>().mass = 3;
        ballList[2].GetComponent<Rigidbody2D>().mass = 2;
    }
}
