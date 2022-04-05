using System.Collections.Generic;

namespace RealSite.Domain
{
    public class ManufactureModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<MachineModel> Models { get; set; }
    }
}
