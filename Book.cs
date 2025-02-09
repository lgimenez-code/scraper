﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scraper
{
    internal class Book
    {
        public string? Title { get; set; }
        public double? Price { get; set; }
        public string TitleAndPrice
        {
            get
            {
                return $"> Title: {Title} - [Price: {Price?.ToString("F2")}]";
            }
        }
    }
}
