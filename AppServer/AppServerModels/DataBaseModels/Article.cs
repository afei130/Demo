using System;
using System.Collections.Generic;

namespace AppServerModels.DataBaseModels
{
    public partial class Article
    {
        public int Id { get; set; }
        public int Uid { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Classify { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int IsDelete { get; set; }
    }
}
