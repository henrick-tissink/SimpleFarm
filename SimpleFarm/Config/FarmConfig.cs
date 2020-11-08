namespace SimpleFarm.Config
{
    public class FarmConfig
    {
        public int TillTimeInMinutes { get; set; }
        public int PlantTimeInMinutes { get; set; }
        public int HarvestTimeInMinutes { get; set; }
        public int FertileLandInMetersSquared { get; set; }
        public string Crop { get; set; }
    }
}
