using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineConnector : MonoBehaviour
{
    [SerializeField] private Transform _a;
    [SerializeField] private Transform _b;
    [SerializeField] private float _smooth = 0.02f;

    private LineRenderer _lr;

    private void Awake()
    {
        _lr = GetComponent<LineRenderer>();
        _lr.useWorldSpace = true;
    }

    private void LateUpdate()
    {
        if (_a == null || _b == null)
            return;

        Vector3 posA = _a.position;
        Vector3 posB = _b.position;
        
        _lr.SetPosition(0, posA);
        _lr.SetPosition(1, Vector3.Lerp(_lr.GetPosition(1), posB, _smooth));
    }

    public void SetTargets(Transform a, Transform b)
    {
        _a = a;
        _b = b;
        
        Vector3 posA = _a.position;
        _lr.SetPosition(0, posA);
        _lr.SetPosition(1, posA);
    }
}