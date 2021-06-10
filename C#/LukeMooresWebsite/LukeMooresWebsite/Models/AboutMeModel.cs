using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LukeMooresWebsite.Entities;

namespace LukeMooresWebsite.Models
{
    public class AboutModel
    {
        private readonly DateTime _startDate = Settings.StartDate();
        private int _Years;
        private int _Months;

        public AboutModel()
        {
            var today = DateTime.Now;

            System.TimeSpan diff = today.Subtract(_startDate);

            var experience = new decimal(diff.Days / Settings.DaysPerYear());

            var roundedDownExperience = Math.Floor(experience);

            _Years = Convert.ToInt32(roundedDownExperience);
            _Months = Convert.ToInt32((experience - roundedDownExperience) * Settings.MonthsPerYear());

            if (_Months == Settings.MonthsPerYear())
            {
                _Years += 1;
                _Months = 0;
            }

        }

        public string Experience
        {
            get
            {
                return $"{_Years} year's {_Months} month's";
            }
        }
    }
}
