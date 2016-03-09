using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributesDemo
{
    /// <summary>
    /// Useful attributes
    /// http://stackoverflow.com/questions/144833/most-useful-attributes
    /// </summary>

    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class CodeReviewAttribute : Attribute
    {
        private string _reviewer;
        private string _date;
        private string _comment;

        public CodeReviewAttribute(string reviewer, string date)
        {
            _reviewer = reviewer;
            _date = date;
        }

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        public string Date
        {
            get { return _date; }
        }

        public string Reviewer
        {
            get { return _reviewer; }
        }
    }

    [CodeReview("Bartosz", "01-01-2016", Comment = "test code")]
    class complex
    {

    }
}
