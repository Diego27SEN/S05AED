using UnityEngine;
[System.Serializable]
public class GameState
{
    public Vector3 playerPosition;
    public int playerHP;
    public int playerAttack;

    public List<Vector3> enemyPositions;
}
