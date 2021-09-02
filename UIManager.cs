using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField fieldRabbits;
    public InputField fieldWoolfs;
    public static int countRabbits;
    public static int countWoolfs;
    
    public void StartSimulation()
    {
        countWoolfs = Convert.ToInt32(fieldWoolfs.text);
        countRabbits = Convert.ToInt32(fieldRabbits.text);
        if(fieldRabbits.text.Length != 0 && fieldWoolfs.text.Length != 0) SceneManager.LoadScene("MainScene");
    }
}
