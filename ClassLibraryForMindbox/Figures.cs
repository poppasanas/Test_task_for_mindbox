using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForMindbox
{
    public class Figures
    {
		public int AmountOfPointsInFigure()
		{
			Console.WriteLine("Введите кол-во известных вам длин в фигуре: ");
			int amount = Convert.ToInt32(Console.ReadLine());
			return amount;
		}
		public double[] ReadLengthsFromKbd()
		{
			Console.WriteLine("Введите известные вам длины фигуры");
			Console.WriteLine("Если у вас больше 4 сторон - введите одну для правильной фигуры:");
			double[] lengths = Console.ReadLine().Split(' ').Select(text => double.Parse(text)).ToArray();
			return lengths;
		}
		public double AreaOfCircle(double[] lengths)
		{
			double CircleArea = Math.PI * lengths[0] * lengths[0];
			return CircleArea;
		}
		public double AreaOfRectangle(double[] lengths)
		{
			double RectangleArea = lengths[0] * lengths[1];
			return RectangleArea;
		}
		public double AreaOfTriangle(double[] lengths)
		{
			double HP = (lengths[0] + lengths[1] + lengths[2]) / 2; //Полупериметр
			double TriangleArea = Math.Sqrt(HP * (HP - lengths[0]) * (HP - lengths[1]) * (HP - lengths[2]));
			return TriangleArea;
		}
		public double AreaOfOtherCorrectFigures(double[] lengths, int amount)
		{
			double Area = (amount / 4) * lengths[0] * lengths[0] * (1 / Math.Tan(Math.PI / amount));
			return Area;
		}
		public void ReturnArea(double area)
		{
			Console.WriteLine("Площадь вашей фигуры равна: " + area);
			return;
		}
		public void AllFigure()
		{
			double area;
			int amount = AmountOfPointsInFigure();
			double[] AllLengths = ReadLengthsFromKbd();
			switch (amount)
			{
				case 1:
					area = AreaOfCircle(AllLengths);
					ReturnArea(area);
					break;
				case 2:
					area = AreaOfRectangle(AllLengths);
					ReturnArea(area);
					break;
				case 3:
					area = AreaOfTriangle(AllLengths);
					ReturnArea(area);
					break;
				case -1:
					break;
				default:
					area = AreaOfOtherCorrectFigures(AllLengths, amount);
					ReturnArea(area);
					goto case -1;
			}
			System.Threading.Thread.Sleep(2000);
		}
	}
}
