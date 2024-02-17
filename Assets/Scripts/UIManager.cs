using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameoverpanel;
    private void Start()
    {
        gameoverpanel.SetActive(false);
        GameManager.rs += deactivatePanel;
        GameManager.gm += activatePanel;
    }
    private void activatePanel()
    {
        gameoverpanel.SetActive(true);
    }
    private void deactivatePanel() 
    {
        gameoverpanel.SetActive(false);
    }
    public void restart()
    {
        GameManager.rs?.Invoke();
    }
    private void Update()
    {

    }
}
