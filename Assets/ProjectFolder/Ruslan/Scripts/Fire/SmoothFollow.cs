using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _heartTransform;
    [SerializeField] private Transform _followTarget;
    [SerializeField] private float _heartSmoothTime = 0.3f;

    private Vector3 _heartVelocity = Vector3.zero;

    public float radius = 0.1f; // ������ � �������� �������� ���������� �����
    public float _targetSmoothTime = 0.2f; // ����� �����������
    public float _pointStayTime = 1f; // ����� �������� ����� ������ �����

    private Vector3 _targetPoint; // ������� ����
    private Vector3 _targetVelocity = Vector3.zero; // ������ ��������
    private float _waitTime; // ����� �������� ����� ������ �����

    private void Start()
    {
        _heartTransform.parent = null;

        // �������� ��������� ����
        PickNewTarget();
    }

    void FixedUpdate()
    {
        MoveHeart();
        MoveTarget();
    }

    private void MoveHeart()
    {
        if (_target == null) return;
        _heartTransform.position = Vector3.SmoothDamp(_heartTransform.position, _target.position, ref _heartVelocity, _heartSmoothTime);
    }

    private void MoveTarget()
    {
        if (_followTarget == null) return; // ������ �� ������

        _target.localPosition = Vector3.SmoothDamp(_target.localPosition, _targetPoint, ref _targetVelocity, _targetSmoothTime);

        // ���� ����� �������� ����, ���� ����� ������� ����� �����
        if (Vector3.Distance(_target.localPosition, _targetPoint) < 0.05f) // �������� �����
        {
            _waitTime -= Time.deltaTime;
            if (_waitTime <= 0)
            {
                PickNewTarget();
            }
        }
    }

    void PickNewTarget()
    {
        if (_followTarget == null) return;

        // �������� ��������� ����� ������ _followTarget
        Vector2 randomOffset = Random.insideUnitCircle * radius;
        _targetPoint = _followTarget.localPosition + new Vector3(randomOffset.x, randomOffset.y, 0);

        _waitTime = _pointStayTime; // ������������� ������ ��������
    }
}
