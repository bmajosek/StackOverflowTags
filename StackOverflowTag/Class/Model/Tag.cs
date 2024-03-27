using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflowTag.Class.Model
{
    public class Tag
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public float Percentage { get; set; }
    }
}