using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyApp.Models;

namespace MyApp.ViewModel
{
    public class MovieForm
    {
        public IEnumerable<Genres> genres { get; set; }
        public Movies movies { get; set; }
    }
}