using System.ComponentModel.DataAnnotations;

namespace BackEndProject.ViewModels
{
    public class SliderCreateVM
    {

        [Required]
        public IFormFile? Photo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
