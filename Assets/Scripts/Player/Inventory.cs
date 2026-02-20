using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Lista de llaves obtenidas
    private HashSet<string> keys = new HashSet<string>();

    // Agregar llave
    public void AddKey(string keyID)
    {
        if (!keys.Contains(keyID))
        {
            keys.Add(keyID);
            Debug.Log("Llave obtenida: " + keyID);
        }
    }

    // Verificar si tiene una llave
    public bool HasKey(string keyID)
    {
        return keys.Contains(keyID);
    }
}
