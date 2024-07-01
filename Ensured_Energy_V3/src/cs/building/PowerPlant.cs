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

// Represents a Power Plant object in the game
public partial class PowerPlant : Node2D {
	/*
	 * !!! This code is not being reworked yet. 
	 * Lines are just readded progressively to not throw errors in other files.
   * Do not expect anything below to work as intended.
	 */

	private int EnergyCapacity = 100;

	[Export] 
	// The type of the power plant, this is for internal use, other fields have to be 
	// updated to match the type of the building
	private Building.Type _PlantType = Building.Type.GAS;
	public Building PlantType;

	// Getter for the powerplant's current capacity
	public int _GetCapacity() => EnergyCapacity;
}
