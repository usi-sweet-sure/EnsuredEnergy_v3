/**
	Sustainable Energy Development game modeling the Swiss energy Grid.
	Copyright (C) 2023 Università della Svizzera Italiana

	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
using Godot;
using System;

// UI Script for the import controlling slider
public partial class ImportSlider : VSlider {
    public int _GetImportValue() => (int)Mathf.Max(0.0f, Mathf.Min(ImportAmount, MAX_ENERGY_IMPORT));
    /*
	 * !!! This code is not being reworked yet. 
	 * Lines are just readded progressively as needed in other files.
	 */
	public bool _GetGreenImports() => GreenImports;
	[Signal]
	/* Propagates a value update to the rest of the system */
	public delegate void ImportUpdateEventHandler();

	[Export]
	public float MAX_ENERGY_IMPORT =  100.0f;

	// Constants for target bar positions
	private const int TARGET_100_Y_POS = 21;
	private const int TARGET_0_Y_POS = 220;

	// Various labels that need to be dynamic
	private Label Amount; // Current selected import percentage
	private Label Text; // The text label describing the slider
	private Button ApplySelection; // Button that confirms the selected import amount
	private Button Cancel; // Button that cancels the modification of the import slider
	private TextureButton Up;
	private TextureButton Down;


	// Target import required to meet demand

	private float Max = 0;

	// The confirmed import amount
	private int ImportAmount;

	// The clean import toggle switch
	private Button ImportSwitch;
	private bool GreenImports;
	
	private UI _UI;

	// ==================== GODOT Method Overrides ====================

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {}
}

