using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace src.UIManipulations
{
    public class UIManager : MonoBehaviour
    {
        [Header("General Panel")] [SerializeField] private GameObject generalPanel;
        [SerializeField] private TMP_Text moneyAmount;
        [SerializeField] private Button tapToStartBtn;
        [SerializeField] private Button pauseBtn;

        [Header("Loading Panel")] [SerializeField] private GameObject loadingPanel;
        [SerializeField] private float loadingDuration = 2;

        [Header("Pause Panel")] [SerializeField] private GameObject pausePanel;
        [SerializeField] private GameObject pausePanelPopup;
        [SerializeField] private Button resumeBtn;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button closeButton;

        [Header("Settings Panel")] [SerializeField] private GameObject settingsPanel;
        [SerializeField] private GameObject settingsPanelPopup;
        [SerializeField] private Slider soundSlider;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Toggle notificationToggle;
        [SerializeField] private Button settingsCloseButton;


        private void Awake()
        {
            tapToStartBtn.onClick.AddListener(StartGame);
            pauseBtn.onClick.AddListener(OpenPausePanel);
            settingsButton.onClick.AddListener(OpenSettingsPanel);
            closeButton.onClick.AddListener(ClosePausePanel);
            settingsCloseButton.onClick.AddListener(CloseSettingsPanel);
            resumeBtn.onClick.AddListener(ResumeGame);
            Time.timeScale = 0;
        }

        private void ResumeGame()
        {
            Time.timeScale = 1;
            Image panelImg = pausePanel.GetComponent<Image>();
            DOTween.To(() => panelImg.color, x => panelImg.color = x, new Color32(32, 32, 32, 0), 0.2f);
            pausePanelPopup.transform.DOScale(0f, 0.2f).OnComplete(() =>
            {
                pausePanel.SetActive(false);
                pausePanelPopup.SetActive(false);
            });
        }

        private void Start()
        {
            OpenLoadingPanel();
        }

        void OpenGeneralPanel()
        {
            generalPanel.SetActive(true);
        }

        void CloseGeneralPanel()
        {
            generalPanel.SetActive(false);
        }

        void OpenLoadingPanel()
        {
            StartCoroutine(LoadingPanelAnimation());
            loadingPanel.SetActive(true);
        }

        void CloseLoadingPanel()
        {
            loadingPanel.SetActive(false);
        }

        void OpenSettingsPanel()
        {
            
            settingsPanel.SetActive(true);
            settingsPanelPopup.SetActive(true);
            settingsPanelPopup.transform.localScale = Vector3.zero;
            Image panelImg = settingsPanel.GetComponent<Image>();
            panelImg.color = new Color(0, 0, 0, 0);
            DOTween.To(() => panelImg.color, x => panelImg.color = x, new Color32(32, 32, 32, 180), 0.2f);
            settingsPanelPopup.transform.DOScale(1f, 0.2f).SetUpdate(true);
        }
        void CloseSettingsPanel()
        {
            
            Image panelImg = settingsPanel.GetComponent<Image>();
            DOTween.To(() => panelImg.color, x => panelImg.color = x, new Color32(32, 32, 32, 0), 0.2f);
            settingsPanelPopup.transform.DOScale(0f, 0.2f).OnComplete(() =>
            {
                settingsPanel.SetActive(false);
                settingsPanelPopup.SetActive(false);
            }).SetUpdate(true);
        }

        void OpenPausePanel()
        {
            
            pausePanel.SetActive(true);
            pausePanelPopup.SetActive(true);
            pausePanelPopup.transform.localScale = Vector3.zero;
            Image panelImg = pausePanel.GetComponent<Image>();
            panelImg.color = new Color(0, 0, 0, 0);
            DOTween.To(() => panelImg.color, x => panelImg.color = x, new Color32(32, 32, 32, 180), 0.2f);
            pausePanelPopup.transform.DOScale(1f, 0.2f).OnComplete(() =>
            {
                Time.timeScale = 0;
            });
        }
        
        void ClosePausePanel()
        {
            Time.timeScale = 1;
            Image panelImg = pausePanel.GetComponent<Image>();
            DOTween.To(() => panelImg.color, x => panelImg.color = x, new Color32(32, 32, 32, 0), 0.2f);
            pausePanelPopup.transform.DOScale(0f, 0.2f).OnComplete(() =>
            {
                pausePanel.SetActive(false);
                pausePanelPopup.SetActive(false);
            });
        }

        void StartGame()
        {
            Time.timeScale = 1;
            tapToStartBtn.gameObject.SetActive(false);
        }

        IEnumerator LoadingPanelAnimation()
        {
            yield return new WaitForSecondsRealtime(loadingDuration);
            CloseLoadingPanel();
            OpenGeneralPanel();
        }
    }
}