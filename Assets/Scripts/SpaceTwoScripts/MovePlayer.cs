using UnityEngine;
using UnityEngine.SceneManagement;
using System.Timers;

public class MovePlayer : MonoBehaviour
{
    public float speedPlayer;
    public AudioSource musicGoal;

    private bool isMoveUp = false;

    private float delay = 0;

    private void FixedUpdate()
    {
        if(WTPoints.dimension)
            ActionInSpaceTwo();
        else
            ActionInSpaceOne();    
    }

    private void ActionInSpaceTwo()
    {
        if (isMoveUp)
            transform.position += new Vector3(0, speedPlayer * Time.deltaTime);
        else
            transform.position -= new Vector3(0, speedPlayer * Time.deltaTime);
    }

    private void ActionInSpaceOne()
    {
        if (isMoveUp)
            transform.position += new Vector3(speedPlayer * Time.deltaTime, 0);
        else
            transform.position -= new Vector3(speedPlayer * Time.deltaTime, 0);
    }

    public void OnClick() 
    {
        Invoke("SwitchedDirection", delay);
        delay = 0;
    }

    private void SwitchedDirection()
    {
        isMoveUp = !isMoveUp;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "barrier")
        {
            if (WTPoints.pointsSpaceOne == WTPoints.pointsSpaceTwo)
            {
                WTPoints.score = WTPoints.pointsSpaceTwo;

                if(WTPoints.score > WTPoints.hiScore)
                    PlayerPrefs.SetInt("HiScore", WTPoints.score);

                PlayerPrefs.SetInt("Score", WTPoints.score);
                SceneManager.LoadScene(3);
                return;
            }

            PlayerPrefs.SetInt("Score", 0);
            SceneManager.LoadScene(2);
        }
        else if (collision.gameObject.tag == "SpaceTwo" || collision.gameObject.tag == "SpaceOne")
        {
            SwitchedDirection();
            delay = 0.05f;
        }
            

        if (collision.gameObject.tag == "goal")
            musicGoal.Play();
    }
}
