using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPortal : MonoBehaviour
{
    [SerializeField] private GameObject EnterIn;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "player")
        {
            DataPoints.Dimension = !DataPoints.Dimension;

            if (gameObject.tag == "portalSpaceTwo")
            {
                if (DataPoints.PointsSpaceTwo < DataPoints.PointsSpaceOne)
                {
                    LoadLoserScene();
                    return;
                }

                Destroy(StartProcess.CloneSpaceTwo);

                StartProcess.CloneSpaceOne = Instantiate(EnterIn, Vector3.zero, Quaternion.identity);

                DataPoints.Space = GameObject.Find("spaceOne");
            }
            else if(gameObject.tag == "portalSpaceOne")
            {
                if (DataPoints.PointsSpaceTwo > DataPoints.PointsSpaceOne)
                {
                    LoadLoserScene();
                    return;
                }

                Destroy(StartProcess.CloneSpaceOne);

                StartProcess.CloneSpaceTwo = Instantiate(EnterIn, Vector3.zero, Quaternion.identity);

                DataPoints.Space = GameObject.Find("spaceTwo");
            }

            DataPoints.Render = DataPoints.Space.GetComponent<SpriteRenderer>();
        }
    }

    private void LoadLoserScene()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(2);
    }
}
