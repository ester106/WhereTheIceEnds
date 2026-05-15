using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
{
    public PlayerHealth player;
    public Image[] hearts;

    void Update()
    {
        if (player == null) return;

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < player.currentHealth;
        }
    }
}