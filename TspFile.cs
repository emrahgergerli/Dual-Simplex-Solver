using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm_Tsp
{
    enum EdgeWeightType //
    {
        EUC_2D,
        MAX_2D,
        MAN_2D,
        CEIL_2D

    }

    class City  //Sehrin sirasi, x koord , y koord degerleri 
    {
        public int index;
        public double x;
        public double y;
    }

    class TspFile : IComparable<TspFile> // dosyadan okuduklarimizi tutmak icin
    {

        public string name;
        public string comment;
        public string type;
        public EdgeWeightType edgeWeightType;
        public int dimension;
        public double distance;

        //icinde kacinci sirada,x,y tutulan bir sehirlistesi
        public List<City> cityList = new List<City>();

        //sehir ekleme fonksiyonu
        //dosyadan okunan sehirleri ekleyecek
        public void AddCity(int index, double x, double y)
        {
            City city = new City();
            city.index = index;
            city.x = x;
            city.y = y;
            cityList.Add(city);
        }

        //Oklid uzaklik 
        //karekok icinde (x1-x2) karesi + (y1-y2) karesi
        public double EuclidDistance() 
        {
            City city1;
            City city2;
            for (int i = 0; i < cityList.Count - 1; i++)
            {
                city1 = cityList[i];
                city2 = cityList[i + 1];
                distance += Math.Sqrt(Math.Pow(city1.x - city2.x, 2) + Math.Pow(city1.y - city2.y, 2));
            }
            //Son sehirden en bastakine olan uzaklik
            city1 = cityList[0];
            city2 = cityList[cityList.Count - 1];
            distance += Math.Sqrt(Math.Pow(city1.x - city2.x, 2) + Math.Pow(city1.y - city2.y, 2));
            return distance;
        }

        //Oklid ile ayni fakat en yakin int degere yuvarliyor.
        public double CeilDistance()
        {
            distance = Math.Ceiling(EuclidDistance());
            return distance;
        }


        //Manhattan Uzaklik
        // Karekok icinde |x1-x2|+|y1-y2|
        public double ManhattanDistance()
        {
            City city1;
            City city2;
            for (int i = 0; i < cityList.Count - 1; i++)
            {
                city1 = cityList[i];
                city2 = cityList[i + 1];
                distance += Math.Abs(city1.x - city2.x) + Math.Abs(city1.y - city2.y);
            }
            city1 = cityList[0];
            city2 = cityList[cityList.Count - 1];
            distance += Math.Sqrt(Math.Abs(city1.x - city2.x) + Math.Abs(city1.y - city2.y));
            return distance;
        }

        //Maksimum Uzaklik
        //xler farkini yler farkindan butuk olani aliyor.
        public double MaximumDistance()
        {
            City city1;
            City city2;
            for (int i = 0; i < cityList.Count - 1; i++)
            {
                city1 = cityList[i];
                city2 = cityList[i + 1];
                distance += Math.Max(Math.Abs(city1.x - city2.x), Math.Abs(city1.y - city2.y));
            }
            city1 = cityList[0];
            city2 = cityList[cityList.Count - 1];
            distance += Math.Max(Math.Abs(city1.x - city2.x), Math.Abs(city1.y - city2.y));
            return distance;
        }


        public int CompareTo(TspFile obj)
        {
            if (distance > obj.distance)
            {
                return -1;
            }
            else if (distance == obj.distance)
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }
    }
}
