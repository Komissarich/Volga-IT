using UnityEngine;

[CreateAssetMenu]
public class Wave : ScriptableObject {

	[SerializeField, Range(0, 100)]
	public int amountofmelees;
    [SerializeField, Range(0, 100)]
    public int amountofdistants = 0;
    [SerializeField, Range(0, 100)]
    public int amountofbosses = 0;
    [SerializeField, Range(0, 100)]
    public int damagemultiplier = 0;
    [SerializeField, Range(0, 100)]
    public int healthmultiplier = 0;
    [SerializeField, Range(0, 100)]
    public float rateofspawning;

}