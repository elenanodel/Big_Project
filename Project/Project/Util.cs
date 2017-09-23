using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.IO;

namespace Util
{
    public class FileWork
    {
        private const string fileName = "file.txt";
        public void WriteAllToFile(List<Transport> list)
        {
            StreamWriter sw = new StreamWriter(fileName, true);
            foreach (Transport t in list)
            {
                sw.WriteLine(t.infoToWrite());
            }
            sw.Close();
        }

        public List<Transport> readAllFromFile()
        {
            List<Transport> result = new List<Transport>();

            string[] fromFile = File.ReadAllLines(fileName);

            foreach (string s in fromFile)
            {
                string[] items = s.Split('\t');

                switch (items[1])
                {
                case "Car":
                    {
                        result.Add(getCarObject(items));
                        break;
                    }

                case "AirPlane":
                    {
                        result.Add(getPlaneObject(items));
                        break;
                    }

                case "Ship":
                    {
                        result.Add(getShipObject(items));
                        break;
                    }
                case "Train":
                    {
                        result.Add(getTrainObject(items));
                        break;
                    }
                case "Bike":
                    {
                        result.Add(getBikeObject(items));
                        break;
                    }
                }
            }

            return result;
        }

        private Car getCarObject(string[] items)
        {
            Car car = new Car();

            car.Manufactor = items[2];
            car.Speed = int.Parse(items[3]);
            car.Width = double.Parse(items[4]);
            car.Height = double.Parse(items[5]);
            car.Engine = getEngine(items);
            car.Amount = int.Parse(items[10]);
            car.Transmisson = items[11];
            car.Body = items[12];

            Console.WriteLine(car.getInformation());

            return car;
        }

        private AirPlane getPlaneObject(string[] items)
        {
            AirPlane plane = new AirPlane();

            plane.Manufactor = items[2];
            plane.Speed = int.Parse(items[3]);
            plane.Width = double.Parse(items[4]);
            plane.Height = double.Parse(items[5]);
            plane.Engine = getEngine(items);
            plane.Amount = int.Parse(items[10]);
            plane.WingSpan = double.Parse(items[11]);
            plane.TakeOffWeight = double.Parse(items[12]);

            Console.WriteLine(plane.getInformation());

            return plane;
        }

        private Ship getShipObject (string[] items)
        {
            Ship ship = new Ship();

            ship.Manufactor = items[2];
            ship.Speed = int.Parse(items[3]);
            ship.Width = double.Parse(items[4]);
            ship.Height = double.Parse(items[5]);
            ship.Engine = getEngine(items);
            ship.Amount = int.Parse(items[10]);
            ship.Displacement = double.Parse(items[11]);
            ship.NavigationArea = items[12];

            Console.WriteLine(ship.getInformation());

            return ship;
        }

        private Train getTrainObject(string[] items)
        {
            Train train = new Train();

            train.Manufactor = items[2];
            train.Speed = int.Parse(items[3]);
            train.Width = double.Parse(items[4]);
            train.Height = double.Parse(items[5]);
            train.Engine = getEngine(items);
            train.Amount = int.Parse(items[10]);
            train.RollingStock = items[11];
            train.Regular = items[12];

            Console.WriteLine(train.getInformation());

            return train;
        }

        private Bike getBikeObject(string[] items)
        {
            Bike bike = new Bike();

            bike.Manufactor = items[2];
            bike.Speed = int.Parse(items[3]);
            bike.Width = double.Parse(items[4]);
            bike.Height = double.Parse(items[5]);
            bike.Engine = getEngine(items);
            bike.Amount = int.Parse(items[10]);
            bike.Model = items[11];
            bike.Brakes = items[12];

            Console.WriteLine(bike.getInformation());

            return bike;
        }

        private Engine getEngine(string[] items)
        {
            Engine engine = null;

            switch (items[6])
            {
                case "PetrolEngine":
                    {
                        engine = getPetrolEngine(items);
                        break;
                    }

                case "ReactiveEngine":
                    {
                        engine = getReactiveEngine(items);
                        break;
                    }

                case "Disel":
                    {
                        engine = getDisel(items);
                        break;
                    }
            }

            return engine;
        }

        private PetrolEngine getPetrolEngine(string[] items)
        {
            PetrolEngine petrolEngine = new PetrolEngine();

            petrolEngine.Power = int.Parse(items[7]);
            petrolEngine.Manufactor = items[8];
            petrolEngine.BlendingProcess = items[9];

            return petrolEngine;
        }

        private ReactiveEngine getReactiveEngine(string[] items)
        {
            ReactiveEngine reactiveEngine = new ReactiveEngine();

            reactiveEngine.Power = int.Parse(items[7]);
            reactiveEngine.Manufactor = items[8];
            reactiveEngine.Classes = items[9];

            return reactiveEngine;
        }

        private Disel getDisel (string[] items)
        {
            Disel diselEngine = new Disel();

            diselEngine.Power = int.Parse(items[7]);
            diselEngine.Manufactor = items[8];
            diselEngine.Construction = items[9];

            return diselEngine;
        }
    }
}