﻿using System;
using System.Collections.Generic;
using System.Text;
using static МатКлассы.FuncMethods.DefInteg.GaussKronrod;
using NUnit.Framework;

namespace MathClassesTests
{
    public class GaussKrondorTests
    {
        [TestCase(0,1)]
        [TestCase(5, 16)]
        [TestCase(-1,-0.3)]
        public void IntegralofX2(double begin,double end)
        {
            Func<double, double> x3 = (double x) => x * x * x / 3;
            
            double result = MySimpleGaussKronrod((double x) => x * x, begin, end);

            Assert.AreEqual(x3(end) - x3(begin),result,  0.000001);
        }

        [TestCase(0, 100)]
        [TestCase(5, 306)]
        [TestCase(-Math.PI, Math.PI*200)]
        public void IntegralofSinOnLongCut(double begin, double end)
        { 
            double result = MySimpleGaussKronrod(Math.Sin, begin, end,ChooseStepByCompareRes:true,MaxDivCount:6);

            Assert.AreEqual( -Math.Cos(end) + Math.Cos(begin), result,0.000001);
        }


    }
}
