using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Keypad1)) 
        {
            levelOne();
        }
        if (Input.GetKeyUp(KeyCode.Keypad2)) { levelTwo(); }
        if (Input.GetKeyUp (KeyCode.Keypad3)) { levelThree();}
        if (Input.GetKeyUp (KeyCode.Keypad4)) { levelFour(); }
        if (Input.GetKeyUp (KeyCode.Keypad5)) { levelFive(); }
        if (Input .GetKeyUp (KeyCode.Keypad6)) { levelSix(); }
    }

    public void levelOne()
    {
        //reset scene
        SceneManager.LoadScene("Level1");
    }
    public void levelTwo()
    {
        //reset scene
        SceneManager.LoadScene("Level2");
    }
    public void levelThree()
    {
        //reset scene
        SceneManager.LoadScene("Level3");
    }
    public void levelFour()
    {
        //reset scene
        SceneManager.LoadScene("Level4");
    }
    public void levelFive()
    {
        //reset scene
        SceneManager.LoadScene("Level5");
    }
    public void levelSix()
    {
        //reset scene
        SceneManager.LoadScene("Level6");
    }
}
