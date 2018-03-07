using System;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.ViewModels
{
    public class RegisterDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? RegisterDate { get; set; }

        public int ConsumerCount { get; set; }
    }
}