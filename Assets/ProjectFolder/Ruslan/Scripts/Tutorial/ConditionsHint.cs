using UnityEngine;

public class ConditionsHint : TutorialHint
{
    [SerializeField] private string _noFireText = "����� ����� ������ ������. ����� ��� �� ������ �������!";
    [SerializeField] private string _noBonfireText = "���� ����� ���� �� ������ ���� ������! ����� ������ ������, ����� �� ���������...";

    public void SetHintText(bool isNoBonfire)
    {
        _hintText = isNoBonfire ? _noBonfireText : _noFireText;
    }
}
