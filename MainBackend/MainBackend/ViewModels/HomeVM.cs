using MainBackend.Models;

namespace MainBackend.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public SliderDetail SliderDetails { get; set; }
    }
}
