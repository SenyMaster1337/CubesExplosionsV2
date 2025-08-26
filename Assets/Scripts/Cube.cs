using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _chanceSplitValue;

    private float _reducingChanceValue = 2.0f;

    public float GetChanceSplitValue => _chanceSplitValue;

    public void ChangeChanceSplitValue(float chanceValue)
    {
        _chanceSplitValue = chanceValue / _reducingChanceValue;
    }
}