﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DynamicXml
{
    class Program
    {
        static void Main(string[] args)
        {
            //Application crashes - do not use an absolute path..
            dynamic planets = DynamicXElement.Create(XElement.Load(@"C:\Users\Ami\Documents\Visual Studio 2015\Projects\codeValue\Advanced\lab1\DynamicXml\planets.xml"));
            var mercury = planets.Planet; // first planet
            Console.WriteLine(mercury);
            var venus = planets["Planet", 1]; // second planet
            Console.WriteLine(venus);
            var ourMoon = planets["Planet", 2].Moons.Moon;
            Console.WriteLine(ourMoon);
            var marsMoon = planets["Planet", 3]["Moons", 0].Moon; // mars second moon
            Console.WriteLine(marsMoon);
        }
    }
}
