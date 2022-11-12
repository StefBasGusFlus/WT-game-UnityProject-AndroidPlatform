using UnityEngine;

public class RotateElementBackground : MonoBehaviour
{
    [SerializeField] private int rotateSpeed;

    void Update() => transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
}
