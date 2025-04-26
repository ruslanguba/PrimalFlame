using UnityEngine;

public class FlyAround : MonoBehaviour
{
    [SerializeField] private Transform _patrolCenter;  // ����� ��������
    [SerializeField] private float _radius = 2f;       // ������, � ������� ���������� ��������� �����
    [SerializeField] private float _moveSpeed = 1f;    // �������� ��������
    [SerializeField] private float _randomTimeOffset = 0f; // ��������� �������� ������� ��� ������� �������

    private float _time; // ����� ��� �������� ����������� ��������

    void Start()
    {
        // ��������� ��������� ����� � ������� �� ������ ��� ������� �������
        Vector2 randomDirection = Random.insideUnitCircle.normalized; // ��������� ���������� �����������
        Vector2 randomPosition = _patrolCenter.position + (Vector3)(randomDirection * _radius); // �������� �� ������ � ���������� � ������

        // ������������� ������ � ��������� �����
        transform.position = randomPosition;

        // ��������� �������� ������� ��� ������� �������
        _randomTimeOffset = Random.Range(0f, Mathf.PI * 2f); // ��������� ���������� �������� �������
    }

    void Update()
    {
        // ����������� ����� � ������ �������� ��� ������� �������
        _time += Time.deltaTime * _moveSpeed;

        // ��������� ��������� �������� �������
        float x = Mathf.Sin(_time + _randomTimeOffset) * _radius;  // �������������� ����������
        float y = Mathf.Sin(_time * 0.5f + _randomTimeOffset) * _radius; // ������������ ����������

        // ���������� ������
        transform.position = new Vector2(_patrolCenter.position.x + x, _patrolCenter.position.y + y);
    }
}
