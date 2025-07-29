using UnityEngine;
// namespace getReal3D
//{
public class TextureChanger : MonoBehaviour
{
    // Assign your textures (PNGs) in the Inspector
    public Texture[] albedoTextures;

    private int currentIndex = 0;
    private Renderer objectRenderer;

    void Start()
    {
        // Get the Renderer component from the object this script is attached to
        objectRenderer = GetComponent<Renderer>();

        // Optional: Set the initial texture on start
        if (albedoTextures.Length > 0)
        {
            objectRenderer.material.SetTexture("_MainTex", albedoTextures[0]);
        }
    }

    void Update()
    {
        // Check if the space bar is pressed down
         if (Input.GetKeyDown(KeyCode.C))
        //if (Input.GetButtonDown("WandDrive"))
        {
            // Make sure there are textures to switch to
            if (albedoTextures.Length == 0)
            {
                Debug.LogWarning("No textures assigned to the TextureChanger script.");
                return;
            }

            // Move to the next texture index
            currentIndex++;

            // If we've gone past the end of the array, loop back to the start
            if (currentIndex >= albedoTextures.Length)
            {
                currentIndex = 0;
            }

            // Change the material's main texture (Albedo)
            // "_MainTex" is the standard property name for the albedo texture in Unity's Standard Shader.
            objectRenderer.material.SetTexture("_MainTex", albedoTextures[currentIndex]);
        }
    }
}
//}