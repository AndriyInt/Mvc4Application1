namespace Mvc4Application1.DAL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }

        [Required]
        [DataType(DataType.Date)] // only provide hints for the view engine to format the data
        public DateTime BirthDate { get; set; }

        [Range(0, 1000000000)]
        ////[DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Monthly expenses")]
        public decimal MonthlyExpenses { get; set; }
    }
}