using System.Collections;
using System.Collections.Generic;
using SkeletonEditor;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Sword swordWeapon;
    [SerializeField] private PlayerController playerHero;
    [SerializeField] private GameObject gameOverCanvas;
    
    [Header("UI")]
    [SerializeField] private TMP_Text labelExpCounter;
    [SerializeField] private TMP_Text labelHealthCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        labelExpCounter.SetText(swordWeapon.CollectedExp.ToString());
        labelHealthCounter.SetText(playerHero.HealthPoints.ToString());
        if (playerHero.HealthPoints < 1)
        {
            Cursor.lockState = CursorLockMode.None;
            gameOverCanvas.SetActive(true);
        }
    }

    public void RestartButtonFunc()
    {
        SceneManager.LoadScene("Modular Dungeon");
    }
}
