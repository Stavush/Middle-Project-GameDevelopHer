using UnityEngine;

public class BaseTrap : MonoBehaviour
{
    public int damage;
    public string AliceSize;

    public virtual void SpecificTrapBehavior()
    {
        
        Debug.Log("Specific trap behavior!");
    }
}