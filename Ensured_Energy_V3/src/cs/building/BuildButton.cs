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
using System.Diagnostics;
using System.Collections.Generic;
using System.Net.Http.Headers;

// Models a button that can be used to create power plants
public partial class BuildButton : TextureButton {
	/*
	 * !!! This code is not being reworked yet. 
	 * Lines are just readded progressively as needed in other files.
	 */
	public delegate void BuildDoneEventHandler();
	public Label AnimMoney;
	public AnimationPlayer AP;
	public void _NextTurn() {

	}

	public void _Reset() {
	}

}
