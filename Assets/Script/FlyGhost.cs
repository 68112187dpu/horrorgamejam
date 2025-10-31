
using UnityEngine;

public class FlyGhost : MonoBehaviour
{
    public GameObject fg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fg.transform.Translate(Vector2.right * 5f * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.gameObject.CompareTag("EditorOnly"))
        {
            Destroy(fg);
        }
    }
}
