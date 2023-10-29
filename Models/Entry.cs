using System;
using System.ComponentModel.DataAnnotations;

namespace My_Scripture_Journal.Models
{
    public class Entry
    {
        public int ID { get; set; }
        public string Reference { get; set; }
        public string Book { get; set; }
        [Display(Name = "Impression Note")]
        public string ImpressionNote { get; set; }

        [Display(Name = "Date of Entry")]
        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }
    }
}
