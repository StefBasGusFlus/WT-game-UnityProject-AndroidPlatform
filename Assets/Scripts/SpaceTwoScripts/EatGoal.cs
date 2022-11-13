using UnityEngine;
using UnityEngine.UI;

public class EatGoal : MonoBehaviour
{
    private Text pointsText;

    private void Start()
    {
        if (DataPoints.Dimension)
            pointsText = GameObject.Find("pointsTwo").GetComponent<Text>();
        else
            pointsText = GameObject.Find("pointsOne").GetComponent<Text>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            if (DataPoints.Dimension)
            {
                DataPoints.PointsSpaceTwo++;
                pointsText.text = DataPoints.PointsSpaceTwo.ToString();
            }
            else
            {
                DataPoints.PointsSpaceOne++;
                pointsText.text = DataPoints.PointsSpaceOne.ToString();
            }

            Destroy(this.gameObject);
        }
    }
}


