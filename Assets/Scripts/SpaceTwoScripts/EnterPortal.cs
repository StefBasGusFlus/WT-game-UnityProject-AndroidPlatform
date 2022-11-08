using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPortal : MonoBehaviour
{
    [SerializeField] private GameObject EnterIn;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "player")
        {
            DataPoints.dimension = !DataPoints.dimension;

            if (gameObject.tag == "portalSpaceTwo")
            {
                if (DataPoints.pointsSpaceTwo < DataPoints.pointsSpaceOne)
                {
                    LoadLoserScene();
                    return;
                }

                Destroy(StartProcess.cloneSpaceTwo);

                StartProcess.cloneSpaceOne = Instantiate(EnterIn, Vector3.zero, Quaternion.identity);

                DataPoints.space = GameObject.Find("spaceOne");
            }
            else if(gameObject.tag == "portalSpaceOne")
            {
                if (DataPoints.pointsSpaceTwo > DataPoints.pointsSpaceOne)
                {
                    LoadLoserScene();
                    return;
                }

                Destroy(StartProcess.cloneSpaceOne);

                StartProcess.cloneSpaceTwo = Instantiate(EnterIn, Vector3.zero, Quaternion.identity);

                DataPoints.space = GameObject.Find("spaceTwo");
            }

            DataPoints.render = DataPoints.space.GetComponent<SpriteRenderer>();
        }
    }

    private void LoadLoserScene()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(2);
    }
}
