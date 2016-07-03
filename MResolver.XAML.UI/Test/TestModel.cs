using MResolver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.UI.Test
{
    public static class TestModel
    {
        public static Model TEST_MODEL()
        {
            var model = new Model();
            model.Name = "Test model";

            var set_1 = model.Set("SET1").OverIntegers;
            var set_2 = model.Set("SET2").OverIntegers;
            var set_3 = model.Set("SET3").OverStrings;
            var set_4 = model.Set("SET4").OverTime;
            
            set_3.Add("PIPPO");
            set_3.Add("PLUTO");
            set_3.Add("PAPERINO");

            set_4.Add(new DateTime(2015, 5, 4));

            var VAR_VXX = model.DecimalVariable("VAR_VXX").Over(set_4);
            
            var set_big = model.Set("SET_P").Over(set_1, set_2, set_3);
            
            var VAR_X = model.DecimalVariable("VAR_X").Over(set_big);
                       

            var formula = model.Formula("Sample Formula");
            formula.Text = @"
for i in range(0,1000): 
    for j in range(0,1000):
        VAR_X[i,j,'CAZ'] = VAR_X[i,j-1,'CAZ'] + 50
";
            
            //for (int i = 0; i < 1000; i++)
            //    for (int j = 0; j < 1000; j++)
            //        foreach (var r in set_3)
            //        {
            //            var_xx[i, j, r] = 150;
            //        }
            
            //foreach (var t in set_big)
            //{
            //    var_xx[t] = 150;
            //}
            
            //foreach (var t in set_big)
            //{
            //    var i = t.Item1;
            //    var j = t.Item2;
            //    var r = t.Item3;

            //    var_xx[i, j, r] = 150;
            //}

            return model;

        }


    }
}
