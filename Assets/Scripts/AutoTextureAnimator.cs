using UnityEngine;
using System.Collections;
using System.Linq; // Used for sorting the textures by name

public class AutoTextureAnimator : MonoBehaviour
{
    [Header("Animation Settings")]
    [Tooltip("The path to the folder inside a 'Resources' folder. E.g., 'EarthFrames'")]
    public string folderPathInResources;

    [Tooltip("The time in seconds to wait before switching to the next texture.")]
    public float secondsPerFrame = 1.0f;

    // Private variables
    private Renderer objectRenderer;
    private Texture2D[] animationFrames;
    private Coroutine animationCoroutine;

    void Start()
    {
        // Get the Renderer component attached to this GameObject
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer == null)
        {
            Debug.LogError("AutoTextureAnimator Error: No Renderer component found on this object.");
            return; // Stop the script if there's no renderer
        }

        // Load all textures from the specified folder
        LoadTexturesFromResources();

        // Start the animation loop if textures were found
        if (animationFrames != null && animationFrames.Length > 0)
        {
            animationCoroutine = StartCoroutine(AnimateTextures());
        }
    }

    void LoadTexturesFromResources()
    {
        if (string.IsNullOrEmpty(folderPathInResources))
        {
            Debug.LogError("Folder path is not specified in the Inspector!");
            return;
        }

        // Load all assets of type Texture2D from the given folder within any "Resources" folder
        animationFrames = Resources.LoadAll<Texture2D>(folderPathInResources);

        if (animationFrames.Length == 0)
        {
            Debug.LogError($"No textures found in 'Resources/{folderPathInResources}'. Please check the path and make sure the images are in a Resources folder.");
        }
        else
        {
            // Sort the textures alphabetically by name to ensure correct playback order
            animationFrames = animationFrames.OrderBy(t => t.name).ToArray();
            Debug.Log($"Loaded {animationFrames.Length} texture frames.");
        }
    }

    IEnumerator AnimateTextures()
    {
        int currentFrameIndex = 0;
        
        // Loop forever
        while (true)
        {
            // Set the main texture of the material
            objectRenderer.material.SetTexture("_MainTex", animationFrames[currentFrameIndex]);

            // Move to the next frame, looping back to the start if at the end
            currentFrameIndex = (currentFrameIndex + 1) % animationFrames.Length;

            // Wait for the specified amount of time before continuing the loop
            yield return new WaitForSeconds(secondsPerFrame);
        }
    }
}