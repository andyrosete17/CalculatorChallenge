namespace Calculator.Domain
{
    using System.ComponentModel.DataAnnotations;
    public class CalculatorOperation
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10)]
        public string FirstOperand { get; set; }

        [StringLength(10)]
        public string SecondOperand { get; set; }

        [StringLength(5)]
        public string Operation { get; set; }

        [StringLength(20)]
        public string Result { get; private set; }

    }
}
