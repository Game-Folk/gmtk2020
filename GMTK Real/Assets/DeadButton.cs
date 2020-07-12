using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {

    }
    public void restartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void test()
    {
        Debug.Log("hi");
    }
    
}
