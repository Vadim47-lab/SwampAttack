using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private AudioClip _buttonPress;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnStartButtonClick()
    {
        PlayMusic();
        SceneManager.LoadScene(1);
    }

    private void OnExitButtonClick()
    {
        PlayMusic();
        Application.Quit();
    }

    private void PlayMusic()
    {
        GetComponent<AudioSource>().PlayOneShot(_buttonPress);
    }
}