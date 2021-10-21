using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    [SerializeField] Slider _bar;
    [SerializeField] CharacterManager _owner;

    private void Start()
    {
        _owner._damageEvents.Add(DamageAction);
    }

    public void Setting(float maxHp)
    {
        _bar.maxValue = maxHp;
        _bar.value = maxHp;
    }

    public void UpdateHpBar(float hp) => _bar.value = hp;

    void DamageAction(float hp)
    {

    }
}
