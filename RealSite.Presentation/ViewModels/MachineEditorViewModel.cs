
using RealSite.Domain.DataModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealSite.Presentation.ViewModels
{
    public class MachineEditorViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ModelInfo { get; set; }
        [Required]
        public string Price { get; set; }
        public List<ImageModel> Photos { get; set; }
        public int ManufactureModelId { get; set; }
        public List<ManufactureModel> Manufactures { get; set; }
    }
}
