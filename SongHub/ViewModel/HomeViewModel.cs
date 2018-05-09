using SongHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SongHub.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Gig> UpcommingGigs { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
    }
}