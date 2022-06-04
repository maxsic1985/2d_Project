using UnityEngine;
using UnityEngine.UI;

public class MaimMenuView : MonoBehaviour
{
    [SerializeField] private GameObject _Level1;
    [SerializeField] private GameObject _generator;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform root;
    [SerializeField] private GameObject _viewMenu;
    [SerializeField] private Button _buttonStart;
    [SerializeField] private Button _buttonGetLabirint;
    [SerializeField] private Button _buttonQuit;

    void Start()
    {
        _buttonStart.onClick.AddListener(StartGame);
        _buttonGetLabirint.onClick.AddListener(StartLabirint);
        _buttonQuit.onClick.AddListener(ExitGame);
    }
    private void StartGame()
    {
        Instantiate((_Level1), root.position, Quaternion.identity);
        _camera.enabled = false;
        _viewMenu.SetActive(false);
    }
    private void StartLabirint()
    {
        Instantiate((_generator), root.position, Quaternion.identity);
        _viewMenu.SetActive(false);
    }
    private void ExitGame() => Application.Quit();
    protected void OnDestroy()
    {
        _buttonStart.onClick.RemoveAllListeners();
        _buttonGetLabirint.onClick.RemoveAllListeners();
        _buttonQuit.onClick.RemoveAllListeners();
    }
}
