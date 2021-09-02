using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    public void StartLastScene()
    {
        SceneManager.LoadScene("Graph");
    }
}
