using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float speedPlayer;

    [SerializeField] private AudioSource musicGoal;

    private bool isMoveUp = false;

    private float delay = 0.08f;

    private void FixedUpdate()
    {
        if(DataPoints.dimension)
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
        Invoke(nameof(SwitchedDirection), delay);
        delay = 0;
    }

    private void OnTriggerExit2D()
    {
        SwitchedDirection();
        delay = 0.08f;
    }

    private void SwitchedDirection() => isMoveUp = !isMoveUp;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "barrier")
        {
            if (DataPoints.pointsSpaceOne == DataPoints.pointsSpaceTwo)
            {
                DataPoints.score = DataPoints.pointsSpaceTwo;

                if(DataPoints.score > DataPoints.hiScore)
                    PlayerPrefs.SetInt("HiScore", DataPoints.score);

                PlayerPrefs.SetInt("Score", DataPoints.score);
                SceneManager.LoadScene(3);
                return;
            }

            PlayerPrefs.SetInt("Score", 0);
            SceneManager.LoadScene(2);
        }
            
        if (collision.gameObject.tag == "goal")
            musicGoal.Play();
    }
}
