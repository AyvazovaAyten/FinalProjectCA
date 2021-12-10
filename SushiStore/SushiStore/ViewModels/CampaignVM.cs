using SushiStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.ViewModels
{
    public class CampaignVM
    {
        public IntroSlider Campaign { get; set; }
        public List<IntroSlider> OtherCampaigns { get; set; }
    }
}
