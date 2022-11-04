using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPortal : MonoBehaviour
{
    public GameObject EnterIn;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "player")
        {
            WTPoints.dimension = !WTPoints.dimension;

            if (gameObject.tag == "portalSpaceTwo")
            {
                if (WTPoints.pointsSpaceTwo < WTPoints.pointsSpaceOne)
                {
                    LoadLoserScene();
                    return;
                }

                Destroy(StartProcess.cloneSpaceTwo);

                StartProcess.cloneSpaceOne = Instantiate(EnterIn, Vector3.zero, Quaternion.identity);

                WTPoints.space = GameObject.Find("spaceOne");
                WTPoints.render = WTPoints.space.GetComponent<SpriteRenderer>();
            }
            else if(gameObject.tag == "portalSpaceOne")
            {
                if (WTPoints.pointsSpaceTwo > WTPoints.pointsSpaceOne)
                {
                    LoadLoserScene();
                    return;
                }

                Destroy(StartProcess.cloneSpaceOne);

                StartProcess.cloneSpaceTwo = Instantiate(EnterIn, Vector3.zero, Quaternion.identity);

                WTPoints.space = GameObject.Find("spaceTwo");
                WTPoints.render = WTPoints.space.GetComponent<SpriteRenderer>();
            }
        }
    }

    private void LoadLoserScene()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(2);
    }
}
