namespace Calculator.Domain
{
    using Calculator.Commons.Implementation;
    using Calculator.Commons.Interface;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Calculator")]
    public class CalculatorOperation : Entity, IEntity
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
        public string Result { get; set; }

    }
}
