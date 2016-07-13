using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    [AttributeUsage(AttributeTargets.Class| 
                    AttributeTargets.Struct, 
                    AllowMultiple = true)]

    class CodeReviewAttribute : System.Attribute
    {
        public string ReviewerName { get; }

        public string reviewDate { get; }

        public bool CodeApproved { get; }


        public CodeReviewAttribute(string reviewerName,
            string reviewDate, bool codeApproved)
        {
            ReviewerName = reviewerName;
            this.reviewDate = reviewDate;
            CodeApproved = codeApproved;
        }
    }
}
