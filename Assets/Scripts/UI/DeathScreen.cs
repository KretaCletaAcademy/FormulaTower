using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreen; // ������ �� Canvas 

    public void RestartGame()
    {
        // ���������� ���� 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowDeathScreen()
    {
        // �������� ����� ������ 
        deathScreen.SetActive(true);
    }

    public void HideDeathScreen()
    {
        deathScreen.SetActive(false);
    }

    private void Start()
    {
        HideDeathScreen();
    }
}
