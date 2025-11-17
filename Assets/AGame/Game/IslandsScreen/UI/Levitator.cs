using UnityEngine;

public class Levitator : MonoBehaviour
{
    [Header("Floating Settings")]
    [SerializeField] private float amplitude = 0.2f;     // Наскільки високо/низько рухається
    [SerializeField] private float frequency = 1f;        // Швидкість руху

    [Header("Optional Rotation")]
    [SerializeField] private bool rotate = false;
    [SerializeField] private float rotationSpeed = 30f;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.localPosition;
    }

    private void Update()
    {
        // Вертикальна левітація
        float y = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.localPosition = startPos + new Vector3(0, y, 0);

        // Додаткова легка ротація
        if (rotate)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}