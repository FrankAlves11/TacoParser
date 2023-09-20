using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args) 
        {    
            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");



            // Create a new instance of your TacoParser class
            TacoParser parser = new TacoParser();
            logger.LogInfo("Created TacoParser Class");

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            ITrackable[] locations = lines.Select(parser.Parse).ToArray();
            logger.LogInfo("Finished Parsing all of the CSV file with Tacobell location\n\n\n");
            Console.WriteLine("Press return to find stores furthest apart> ");
            Console.ReadLine();

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            double longestDistance = 0;
            double tmpMeters = 0;
            double tmpMiles = 0;
            string name1 = "";
            string name2 = "";

            for (int i = 0; i < locations.Length; i++)
            {
                GeoCoordinate geoCordA = new GeoCoordinate();
                geoCordA.Latitude = locations[i].Location.Latitude;
                geoCordA.Longitude = locations[i].Location.Longitude;



                for (int j = i + 1; j < locations.Length; j++)
                {
                    GeoCoordinate geoCordB = new GeoCoordinate();
                    geoCordB.Latitude = locations[j].Location.Latitude;
                    geoCordB.Longitude = locations[j].Location.Longitude;

                    tmpMeters = geoCordA.GetDistanceTo(geoCordB);
                    tmpMiles = tmpMeters * 0.000621371;


                    if (tmpMiles > longestDistance)
                    {
                        longestDistance = tmpMiles;
                        name1 = locations[i].Name;
                        name2 = locations[j].Name;
                    }


                    Console.WriteLine($"Longest Distance in Miles: {longestDistance}, {name1}, {name2}");
                    Console.WriteLine("Press Return To Continue> ");
                    Console.ReadLine();


                    // Create a new corA Coordinate with your locA's lat and long


                }
                    // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.

            }         
            
        }
    }
}
