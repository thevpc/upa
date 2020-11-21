using System;
using System.Collections.Generic;
using System.Linq;
namespace Net.TheVpc.Upa.Types{
//SPECIFIC

/**
 * User: taha
 * Date: 5 sept. 2003
 * Time: 12:57:26
 */
    public partial class EnumType {
        public override IList<Object> GetValues() {
            return Enum.GetValues(typeof(EnumType)).Cast<Object>().ToList();
        }
    }
}
