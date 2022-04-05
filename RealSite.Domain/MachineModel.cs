using System.Collections.Generic;

namespace RealSite.Domain
{
    public class MachineModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufactureModelId { get; set; }
        public ManufactureModel ManufactureModel { get; set; }
        public string ModelInfo { get; set; }
        public string Price { get; set; }
        public List<ImageModel> Photos { get; set; }
    }
}
