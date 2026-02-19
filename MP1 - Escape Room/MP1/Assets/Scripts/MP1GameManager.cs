using UnityEngine;
using TMPro;

public class MP1GameManager : MonoBehaviour
{
    // Progress = how many UNIQUE gates have been solved (0..3)
    public int progress = 0;
    public TextMeshProUGUI progressText;

    // Optional "escape" content
    public GameObject door;        // Door to open when ALL gates solved
    public GameObject obstruction; // Any blocker to remove when ALL gates solved

    // Track which gates are already counted (expects gateIndex = 1,2,3)
    private bool[] gateSolved = new bool[4];

    private void Start()
    {
        UpdateProgressUI();
    }

    /// <summary>
    /// Called by each Gate/Socket script when the CORRECT key is placed.
    /// gateIndex should be 1..3 (Gate1, Gate2, Gate3).
    /// </summary>
    public void OnGateSolved(int gateIndex)
    {
        // Safety: ignore bad indices
        if (gateIndex < 1 || gateIndex > 3) return;

        // Only count the first time this gate is solved
        if (gateSolved[gateIndex]) return;

        gateSolved[gateIndex] = true;
        progress++;

        UpdateProgressUI();

        // Win condition: ALL 3 gates solved
        if (progress >= 3)
        {
            TriggerWin();
        }
    }

    private void UpdateProgressUI()
    {
        if (!progressText) return;

        if (progress >= 3)
            progressText.text = "Progress: 3/3  Congrats!";
        else
            progressText.text = $"Progress: {progress}/3   \nCollect all 3 keys to escape!";
    }

    private void TriggerWin()
    {
        Debug.Log("WIN!");

        // Simple win "celebration": open door + remove obstruction
        if (door) door.transform.position += new Vector3(0, 2f, 0);
        if (obstruction) obstruction.SetActive(false);
    }
}
