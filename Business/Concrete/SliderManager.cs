using Business.Abstarct;
using DataAccess.Abstarct;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SliderManager : ISliderManager
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public void Add(Slider slider)
        {
           _sliderDal.Add(slider);
        }

        public List<Slider> GetAllSliders()
        {
            return _sliderDal.GetAll();
        }

        public void Remove(Slider slider, int id)
        {
            var current = _sliderDal.Get(x=>x.Id == id);
            _sliderDal.Delete(current);
        }

        public void Update(Slider slider, int id)
        {
            var current = _sliderDal.Get(x => x.Id == id);
            current.Title = slider.Title;
            current.Description = slider.Description;
            current.PhotoUrl = slider.PhotoUrl;
           _sliderDal.Update(current);
        }
    }
}
