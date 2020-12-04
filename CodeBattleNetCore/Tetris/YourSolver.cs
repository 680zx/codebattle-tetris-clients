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

			
			foreach (var point in GetFreePointsAtZeroLayer(board))
				Console.WriteLine(point.ToString());
			
			
			var currentAvailablePoints = GetFreePointsAtZeroLayer(board);
			Command direction;
			
			if (board.GetCurrentFigureType() == Element.YELLOW)
            {
				int dx = board.GetCurrentFigurePoint().X - currentAvailablePoints[0].X;
				direction = dx < 0 ? Command.RIGHT : Command.LEFT;
				dx = Math.Abs(dx);

				return Command.DUMMY.Then(direction, dx).Then(Command.DOWN);
            }




			return Command.DUMMY;


			// Команды можно комбинировать
			
			
			//return Command.DOWN
				//.Then(Command.LEFT);
			
		} 

		

		private List<Point> GetFreePointsAtZeroLayer(Board board)
        {
			var availablePoints = board.GetFreeSpace();

			var selectedPoints = (from point in availablePoints
								where point.Y == 0
								select point).ToList();

			return selectedPoints;
        }


		//Переделать логику -> нужно, чтобы метод искал минимальный уровень, который можно 
		//достичь с текущей фигурой
		private int GetMinLayerByYcoord(Board board)
		{
			var availablePoints = board.GetFreeSpace();

			int minLayer = byte.MaxValue;

			for (int i = 0; i < availablePoints.Count; i++)
			{
				if (availablePoints[i].Y < minLayer)
					minLayer = availablePoints[i].Y;
			}

			return minLayer;
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
