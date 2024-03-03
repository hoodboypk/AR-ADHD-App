using UnityEngine;

public class StackManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves a model we want to stack
        if (collision.gameObject.CompareTag("Stackable"))
        {
            // Get the mesh filters of the colliding objects
            MeshFilter[] meshFilters = new MeshFilter[2];
            meshFilters[0] = GetComponent<MeshFilter>(); // Mesh of the current object
            meshFilters[1] = collision.gameObject.GetComponent<MeshFilter>(); // Mesh of the collided object

            // Combine the meshes
            CombineInstance[] combine = new CombineInstance[2];
            for (int i = 0; i < 2; i++)
            {
                combine[i].mesh = meshFilters[i].sharedMesh;
                combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            }

            // Create a new GameObject to hold the combined mesh
            GameObject newObject = new GameObject("CombinedModel");
            MeshFilter newMeshFilter = newObject.AddComponent<MeshFilter>();
            newMeshFilter.mesh = new Mesh();
            newMeshFilter.mesh.CombineMeshes(combine);

            // Add a collider to the new combined object if needed
            newObject.AddComponent<MeshCollider>();

            // Optionally, destroy the original objects
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
