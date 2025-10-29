using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown modeDropdown;
    public TextMeshProUGUI errorText;

    public void LoadGameScene()
    {
        Time.timeScale = 1.0f;
        if (modeDropdown.options[modeDropdown.value].text != "Choose Tower Type")
        {
            GameMode.chosenMode = modeDropdown.options[modeDropdown.value].text;
            SceneManager.LoadScene("TowerScene");
        }
        else
        {
            errorText.gameObject.SetActive(true);
        }
    }

    public void LoadMenuScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MenuScene");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
