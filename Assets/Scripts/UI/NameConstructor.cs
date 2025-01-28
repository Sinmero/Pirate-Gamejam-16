using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameConstructor : DisplayText
{
    [SerializeField] NameLists _namelists;
    [SerializeField] Player player;


    public override void Start()
    {
        _textToDisplay = GenerateName();
        base.Start();

        player.IonDeath += OnPlayerDeath;
    }

    
    
    public string GenerateName() {
        string firstName = _namelists._names[Random.Range(1, _namelists._names.Count - 1)];
        string title = _namelists._titles[Random.Range(1, _namelists._titles.Count - 1)];

        string name = firstName + " " + title;
        Debug.Log(name);

        return name;
    }



    public void OnPlayerDeath() {
        string message = _textMeshPro.text + " has falled. But you still remain.";
        DoDisplayText(message);
    }
}
