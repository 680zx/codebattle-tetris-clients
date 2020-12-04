/*-
 * #%L
 * Codenjoy - it's a dojo-like platform from developers to developers.
 * %%
 * Copyright (C) 2018 Codenjoy
 * %%
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as
 * published by the Free Software Foundation, either version 3 of the
 * License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public
 * License along with this program.  If not, see
 * <http://www.gnu.org/licenses/gpl-3.0.html>.
 * #L%
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace TetrisClient
{
	/// <summary>
	/// В этом классе находится логика Вашего бота
	/// </summary>
	internal class YourSolver : AbstractSolver
	{
		public YourSolver(string server)
			: base(server)
		{
		}

		/// <summary>
		/// Этот метод вызывается каждый игровой тик
		/// </summary>
		/// 
		/*
		 	BLUE =   (short)'I',
			CYAN =   (short)'J',
			ORANGE = (short)'L',
			YELLOW = (short)'O',
			GREEN =  (short)'S',
			PURPLE = (short)'T',
			RED =    (short)'Z',
			NONE =   (short)'.',
		 */
		protected internal override Command Get(Board board)
		{
			// Код писать сюда!
		
			var availableCells = board.GetFreeSpace();

			foreach (var point in GetPointsAtMinLayer(board, GetMinLayerByYcoord(board)))
				Console.WriteLine(point.ToString());

			return Command.DUMMY;


			// Команды можно комбинировать
			
			
			//return Command.DOWN
				//.Then(Command.LEFT);
			
		} 

		private int GetMinLayerByYcoord(Board board)
        {
			var availableCells = board.GetFreeSpace();

			int minLayer = byte.MaxValue;

			for (int i = 0; i < availableCells.Count; i++)
            {
				if (availableCells[i].Y < minLayer)
					minLayer = availableCells[i].Y;
            }

			return minLayer;
        }

		private List<Point> GetPointsAtMinLayer(Board board, int LayerYCoord)
        {
			var availableCells = board.GetFreeSpace();

			List<Point> selectedCells = new List<Point>();

			selectedCells = (from point in availableCells
							where point.Y == LayerYCoord
							select point).ToList();

			return selectedCells;
        }



		#region Эти методы не работают

		private List<Point> GetAvailbaleCellsByXcoordCurrentYLayer(Board board, int minLayerYCoord)
        {
			List<Point> XPoints = new List<Point>();

			for (int i = 0; i < 18; i++)
            {
				
            }

			return XPoints;
        }



		private List<Point> minPointsByYcoord(Board board)
        {
			var points = board.GetFreeSpace();

			List<Point> minPoints = new List<Point>();

			Array.Sort(points.ToArray());

			foreach (var point in points)
				Console.WriteLine(point.ToString());

			return minPoints;

        }

        #endregion
    }
}
