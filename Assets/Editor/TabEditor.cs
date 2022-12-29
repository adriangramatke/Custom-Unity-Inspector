using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Tab))]
public class TabEditor : Editor
{
    private Tab tab;
    private SerializedObject soTab;

    public SerializedProperty fullName;
    public SerializedProperty occupation;
    public SerializedProperty house;
    public SerializedProperty hasCar;

    public SerializedProperty age;
    public SerializedProperty income;
    public SerializedProperty debt;

    public SerializedProperty city;
    public SerializedProperty country;
    public SerializedProperty address;
    public SerializedProperty postalCode;

    public SerializedProperty favouriteColor;
    public SerializedProperty favouriteAnimal;
    public SerializedProperty favouriteNumber;

    public SerializedProperty username;
    public SerializedProperty password;

    private void OnEnable()
    {
        tab = (Tab)target;
        soTab = new SerializedObject(tab);

        fullName = soTab.FindProperty("fullName");
        occupation = soTab.FindProperty("occupation");
        house = soTab.FindProperty("house");
        hasCar = soTab.FindProperty("hasCar");

        age = soTab.FindProperty("age");
        income = soTab.FindProperty("income");
        debt = soTab.FindProperty("debt");

        city = soTab.FindProperty("city");
        country = soTab.FindProperty("country");
        address = soTab.FindProperty("address");
        postalCode = soTab.FindProperty("postalCode");

        favouriteColor = soTab.FindProperty("favouriteColor");
        favouriteAnimal = soTab.FindProperty("favouriteAnimal");
        favouriteNumber = soTab.FindProperty("favouriteNumber");

        username = soTab.FindProperty("username");
        password = soTab.FindProperty("password");
    }

    public override void OnInspectorGUI()
    {
        soTab.Update();

        EditorGUI.BeginChangeCheck();

        tab.toolbarTabTop = GUILayout.Toolbar(tab.toolbarTabTop, new string[] { "Individual Info", "Financial Info" });
        switch (tab.toolbarTabTop)
        {
            case 0:
                tab.toolbarTabBottom = 4;
                tab.currentTab = "Individual Info";
                break;
            case 1:
                tab.toolbarTabBottom = 4;
                tab.currentTab = "Financial Info";
                break;
        }

        tab.toolbarTabBottom = GUILayout.Toolbar(tab.toolbarTabBottom, new string[] { "Location", "Favourites", "Account" });
        switch (tab.toolbarTabBottom)
        {
            case 0:
                tab.toolbarTabTop = 4;
                tab.currentTab = "Location";
                break;
            case 1:
                tab.toolbarTabTop = 4;
                tab.currentTab = "Favourites";
                break;
            case 2:
                tab.toolbarTabTop = 4;
                tab.currentTab = "Account";
                break;
        }
        if (EditorGUI.EndChangeCheck())
        {
            soTab.ApplyModifiedProperties();
            GUI.FocusControl(null);
        }

        EditorGUI.BeginChangeCheck();
        switch (tab.currentTab)
        {
            case "Individual Info":
                EditorGUILayout.PropertyField(fullName);
                EditorGUILayout.PropertyField(occupation);
                EditorGUILayout.PropertyField(house);
                EditorGUILayout.PropertyField(hasCar);
                break;
            case "Financial Info":
                EditorGUILayout.IntSlider(age, 0, 100);
                EditorGUILayout.IntSlider(income, 0, 100000);
                EditorGUILayout.IntSlider(debt, 0, 100000);
                EditorGUILayout.Space(50);
                EditorGUI.ProgressBar(new Rect(18, 110, 200, 40), (float)debt.intValue/(float)income.intValue, "Debt to Income Ratio");
                break;
            case "Location":
                EditorGUILayout.PropertyField(city);
                EditorGUILayout.PropertyField(country);
                EditorGUILayout.PropertyField(address);
                EditorGUILayout.PropertyField(postalCode);
                break;
            case "Favourites":
                EditorGUILayout.PropertyField(favouriteColor);
                EditorGUILayout.PropertyField(favouriteAnimal);
                EditorGUILayout.PropertyField(favouriteNumber);
                break;
            case "Account":
                EditorGUILayout.PropertyField(username);
                EditorGUILayout.PropertyField(password);
                EditorGUILayout.Space(50);
                EditorGUI.ProgressBar(new Rect(18, 90, 200, 40), (float)password.stringValue.Length/20, "Password Strength");
                break;
        }

        if (EditorGUI.EndChangeCheck())
        {
            soTab.ApplyModifiedProperties();
        }
    }
}
