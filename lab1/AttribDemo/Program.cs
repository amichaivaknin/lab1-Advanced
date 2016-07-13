using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    class Program
    {

        static bool AnalyzeAssembly(Assembly assembly)
        {
            bool allApproved = true;
            Type[] types = assembly.GetTypes();
            
            foreach(Type type in types)
            {
                object[] attributes = type.GetCustomAttributes(typeof(CodeReviewAttribute), false);
                if (attributes.Length==0)
                {
                    Console.WriteLine("No CodeReviewAttribute for "+ type.Name);
                    Console.WriteLine();
                    continue;
                }

                Console.WriteLine("CodeReviewAttribute for " + type.Name);
                foreach (CodeReviewAttribute attDetails in attributes)
                {
                    Console.WriteLine("Name:" + attDetails.ReviewerName +
                                      " Date:" + attDetails.reviewDate +
                                      " Approves:" + attDetails.CodeApproved);

                    if (attDetails.CodeApproved==false)
                    {
                        allApproved = false;
                    }
                }
                Console.WriteLine();
            }
            return allApproved;
        }

        static void Main(string[] args)
        {
            bool allApproved = AnalyzeAssembly(Assembly.GetExecutingAssembly());
            if (allApproved)
            {
                Console.WriteLine("All reviewed types are approved :-)");
                return;
            }
            Console.WriteLine("not all the reviewed types are approved :-(");

            bool allApprovedTry = AnalyzeAssembly(typeof(int).Assembly);
            if (allApprovedTry)
            {
                Console.WriteLine("All reviewed types are approved :-)");
                return;
            }
            Console.WriteLine("not all the reviewed types are approved :-(");
        }
    }

    [CodeReview("Amichai", "10/02/88",true)]
    class A
    {
        
    }

    [CodeReview("Haim", "10/12/96", true)]
    [CodeReview("David", "10/08/96", false)]
    class B
    {
        
    }

    [CodeReview("Haim", "10/12/96", true)]
    [CodeReview("David", "10/08/96", false)]
    [CodeReview("Moshe", "10/08/97", true)]
    class C
    {
        
    }

}
