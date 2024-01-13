using UnityEngine;

public class MazeModel : MonoBehaviour
{
    [SerializeField]
    public int mazeWidth = 10; // only for example
    public int mazeHeight = 10;

    public int startPositionX;
    public int startPositionY;

    public int exitPositionX;
    public int exitPositionY;

    private Vector3Int exitPosition;

    public Vector3Int ExitPosition => exitPosition;

    void Start()
    {
        exitPosition = new Vector3Int(exitPositionX, exitPositionY, 0);
    }
}
