using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spotting : MonoBehaviour
{



  

    // Start is called before the first frame update
    void Start()
    {
       
    }   

    void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.name == "Monster")
        {
            Debug.Log("MONSTER SPOTTED");
            Destroy(collision.gameObject);
            GameObject button = new GameObject();
            //button.AddComponent<Button>();
           // button.transform.position = new Vector3(0,0,0);
           // button.GetComponent<Button>().transform.localScale = new Vector3(3, 3, 3);
           // button.GetComponent<Button>().onClick.AddListener(toMenu);
            toMenu();
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
       
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void toMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
