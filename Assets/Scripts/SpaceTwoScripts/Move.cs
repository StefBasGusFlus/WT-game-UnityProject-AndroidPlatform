using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speedLeft;
    [SerializeField] private float speedDown;

    private void Update() =>
        transform.position -= new Vector3(speedLeft * Time.deltaTime, speedDown * Time.deltaTime);

    private void OnTriggerExit2D(Collider2D collision) => Destroy(this.gameObject);
}
