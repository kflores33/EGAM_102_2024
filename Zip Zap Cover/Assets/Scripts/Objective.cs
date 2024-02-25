using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public CircleCollider2D circleCollider;

    public Color color;
    public Color colorGrey;

    public SpriteRenderer spriteRenderer;

    public float timer = 3f;

    public bool timerIsActive = false;
    public bool win = false;

    public AudioSource victory;

    public Animator animator;

    public SceneSwitcher sceneSwitcher;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetTrigger("idle");
    }

    // Update is called once per frame
    void Update()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();
        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (timerIsActive == true)
        {
            timer -= Time.deltaTime;

            if (timer <= 0 && timerIsActive == true && win == false)
            {
                victory.Play();
                win = true;
                //timerIsActive = false;
            }
            if (timer <= -3 && timerIsActive == true)
            {
                Debug.Log("should switch scene here");
                if (sceneName == "Level1")
                {
                    sceneSwitcher.levelTwo();
                }
                else if (sceneName == "Level2")
                {
                    sceneSwitcher.levelThree();
                }
                else if (sceneName == "Level3")
                {
                    sceneSwitcher.levelFour();
                }
                else if (sceneName == "Level4")
                {
                    sceneSwitcher.levelFive();
                }
                else if (sceneName == "Level5")
                {
                    sceneSwitcher.levelSix();
                }
                else if (sceneName == "Level6")
                {
                    sceneSwitcher.levelOne();
                }
            }
        }
        if (timerIsActive == false && win == false)
        {
            timer = 3f;
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Thing") || col.gameObject.CompareTag("Thing2"))
        {
            // start timer 
            timerIsActive= true;
            
            // change color
            spriteRenderer.color = Color.white;

            animator.SetTrigger("Active");
            
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Thing") || col.gameObject.CompareTag("Thing2"))
        {
            timerIsActive = false;

            animator.SetTrigger("idle");
            spriteRenderer.color = colorGrey;
        }
    }
}
