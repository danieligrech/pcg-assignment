using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsBuilder
{
    private List<Material> materialsListSkyscraper = new List<Material>();
    private List<Material> materialsListBase = new List<Material>();
    private List<Material> materialsListDoor = new List<Material>();

    public MaterialsBuilder()
    {
        Material redMaterial = new Material(Shader.Find("Specular"));
        redMaterial.color = Color.red;

        Material blueMaterial = new Material(Shader.Find("Specular"));
        blueMaterial.color = Color.blue;

        Material greenMaterial = new Material(Shader.Find("Specular"));
        greenMaterial.color = Color.green;

        Material magentaMaterial = new Material(Shader.Find("Specular"));
        magentaMaterial.color = Color.magenta;

        Material yellowMaterial = new Material(Shader.Find("Specular"));
        yellowMaterial.color = Color.yellow;

        Material whiteMaterial = new Material(Shader.Find("Specular"));
        whiteMaterial.color = Color.white;

        Material greyMaterial = new Material(Shader.Find("Specular"));
        greyMaterial.color = Color.grey;

        Material blackMaterial = new Material(Shader.Find("Specular"));
        blackMaterial.color = Color.black;


        materialsListSkyscraper.Add(blackMaterial);
        materialsListSkyscraper.Add(blackMaterial);
        materialsListSkyscraper.Add(blackMaterial);
        materialsListSkyscraper.Add(blackMaterial);
        materialsListSkyscraper.Add(blackMaterial);
        materialsListSkyscraper.Add(blackMaterial);

        materialsListBase.Add(greyMaterial);

        materialsListDoor.Add(redMaterial);
        materialsListDoor.Add(redMaterial);
        materialsListDoor.Add(redMaterial);
        materialsListDoor.Add(redMaterial);
        materialsListDoor.Add(redMaterial);
        materialsListDoor.Add(redMaterial);
    }

    public List<Material> MaterialsListSkyscraper(){
        return materialsListSkyscraper;
    }

    public List<Material> MaterialsListBase(){
        return materialsListBase;
    }

    public List<Material> MaterialsListDoor(){
        return materialsListDoor;
    }
}
