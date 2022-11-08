using UnityEngine;
using UnityEngine.UI;

public class EatGoal : MonoBehaviour
{
    private Text pointsText;

    private void Start()
    {
        if (DataPoints.dimension)
            pointsText = GameObject.Find("pointsTwo").GetComponent<Text>();
        else
            pointsText = GameObject.Find("pointsOne").GetComponent<Text>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            if (DataPoints.dimension)
            {
                DataPoints.pointsSpaceTwo++;
                pointsText.text = DataPoints.pointsSpaceTwo.ToString();
            }
            else
            {
                DataPoints.pointsSpaceOne++;
                pointsText.text = DataPoints.pointsSpaceOne.ToString();
            }

            Destroy(this.gameObject);
        }
    }
}


