using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public Vector3 mousePos;
    public Vector3 mousePosWorld;
    public Vector2 mousePosWorld2D;
    public Camera mainCamera;
    RaycastHit2D hit;

    [SerializeField] CharacterDialogue[] characters;
    [SerializeField] public CharacterDialogue activeCharacter;
    void Start()
    {
        Load();
        if (SaveSystem.Instance.playerData.MajorState != "Return")
        {
            characters[0].StartDialogue("Initial", false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!activeCharacter)
            {
                mousePos = Input.mousePosition;
                mousePosWorld = mainCamera.ScreenToWorldPoint(mousePos);
                mousePosWorld2D = new Vector2(mousePosWorld.x, mousePosWorld.y);
                hit = Physics2D.Raycast(mousePosWorld2D, Vector2.zero);
                if (hit.collider != null && !EventSystem.current.IsPointerOverGameObject())
                {
                    if (hit.collider.GetComponent<CharacterDialogue>())
                    {
                        hit.collider.GetComponent<CharacterDialogue>().StartDialogue("Initial", true);
                    }
                    else if (hit.collider.GetComponent<Portal>())
                    {
                        hit.collider.GetComponent<Portal>().MoveToPlace();
                    }
                }
            }
            else 
            {
                activeCharacter.ShowNextLine();
            }
        }
    }

    public void Save()
    {
        SaveSystem.Instance.SavePlayer();
    }

    public void Load()
    {
        SaveSystem.Instance.LoadPlayerData();
    }
}