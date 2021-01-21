using UnityEngine;
using UnityEngine.UI;

namespace PauseMenu
{
    public class PauseSystem : MonoBehaviour
    {
        [SerializeField] private GameObject pauseCanvas;
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button exitButton;

        public static bool IsGamePaused;

        private void Awake()
        {
            resumeButton.onClick.AddListener(ResumeButton_OnClicked);
            exitButton.onClick.AddListener(ExitButton_OnClicked);
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            IsGamePaused = !IsGamePaused;
            ChangeGameState();
        }

        private void ChangeGameState()
        {
            if (IsGamePaused)
            {
                Time.timeScale = 0;
                pauseCanvas.SetActive(true);
            } else
            {
                Time.timeScale = 1;
                pauseCanvas.SetActive(false);
            }
        }

        private void ResumeButton_OnClicked()
        {
            IsGamePaused = false;
            ChangeGameState();
        }

        private void ExitButton_OnClicked()
        {
            Application.Quit();
        }
    }
}
