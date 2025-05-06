using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    [Header("Configuración de aparición de objetos")]
    [SerializeField] private GameObject objectPrefab;        // Prefab del objeto a instanciar
    [SerializeField] private float spawnInterval = 2.0f;      // Tiempo entre cada generación
    [SerializeField] private int maxObjects = 10;             // Máximo número de objetos activos en escena
    [SerializeField] private float spawnMinX = -5f;           // Límite mínimo en X para generar objetos
    [SerializeField] private float spawnMaxX = 5f;            // Límite máximo en X
    [SerializeField] private float spawnMinZ = -5f;           // Límite mínimo en Z
    [SerializeField] private float spawnMaxZ = 5f;            // Límite máximo en Z
    [SerializeField] private float spawnHeight = 0.5f;        // Altura (Y) a la que se generarán los objetos
    
    [Header("Referencias UI")]
    [SerializeField] private TextMeshProUGUI objectCounter;   // Referencia al contador de UI (TextMeshPro)

    // Lista que mantiene el registro de los objetos generados
    private List<GameObject> spawnedObjects = new List<GameObject>();
    
    // Temporizador para controlar el intervalo de generación
    private float spawnTimer = 0f;

    // Se ejecuta una vez al iniciar el script
    void Start()
    {
        // Actualiza el contador de objetos al inicio
        UpdateObjectCounter();
    }

    // Se ejecuta una vez por cada frame
    void Update()
    {
        // Solo se generan objetos si aún no se ha alcanzado el máximo
        if (spawnedObjects.Count < maxObjects)
        {
            // Incrementa el temporizador con el tiempo que ha pasado desde el último frame
            spawnTimer += Time.deltaTime;
            
            // Si ha pasado el intervalo definido, se genera un nuevo objeto
            if (spawnTimer >= spawnInterval)
            {
                SpawnObject();
                spawnTimer = 0f; // Reinicia el temporizador
            }
        }

        // Limpia de la lista cualquier objeto que haya sido destruido
        CleanupDestroyedObjects();
    }

    // Método que genera un nuevo objeto en una posición aleatoria
    void SpawnObject()
    {
        // Calcula una posición aleatoria dentro del área definida
        float randomX = Random.Range(spawnMinX, spawnMaxX);
        float randomZ = Random.Range(spawnMinZ, spawnMaxZ);
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, randomZ);
        
        // Instancia el objeto en la posición calculada
        GameObject newObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        
        // Le asigna un nombre descriptivo
        newObject.name = "SpawnedObject_" + spawnedObjects.Count;
        
        // Lo agrega a la lista de seguimiento
        spawnedObjects.Add(newObject);
        
        // Actualiza el contador en la interfaz
        UpdateObjectCounter();
    }

    // Método que elimina de la lista los objetos que han sido destruidos
    void CleanupDestroyedObjects()
    {
        // Elimina las referencias nulas de la lista (es decir, objetos destruidos)
        spawnedObjects.RemoveAll(item => item == null);
        
        // Actualiza el contador en la interfaz
        UpdateObjectCounter();
    }

    // Método que actualiza el texto del contador de objetos en la UI
    void UpdateObjectCounter()
    {
        if (objectCounter != null)
        {
            objectCounter.text = "Objetos: " + spawnedObjects.Count.ToString() + " / " + maxObjects.ToString();
        }
    }
}
