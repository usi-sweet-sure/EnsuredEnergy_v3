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

// General controller for the UI
public partial class UI : CanvasLayer {
	private ImportSlider Imports;
	/*
	 * !!! This code is not being reworked yet. 
	 * Lines are just readded progressively as needed in other files.
	 */
	public enum InfoType { W_ENGERGY, S_ENGERGY, SUPPORT, ENVIRONMENT, POLLUTION, MONEY };

	public bool _GetGreenImportState() => Imports._GetGreenImports();


	public float _GetImportSliderPercentage() => (float)Imports._GetImportValue();

	public void _UpdateData(InfoType t, params int[] d) {}

}
