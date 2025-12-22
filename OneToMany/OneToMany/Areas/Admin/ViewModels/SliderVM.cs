using OneToMany.Models;

namespace OneToMany.Areas.Admin.ViewModels
{
    public class SliderVM
    {
            public IEnumerable<Slider> Sliders { get; set; }
            public SliderDetail SliderDetail { get; set; }
    }
}
