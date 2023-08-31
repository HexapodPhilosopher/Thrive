﻿using System.Collections.Generic;
using Godot;

/// <summary>
///   Generic interface to allow working with microbe species and also multicellular species' individual cell types
/// </summary>
public interface ICellProperties
{
    public OrganelleLayout<OrganelleTemplate> Organelles { get; }
    public MembraneType MembraneType { get; set; }
    public float MembraneRigidity { get; set; }
    public Color Colour { get; set; }
    public bool IsBacteria { get; set; }
    public float BaseRotationSpeed { get; set; }

    /// <summary>
    ///   Returns true if this cell fills all the requirements needed to engulf.
    /// </summary>
    public bool CanEngulf { get; }

    public string FormattedName { get; }

    /// <summary>
    ///   Repositions the cell to the origin and recalculates any properties dependant on its position.
    /// </summary>
    public void RepositionToOrigin();

    public void UpdateNameIfValid(string newName);
}

public static class CellPropertiesHelpers
{
    // TODO: this can probably be deleted entirely as unused old code
    /// <summary>
    ///   The total compounds in the composition of all organelles
    /// </summary>
    public static Dictionary<Compound, float> CalculateTotalComposition(this ICellProperties properties)
    {
        var result = new Dictionary<Compound, float>();

        foreach (var organelle in properties.Organelles)
        {
            result.Merge(organelle.Definition.InitialComposition);
        }

        return result;
    }
}
