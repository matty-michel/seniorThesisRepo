using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private RectTransform healthBar;
    private float health;
    private float maxHealth;
    [SerializeField] private float width;
    [SerializeField] private float height;

    public void SetMaxHealth(float healthVal)
    {
        maxHealth = healthVal;
    }

    public void SetHealth(float healthVal)
    {
        health = healthVal;
        float newWidth = ((health / maxHealth) * width);
        healthBar.sizeDelta = new Vector2(newWidth, height);
        Debug.Log("New health: " + health + "New width: " + newWidth);
    }
}
