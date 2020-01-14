using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI goldText;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void SetGold(int gold)
	{
		goldText.text = gold.ToString();
	}
}
