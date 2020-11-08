using System.Threading.Tasks;

namespace SimpleFarm.Process
{
    public interface IFarmingProcess
    {
        Task TillTheLand();
        Task PlantTheCrop();
        Task HarvestTheCrop();
    }
}