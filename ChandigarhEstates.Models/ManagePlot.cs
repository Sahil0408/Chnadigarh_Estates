﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChandigarhEstates.Model
{
    public class ManagePlot
    {
        [Key]
        public int Id { get; set; }
        public string PlotNo { get; set; }
        public string Block { get; set; }
        public string PlotSize { get; set; }
        public string Unit { get; set; }
        public string Price { get; set; }
        public string TokenAmount { get; set; }
    }
}
