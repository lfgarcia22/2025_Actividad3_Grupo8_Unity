using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Scriptable Objects/Game Manager SO")]
public class GameManagerSO : ScriptableObject
{
    private InventoryComponent inventoryComponent;

    public InventoryComponent InventoryComponent { get => inventoryComponent; }


    void OnEnable()
    {
        Debug.Log("GameManager - OnEnable");
        SceneManager.sceneLoaded += SceneLoaded;
    }

    void OnDisable()
    {
        Debug.Log("GameManager - ODisable");
        SceneManager.sceneLoaded -= SceneLoaded;
    }

    // Get reference to the player
    private void SceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        inventoryComponent = FindObjectsByType<InventoryComponent>(FindObjectsInactive.Exclude, FindObjectsSortMode.None)[0];
    }
}
