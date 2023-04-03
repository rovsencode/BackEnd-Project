using BackEndProject.Models;

namespace BackEndProject.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders;
        public List<BoardInfo> BoardsInfos;
        public List<Notice> Notices;
        public EduHomeInfo eduHomeInfo;
        public SliderComment sliderComment;
        public List<Courses> Courses { get; set; }
        public List<Event> Events { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
