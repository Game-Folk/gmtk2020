using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void loadScene(string s){
        SceneManager.LoadScene(s);
    }

    public void reloadScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
