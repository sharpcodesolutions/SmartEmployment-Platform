using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace testTait
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Car> cars = new List<Car>();
			for (int i = 0; i < 20; i++)
			{
				Random engineRnd = new Random();
				int engine = engineRnd.Next(-1, 4);
				Random brandRnd = new Random();
				int brand = brandRnd.Next(0, 2);
				Random colorRnd = new Random();
				int color = colorRnd.Next(0, 2);
				Car car = new Car();
				car.Brand = (Brand)brand;
				car.Engine = (Engine)engine;
				car.Color = (Color)color; 
				if (car.Brand == Brand.Tesla)
				{
					car.Engine = Engine.Electric;
				}
				if (car.Brand == Brand.Nissan)
				{
					car.Color = Color.Red; 
				}
				car.Expiry = GetRandomDate(); 

				cars.Add(car); 
			}
			int count = 0; 
			foreach(var car in cars)
			{
				if(car.Engine==Engine.Hybrid)
				{
					count++;
				}
			}
			Console.WriteLine("The percentage of Hybrid cars is: " + 100 * count / 20);

			// To check the expiry date
			foreach(var car in cars)
			{
				if(car.Expiry < DateTime.Now)
				{
					Console.WriteLine("The car " + car.Brand + " has expired license"); 
				}
			}
		}
		static readonly Random rnd = new Random();
		public static DateTime GetRandomDate()
		{
			DateTime from = DateTime.Now.AddYears(-1);
			DateTime to = DateTime.Now.AddYears(1); 
			var range = to - from;

			var randTimeSpan = new TimeSpan((long)(rnd.NextDouble() * range.Ticks));

			return from + randTimeSpan;
		}
	}
	public enum Engine { Petrol, Diesel, Electric, Hybrid }
	public enum Brand { Nissan, Tesla, VW}
	public enum Color { Red, Yellow, Blue }
	class Car
	{
		private DateTime _expiry; 
		public Engine Engine  { get; set; }
		public Brand Brand { get; set; }
		public Color Color { get; set; }
		public DateTime Expiry
		{
			get
			{
				return _expiry;
			}
			set
			{
				if (value > DateTime.Now.AddYears(-1) && value < DateTime.Now.AddYears(1))
				{
					_expiry = value;
				}
				else
				{
					throw new Exception(); 
				}
			}
		}
	}
	
}
