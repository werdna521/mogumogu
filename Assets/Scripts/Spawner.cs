using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject blue;
    public GameObject red;
    public int numberOfBall;
    public float force;
    public string level;
    private Text winLose;
    private static List<GameObject> ballList;
    private List<bool> isBlueList;
    private static GameObject panel;
    private Text text;
    private Text theScore;

    public static List<GameObject> GetList()
    {
        return ballList;
    }

    public static GameObject GetPanel()
    {
        return panel;
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

//            float y = ballList[ballList.Count-1].transform.position.y;
//            ballList.Add(Instantiate(RandomObject(), new Vector2(0, y + 2.5f), Quaternion.identity));

            --numberOfBall;
            text.text = "Bottle Left: " + numberOfBall;
            theScore.text = numberOfBall.ToString();
            winLose.text = "Stage " + level + " Failed";
        }
        else
        {
            for (int i = 0; i < numberOfBall; ++i)
            {
                GameObject temp = ballList[0];
                ballList.Remove(ballList[0]);
                isBlueList.Remove(isBlueList[0]);
                Destroy(temp);
            }
            text.text = "Bottle left: " + numberOfBall;
            theScore.text = numberOfBall.ToString();
            winLose.text = "Stage " + level + " Failed";
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

//            float y = ballList[ballList.Count-1].transform.position.y;
//            ballList.Add(Instantiate(RandomObject(), new Vector2(0, y + 2.5f), Quaternion.identity));

            --numberOfBall;
            text.text = "Bottle left: " + numberOfBall;
            theScore.text = numberOfBall.ToString();
            winLose.text = "Stage " + level + " Failed";
        }
        else
        {
            for (int i = 0; i < numberOfBall; ++i)
            {
                GameObject temp = ballList[0];
                ballList.Remove(ballList[0]);
                isBlueList.Remove(isBlueList[0]);
                Destroy(temp);
            }
            text.text = "Bottle left: " + numberOfBall;
            theScore.text = numberOfBall.ToString();
            winLose.text = "Stage " + level + " Failed";
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
        panel = GameObject.Find("Panel");
        text = GameObject.Find("Score").GetComponent<Text>();
        theScore = GameObject.Find("TheScore").GetComponent<Text>();
        winLose = GameObject.Find("Text").GetComponent<Text>();

        for (int i = 0; i < numberOfBall; ++i)
        {
            ballList.Add(Instantiate(RandomObject(), new Vector2(0, (i + 1) * 4), Quaternion.identity));
        }

        panel.SetActive(false);
        text.text = "Bottle Left: " + numberOfBall;
        theScore.text = numberOfBall.ToString();

        MoveAll();
    }

    // Update is called once per frame
    void Update()
    {
        if (Trigger.IsLost())
        {
            for (int i = 0; i < numberOfBall; ++i)
            {
                GameObject temp = ballList[0];
                ballList.Remove(ballList[0]);
                isBlueList.Remove(isBlueList[0]);
                Destroy(temp);
            }
            text.text = "Bottle left: " + numberOfBall;
            theScore.text = numberOfBall.ToString();
            winLose.text = "Stage " + level + " Failed";
            panel.SetActive(true);
        }

        if (numberOfBall == 0)
        {
            winLose.text = "Stage " + level + " Cleared";
            text.text = "";
            panel.SetActive(true);
        }
//        ballList[0].GetComponent<Rigidbody2D>().mass = 6;
//        ballList[1].GetComponent<Rigidbody2D>().mass = 3;
//        ballList[2].GetComponent<Rigidbody2D>().mass = 2;
    }

    void MoveAll()
    {
        Vector2 direction = new Vector2(0, -2).normalized;
        for (int i = 0; i < numberOfBall; ++i)
        {
            ballList[i].GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
    }
}
