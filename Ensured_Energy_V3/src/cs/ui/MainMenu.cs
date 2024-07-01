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

// Models the behavior of the main menu screen shown above the game at the start
public partial class MainMenu : CanvasLayer {

	// IDs for accessing XML text fields
	private const string MENU_FILE = "labels.xml";
	private const string MENU_GROUP = "menu";
	private const string TITLE_ID = "title";
	private const string PLAY_ID = "label_play";
	private const string LANG_ID = "label_lang";
	private const string MODE_ID = "label_mode";
	private const string OFFLINE_ID = "mode_offline";
	private const string ONLINE_ID = "mode_online";
	
	// Buttons on the main menu
	private TextureButton Play;
	private TextureButton Lang;
	private TextureButton Mode;

	// Labels used to disaply the text
	private Label Title;
	private Label PlayL;
	private Label LangL;
	private Label OfflineL;
	private Label Drag;
	private Label Scroll;

	// Text Controller for dynamic localization
	private TextController TC;

	// Context, used to update the language
	private Context C;

	// Game loop to start the game
	private GameLoop GL;

	// ==================== GODOT Method Overrides ====================
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
        Lang = GetNode<TextureButton>("Lang");
        Lang.Connect("pressed", this, nameof(_OnLangPressed));
		// Initialize the various labels
	}

    // ==================== Public API ====================
    // Resets the main menu to its initial state
    public void _Reset() {

	}
	
	// ==================== Interaction Callbacks ====================
	// Updates the language
	private void _OnLangPressed() {
        GD.Print( System.IO.Path.Combine("text/", "en" + "/" ));
		// Update the language 
		//!!! C._NextLanguage();

		// Update the labels
		//!!!! SetLabels();
	}

}
