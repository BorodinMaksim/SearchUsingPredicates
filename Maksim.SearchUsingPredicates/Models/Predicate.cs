namespace Maksim.SearchUsingPredicates.Models
{
    public class Predicate
    {
        public Predicate(bool isNotNegative, string value)
        {
            this.IsNotNegative = isNotNegative;
            this.Value = value;
        }

        public bool IsNotNegative { get; set; }

        public string Value { get; set; }
    }
}