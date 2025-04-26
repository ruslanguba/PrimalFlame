using System.Collections;
using UnityEngine;

public class ImageHint : HintBase
{
    [SerializeField] private float _showDuration;
    private SpriteRenderer _sprite;
    private Color _color;
    private Coroutine _coroutine;

    private void Start()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _color = _sprite.color;
        HideImage();
    }

    public override void ShowHint(float duration)
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _showDuration = duration;
        _coroutine = StartCoroutine(SetHintVisible());
    }

    private IEnumerator SetHintVisible()
    {
        ShowImage();
        // ������� ���������� ������������
        float elapsedTime = 0f;
        while (elapsedTime < _showDuration)
        {
            float progress = elapsedTime / _showDuration;
            Color currentColor = _sprite.color;
            currentColor.a = Mathf.Lerp(1f, 0f, progress); // ������� ������������� �� 1 �� 0
            _sprite.color = currentColor;

            elapsedTime += Time.deltaTime;
            yield return null; // ���� ��������� ����
        }

        HideImage();
    }

    private void HideImage()
    {
        _color.a = 0; // ������������� ��������� ����� ��� 1 (��������� �������)
        _sprite.color = _color;
    }

    private void ShowImage()
    {
        _color.a = 1;
        _sprite.color = _color;
    }
}
