using System.Linq.Expressions;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            var cells = line.Split(',');

            logger.LogInfo("Finished the line split");

            if (cells.Length < 3)
            {
                logger.LogError("The Array length was less than 3");
                return null;
            }
            // grab the latitude from your array at index 0
            logger.LogInfo("Assign cell[0]");
            double dblTacoLATPt1 = double.Parse(cells[0]);

            // grab the longitude from your array at index 1
            logger.LogInfo("Assign cell[1]");
            double dblTacoLONGPt2 = double.Parse(cells[1]);
            // grab the name from your array at index 2
            logger.LogInfo("Assign cell[2]");
            string strName = cells[2];
            //Rogue

            logger.LogInfo("Create TacoBellPt POINT ");

            
            Point tacoBellpoint = new Point
            {
                Latitude = dblTacoLATPt1,
                Longitude = dblTacoLONGPt2
            };

            //End Rogue

            // You'll need to create a TacoBell class
            // that conforms to ITrackable

            logger.LogInfo("Create Tacobell class instance, assign Name and POINT ");

            
            TacoBell tacoBellNamLoc = new TacoBell() { Name = strName, Location = tacoBellpoint };

            logger.LogInfo("Return tacoBellNamLoc");
            return tacoBellNamLoc;
        }
}   }