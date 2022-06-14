using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPBar : MonoBehaviour
{
    public Slider Slider;
    public Vector3 Offset;

    private void Update() {
        Slider.transform.position=Camera.main.WorldToScreenPoint(transform.parent.position+Offset);

    }

    public void SetHP(float health, float maxHP){
        Slider.gameObject.SetActive(health<maxHP);
        Slider.value = health;
        Slider.maxValue = maxHP;
    }
}
