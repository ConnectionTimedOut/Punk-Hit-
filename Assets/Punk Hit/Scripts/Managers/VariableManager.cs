using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Variables))]
public class VariableManager : MonoBehaviour {
    private Variables sceneVariables;

    [SerializeField]
    private UIManager uiManager;

    private List<GuitarTypes> guitarInventory = new List<GuitarTypes>();

    private int guitarIndex = 0;
    
    private void Start() {
        sceneVariables = GetComponent<Variables>();
        // Tramite sceneVariables.declarations ho accesso alle variabili di Visual Scripting
        
        AddGuitar(GuitarTypes.Media);
    }

    //Punti

    public int GetPoints() {
        return sceneVariables.declarations.Get<int>("punti");
    }

    public void SetPoints(int points) {
        sceneVariables.declarations.Set("punti", points);
        uiManager.UpdatePoints(GetPoints());

    }

    public void AddPoints(int points) {
        SetPoints(GetPoints() + points);
    }

    // Note

    public int GetNotes() {
        return sceneVariables.declarations.Get<int>("note");
    }

    public void SetNotes(int notes) {
        sceneVariables.declarations.Set("note", notes);
        uiManager.UpdateNotes(GetNotes());
    }

    public void AddNotes(int notes) {
        SetNotes(GetNotes() + notes);
    }

    //Fan

    public bool[] GetFanArray() {
        return sceneVariables.declarations.Get<List<bool>>("listaFan").ToArray();
    }
    
    public bool GetFan(int index) {
        return sceneVariables.declarations.Get<List<bool>>("listaFan")[index];
    }

    public void SetFan(int index, bool value = true) {
        sceneVariables.declarations.Get<List<bool>>("listaFan")[index] = value;
    }
    
    //Chitarre

    public void AddGuitar(GuitarTypes type) {
        guitarInventory.Add(type);
    }

    public GuitarTypes GetSelectedGuitar() {
        return guitarInventory[guitarIndex];
    }

    public GuitarTypes SelectNextGuitar() {
        guitarIndex++;
        if (guitarIndex >= guitarInventory.Count) guitarIndex = 0;
        return GetSelectedGuitar();
    }
}
