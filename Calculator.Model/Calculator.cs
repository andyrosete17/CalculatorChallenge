namespace Calculator.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Calculator
    {
        [Key]
        public int Id { get; set; }

        public string FirstOperand { get; set; }

        public string SecondOperand { get; set; }

        public string Operation { get; set; }

        public string Result { get; private set; }

    }
}
