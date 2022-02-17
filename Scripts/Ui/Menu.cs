using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private AudioClip _buttonPress;

    public void OpenPanel(GameObject panel)
    {
        PlayMusic();
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        PlayMusic();
        panel.SetActive(false);
        Time.timeScale = 1;
    }
    public void ReturnMenu()
    {
        PlayMusic();
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        PlayMusic();
        Application.Quit();
    }

    private void PlayMusic()
    {
        GetComponent<AudioSource>().PlayOneShot(_buttonPress);
    }
}