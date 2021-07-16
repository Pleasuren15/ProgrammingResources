using System;

namespace LearningCoding.Models.ViewModels
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int NumberOfPages => (int)Math.Ceiling((double)TotalItems / ItemsPerPage);
    }
}
