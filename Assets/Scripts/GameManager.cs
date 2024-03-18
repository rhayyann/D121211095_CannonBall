using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject[] wallGroupPrefabs;
    public Transform wallGroupSpawnPosition;
    //public List<Transform> wallOfBricks = new List<Transform>();
    public int fallenBrickAmount, fallenBrickNeeded;
    public event Action setAmmo;

    public TextMeshProUGUI levelText;
    public static int level = 1;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnWallGroup(UnityEngine.Random.Range(0, wallGroupPrefabs.Length));
        levelText.text = "Level: " + level;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            RestartGame();
        }
    }

    public void SetAmmo()
    {
        setAmmo?.Invoke();
    }
    void SpawnWallGroup(int wallGroupIndex)
    {
        Instantiate(wallGroupPrefabs[wallGroupIndex], wallGroupSpawnPosition.position, Quaternion.identity);
    }
    //void SetFallenBrickNeeded()
    //{
    //    foreach(var wallOfBrick in wallOfBricks)
    //    {
    //        fallenBrickNeeded += wallOfBrick.childCount;
    //    }
    //}


    public void BrickFall()
    {
        fallenBrickAmount++;
        if (fallenBrickAmount>=fallenBrickNeeded)
        {
            level++;
            print("You win");
            RestartGame();
        }
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
