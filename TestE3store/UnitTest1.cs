using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace TestE3store
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestValidName()
        {
            var funciones = new Funciones();

            #region init 

            Dictionary<string, bool> namesValue = new Dictionary<string, bool>();
            
            namesValue.Add("E. Poe", false);
            namesValue.Add("E. A. Poe", false);
            namesValue.Add("Edgard A. Poe", false);
            namesValue.Add("Edgard", false);
            namesValue.Add("e. Poe", false);
            namesValue.Add("E Poe", false);
            namesValue.Add("E. Allan Poe", false);
            namesValue.Add("E. Allan P.", false);
            namesValue.Add("Edg. Allan Poe", false);

            #endregion init 

            #region validate 
            Dictionary<string, bool> results = new Dictionary<string, bool>();

            foreach (var x in namesValue)
            {
                var valid = funciones.validName(x.Key);
                results.Add(x.Key, valid);
            }

            #endregion validate 

            #region results
            
            Dictionary<string, bool> valids = new Dictionary<string, bool>();

            valids.Add("E. Poe", true);
            valids.Add("E. A. Poe", true);
            valids.Add("Edgard A. Poe", true);
            valids.Add("Edgard", false);
            valids.Add("e. Poe", false);
            valids.Add("E Poe", false);
            valids.Add("E. Allan Poe", false);
            valids.Add("E. Allan P.", false);
            valids.Add("Edg. Allan Poe", false);

            #endregion results

            Assert.IsTrue(!results.Except(valids).Any());
        }

        [TestMethod]
        public void TestValidFraccion()
        {
            var funciones = new Funciones();

            var f1 = "4/6";
            var f2 = "10/11";
            var f3 = "100/400";

            var result1 = funciones.simplificar(f1);
            var result2 = funciones.simplificar(f2);
            var result3 = funciones.simplificar(f3);

            Assert.IsTrue(result1 == "2/3" && result2 == "10/11" && result3 == "1/4");
        }
    }
}
