using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class BottonPlayAnimation : MonoBehaviour
{
    public SpriteRenderer triangleRender = null;
    public Text title;
    public int nextScene;

    private void Start()
    {
        if(triangleRender == null)
           title.text = PlayerPrefs.GetInt("Score").ToString();
    }

    private void Update()
    {
        if (transform.localScale.x < 2.5f)
        {
            transform.localScale += new Vector3(2, 2, 0) * Time.deltaTime;
            return;
        }
        
        AlphaChannel.RegulateText(title, 0.7f);

        if (triangleRender != null)
            AlphaChannel.RegulateSprite(triangleRender, 0.7f);
    }

    public void OnClickPlay() => SceneManager.LoadScene(nextScene);
}
