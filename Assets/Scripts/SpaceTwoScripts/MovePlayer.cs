using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float speedPlayer;

    [SerializeField] private AudioSource musicGoal;

    private float delay = 0;

    private void FixedUpdate()
    {
        if(DataPoints.Dimension)
            MoveInCurrentDimension(Vector3.up);
        else
            MoveInCurrentDimension(Vector3.right);

        if (IsOnBounds())
        {
            SwitchedDirection();
            delay = 0.06f;
        }
    }

    private void Update()
    {
        delay -= Time.deltaTime;
        delay = Mathf.Clamp(delay, 0, 0.06f);
    }

    private bool IsOnBounds()
    {
        return (transform.position.y < SpawnBarrier.BoundsGameField.min.y || transform.position.y > SpawnBarrier.BoundsGameField.max.y) ||
            (transform.position.x < SpawnBarrier.BoundsGameField.min.x || transform.position.x > SpawnBarrier.BoundsGameField.max.x);
    }

    private void MoveInCurrentDimension(Vector3 axisPosition) =>
        transform.Translate(speedPlayer * Time.fixedDeltaTime * axisPosition);

    public void OnClick()
    {
        if(delay == 0)
           SwitchedDirection();
    }

    private void SwitchedDirection() => speedPlayer *= -1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "barrier")
        {
            if (DataPoints.PointsSpaceOne == DataPoints.PointsSpaceTwo)
            {
                DataPoints.Score = DataPoints.PointsSpaceTwo;

                if(DataPoints.Score > DataPoints.HiScore)
                    PlayerPrefs.SetInt("HiScore", DataPoints.Score);

                PlayerPrefs.SetInt("Score", DataPoints.Score);
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
