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
	private Sprite2D LEDOn;

	// Target import required to meet demand
	private Sprite2D Target;
	private float Max = 0;

	// The confirmed import amount
	private int ImportAmount;

	// The clean import toggle switch
	private Button ImportSwitch;
	private bool GreenImports;
	
	private UI _UI;

	// ==================== GODOT Method Overrides ====================

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {

		//  Fetch nodes
		Amount = GetNode<Label>("Amount");
		Text = GetNode<Label>("Text");
		Target = GetNode<Sprite2D>("Target");
		ApplySelection = GetNode<Button>("Apply");
		Cancel = GetNode<Button>("Cancel");
		ImportSwitch = GetNode<Button>("ImportSwitch");
		Up = GetNode<TextureButton>("UpButton");
		Down = GetNode<TextureButton>("DownButton");
		LEDOn = GetNode<Sprite2D>("LEDOn");

		// Initialize the import amount
		ImportAmount = 0;
		GreenImports = false;
		
		_UI = GetNode<UI>("/root/Main/UI");

		// Connect the various callbacks
		ValueChanged += OnSliderRangeValueChanged;
		DragEnded += _OnApplySelectionPressed;
		//Keeping it just in case for now
		//ApplySelection.Pressed += OnApplySelectionPressed;
		Cancel.Pressed += OnCancelPressed;
		ImportSwitch.Toggled += OnImportSwitchToggled;
		Up.Pressed += OnUpPressed;
		Down.Pressed += OnDownPressed;
	}

	// ==================== Public API ====================

	// Sets the value of the target based on a given demand percentage
	// The given demand should represent the percentage of the total
	// demand that would need to be imported to cover the lack of supply
	public void _UpdateTargetImport(float diff) {
		Max = diff;
		// Clamp diff to be in range [0, max]
		float _d = Math.Max(0.0f, Math.Min(diff, MAX_ENERGY_IMPORT));

		// Set the bar position based on the given percentage
		int y_pos = TARGET_0_Y_POS + (int)(_d/MAX_ENERGY_IMPORT * (TARGET_100_Y_POS - TARGET_0_Y_POS));
		Target.Position = new Vector2(
			Target.Position.X, 
			y_pos
		);
		_OnApplySelectionPressed(true);
	}

	// Udpates the text to match the given string
	// This should only be used in the UI object for localization pourposes
	public void _UpdateLabel(string new_label) {
		Text.Text = new_label;
	}

	// Getter for the current value selected with the slider
	public int _GetImportValue() => (int)Math.Max(0.0f, Math.Min(ImportAmount, MAX_ENERGY_IMPORT));

	// Getter for the state of green imports
	public bool _GetGreenImports() => GreenImports;

	// ==================== Signal Callbacks ====================

	// Updates the amount label to match the selected value of the import slider
	// The value given is the new value of the slider
	private void OnSliderRangeValueChanged(double value) {
		// Update the amount label to reflect the selected amount
		Amount.Text = value.ToString() + " %";

		// Show the two selection related buttons
		//ApplySelection.Show();
		//Cancel.Show();
	}

	// Confirms the selection of a specific import amount
	public void _OnApplySelectionPressed(bool ValChanged) {
		// Save the import amount
		if(Max <= 0) {
			ImportAmount = 0;
		} else {
			ImportAmount = Math.Max(0, Math.Min((int) Value, (int)Max + 1));
			}
		
		Value = ImportAmount;

		// Hide the apply selection button
		//ApplySelection.Hide();
		//Cancel.Hide();

		// Propagate the value update to the rest of the system
		EmitSignal(SignalName.ImportUpdate);
	}

	// Cancels any modifications made to the import slider
	private void OnCancelPressed() {
		// Reset the value to the previously saved import amount
		Value = (double)ImportAmount;

		// Hide all buttons
		ApplySelection.Hide();
		Cancel.Hide();
	}
	
	// Toggles the clean import that cost more but doesn't pollute
	private void OnImportSwitchToggled(bool Toggled) {
		LEDOn.Visible = Toggled;
		GreenImports = ! GreenImports;
		EmitSignal(SignalName.ImportUpdate);
	}
	
	private void OnUpPressed() {
		Value += Step;
		_OnApplySelectionPressed(true);
	}
	
	private void OnDownPressed() {
		Value -= Step;
		_OnApplySelectionPressed(true);
	}
}

