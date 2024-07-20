using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreen; // ссылка на Canvas 

    public void RestartGame()
    {
        // перезапуск игры 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowDeathScreen()
    {
        // показать экран смерти 
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
