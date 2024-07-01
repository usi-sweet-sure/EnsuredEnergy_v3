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
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

// Encapsulates all of the resource management used throughout the game
// A resource is any mesurable field that is actively used by the player to make decisions
// There are 3 groups of resources, which represent the 3 pillars of our simulation
// - Support: How aligned the population with the decisions the player is making
// - Energy: The core resource of the game, are the people getting enough energy to meet their demand
// - Environment: How are the energy management decisions impacting the environment
public partial class ResourceManager : Node {
	/*
	 * !!! This code is not being reworked yet. 
	 * Lines are just readded progressively to not throw errors in other files.
     * Do not expect anything below to work as intended.
	 */

	public (Energy, Environment, Support) _GetResources() => (new Energy(), new Environment(), new Support());
}
