using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneShifter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StageOne()
    {
        SceneManager.LoadScene("StageOne");
    }

    public void StageTwo()
    {
        SceneManager.LoadScene("StageTwo");
    }

    public void StageThree()
    {
        SceneManager.LoadScene("StageThree");
    }

    public void Map()
    {
        SceneManager.LoadScene("Map");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
