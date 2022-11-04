using UnityEngine;
using UnityEngine.UI;

public class EatGoal : MonoBehaviour
{
    private Text pointsText;

    private void Start()
    {
        if (WTPoints.dimension)
            pointsText = GameObject.Find("pointsTwo").GetComponent<Text>();
        else
            pointsText = GameObject.Find("pointsOne").GetComponent<Text>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            if (WTPoints.dimension)
            {
                WTPoints.pointsSpaceTwo++;
                pointsText.text = WTPoints.pointsSpaceTwo.ToString();
            }
            else
            {
                WTPoints.pointsSpaceOne++;
                pointsText.text = WTPoints.pointsSpaceOne.ToString();
            }

            Destroy(this.gameObject);
        }
    }
}


