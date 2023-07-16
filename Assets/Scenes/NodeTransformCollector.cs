using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NodeTransformCollector : MonoBehaviour
{
    [SerializeField] private Transform nodesParent;
    [SerializeField] private GameObject nodePrefab;
    [SerializeField] private string newNodesParentName = "NewNodesParent";

    private void Start()
    {
        if (nodesParent == null)
        {
            Debug.LogError("Nodes parent object is not assigned!");
            return;
        }

        // Create a new parent object to hold the instantiated prefabs
        GameObject newNodesParent = new GameObject(newNodesParentName);

        // Collect positions and transforms of child objects
        List<Vector3> nodePositions = new List<Vector3>();
        List<Quaternion> nodeRotations = new List<Quaternion>();
        foreach (Transform child in nodesParent)
        {
            nodePositions.Add(child.position);
            nodeRotations.Add(child.rotation);

            // Instantiate new node prefabs under the new parent object
            GameObject newNode = Instantiate(nodePrefab, child.position, child.rotation, newNodesParent.transform);
            // Add any additional setup or modifications to the new node here
        }

        // Save the new parent object as a prefab
        string prefabPath = "Assets/Prefabs/" + newNodesParentName + ".prefab";
        PrefabUtility.SaveAsPrefabAsset(newNodesParent, prefabPath);

        // Destroy the temporary new parent object from the scene
        Destroy(newNodesParent);
    }
}
