using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Block : MonoBehaviour
{
    public State currentState;
    private InputController _inputController;

    public bool IsSelected { get; private set; }
    public Vector3 StartPosition { get; private set; }
    public Vector3 Position
    {
        get => transform.position;
        set => transform.position = value;
    }

    [SerializeField, HideInInspector]
    private Renderer renderer;
    public Material material
    {
        set => renderer.material = value;
    }

    private void OnValidate()
    {
        if (renderer == null)
            renderer = GetComponent<Renderer>();
    }

    private void Awake()
    {
        GameManager.Instance.StartGame += StartGame;
        StartPosition = transform.position;
        currentState = new Plane(this);
    }

    private void FixedUpdate()
    {
        currentState.Move();
    }

    public void Select()
    {
        IsSelected = true;
    }

    private void StartGame()
    {
        currentState.Select(IsSelected);
        currentState.StartGame();
    }

    private void OnMouseDown()
    {
        _inputController = new InputController(Input.mousePosition, Time.time);
    }

    private void OnMouseUp()
    {
        currentState.Swipe(_inputController.FindDirection(Input.mousePosition, Time.time));
    }
    private void OnCollisionEnter(Collision other)
    {
        if(!currentState.DieOnCollision)
            return;

        if(other.collider.CompareTag(Const.WallTag))
        {
            GameManager.Instance.StopGame(false);
        }
    }
}
