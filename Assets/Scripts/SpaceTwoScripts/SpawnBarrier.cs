using System.Collections;
using UnityEngine;

public class SpawnBarrier : MonoBehaviour
{
    [SerializeField] private GameObject[] barriersTopOrLeft;
    [SerializeField] private GameObject[] barriersDownOrRight;

    [SerializeField] private GameObject[] portals;

    private Bounds boundsGameField;

    private float x;
    private float y;

    private const float SHIFT = 0.52f;
    private float shiftY;
    private float shiftX;

    private void Start()
    {
        boundsGameField = gameObject.GetComponent<BoxCollider2D>().bounds;

        if (gameObject.tag == "SpaceTwo")
        {
            x = boundsGameField.max.x;
            y = boundsGameField.center.y;
            shiftY = SHIFT;
            shiftX = 0;

        }
        else if (gameObject.tag == "SpaceOne")
        {
            x = boundsGameField.center.x;
            y = boundsGameField.max.y;
            shiftY = 0;
            shiftX = SHIFT;
        }

        Repeat();
    }

    private void Repeat() => StartCoroutine(SpawnGenerator());

    IEnumerator SpawnGenerator()
    {
        yield return new WaitForSeconds(1);
        int randomElement = Random.Range(0, barriersTopOrLeft.Length);
        Create(barriersTopOrLeft[randomElement], new Vector3(x - shiftX, y + shiftY, 0));

        yield return new WaitForSeconds(2);
        randomElement = Random.Range(0, barriersDownOrRight.Length);
        Create(barriersDownOrRight[randomElement], new Vector3(x + shiftX, y - shiftY, 0));

        yield return new WaitForSeconds(2.5f);
        randomElement = Random.Range(0, portals.Length);
        Create(portals[randomElement], new Vector3(x, y, 0));

        Repeat();
    }

    private void Create(GameObject prefab, Vector3 position)
    {
        GameObject clone = Instantiate(prefab, position, Quaternion.identity);
        clone.transform.SetParent(transform);
    }
}
