using CarFactoryLibrary;

namespace LabDay1
{
	public class UnitTest1
	{
		//1
		[Fact]
		public void carIsMoving()
		{
			BMW car = new BMW();

			car.IncreaseVelocity(1);

			Assert.False(car.IsStopped());
		}


		//2
		[Fact]
		public void StopCar()
		{
			BMW car = new BMW();
			car.IncreaseVelocity(5);

			car.Stop();

			Assert.Equal(0, car.velocity);
		}
		//3
		[Theory]
		[InlineData(10)]
		public void checkVelocityTesting(int Num)
		{
			Toyota car = new Toyota();
		

			double initialVelocityBefore = car.velocity;
			car.IncreaseVelocity(Num);
			double initialVelocityAfter = car.velocity;

			Assert.InRange(initialVelocityAfter, initialVelocityBefore + 10,car.velocity );
		}


		#region string
		//1
		[Fact]
		public void setDrivingModeToStop()
		{
			BMW car = new BMW();
			car.IncreaseVelocity(10.0);

			car.Stop();

			Assert.Equal(DrivingMode.Stopped.ToString(), car.GetDirection());
		}
		//2
		public void CheckDrivingModeIsStoped()
		{
			BMW car = new BMW();

			Assert.Equal(DrivingMode.Stopped.ToString(), car.GetDirection());
		}
		//3
		[Fact]
		public void setDrivingModeToForward()
		{
			BMW car = new BMW();

			car.IncreaseVelocity(20);

			Assert.Equal(DrivingMode.Forward.ToString(), car.GetDirection());
		}
		//4
		[Fact]
		public void checkForwardDirection()
		{
			Honda car = new Honda();
			car.IncreaseVelocity(5);

			string direction = car.GetDirection();

			Assert.Contains(direction, "Forward");
		}
		//5
		[Fact]
		public void IncreeseTest()
		{
			Honda car = new Honda();
			car.IncreaseVelocity(5);

			string direction = car.GetDirection();

			Assert.NotEqual(direction, "Stopped");
		}
		#endregion

		#region Ref
		//1
		[Fact]
		public void GetMyCar()
		{
			Toyota car = new Toyota();

			Assert.Same(car, car.GetMyCar());
		}

		//2
		public void TwoCars_SameInstancesSameState_NotSame()
		{
			BMW car1 = new BMW(CarTypes.BMW, DrivingMode.Forward);

			BMW car2 = new BMW(CarTypes.BMW,  DrivingMode.Forward);

			Assert.NotSame(car1, car2);
		}
		#endregion

		#region Type 
		[Fact]
		public void currentCarType()
		{
			Honda car = new Honda();

			Assert.IsType<Honda>(car.GetMyCar());
		}
		//2
		public void GetMyCar_InstanceFrom()
		{
			Honda car = new Honda();

			var actualCar = car.GetMyCar();

			Assert.IsAssignableFrom<Car>(actualCar);
		}
		#endregion
		#region Exception  
		[Fact]
		public void TimeToCoverDistance_ThrowsDivideByZeroException()
		{
			Honda car = new Honda();

			Assert.Throws<DivideByZeroException>(() => car.TimeToCoverDistance(5));
		}
		#endregion


		#region Collection Assert
		[Fact]
		public void GetAllStoreCars_AddCar_Contains()
		{
			
			var carStore = new CarStore();

			
			Assert.Empty(carStore.getAll());
		}
		#endregion
	}
}