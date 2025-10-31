
using UnityEngine;

public class FadingUI : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GhostDeklogic.dekjump == true)
        {
            canvasGroup.alpha -= Time.deltaTime / 3f;
        }
    }

    // Call this function to start the fade-out
    


}
