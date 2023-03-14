using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _MenuPanel;
    [SerializeField] GameObject _GamePanel;
    [SerializeField] Slider _progressbar;
    // Start is called before the first frame update
    void Start()
    {
        _progressbar.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateProgressBar();
    }
    public void PlayButtonPressed()
    {
        GameManager._instance.SetGameState(GameManager.GameState.Game);
        _MenuPanel.SetActive(false);
    }
    void UpdateProgressBar()
    {
        if(!GameManager._instance.isGameState())
        {
            return;
        }
        _progressbar.value = Player_Controller._instance.transform.position.z/ChunkManager._instance.GetFinishLineZpos();
    }
}
