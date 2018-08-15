package net.vpc.upa;

import net.vpc.upa.persistence.ContextOperation;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.PersistenceStore;
import net.vpc.upa.persistence.UConnection;

/**
 * Interface to be used as a single param in methods annotated with
 *
 * @NamedFormula annotations to implement a custom Formula invoked in Java/C#
 * instead of UPQL. Such named formula method is a method
 * <ul>
 * <li>defined in a callable class (class with @{@link Callback}
 * annotation)</li>
 * <li>which has a single {@link CustomFormulaContext} parameter.</li>
 * <li>retrieving contextual values (of the updated document) using
 * {@link CustomFormulaContext#getUpdateDocument()}  </li>
 * <li>returning as a result the formula value</li>
 * </ul>
 * such method is responsible of implementing in Java/C# formula logic instead
 * of UPQL. This method is finally referenced in @Formula annotation over the
 * formula field using it's "name" attribute. In the following example formulas
 * in fields formula1 and formula2 are equivalent : that simply concatenates
 * str1 and str2. str1 is implementing simple UPQL formula. str2 is implementing
 * custom named formula.
 * <p>
 * ddd</p>
 * <blockquote><pre>
 * &#64;Entity
 * public class Example{
 *     private int id;
 *     private String str1;
 *     private String str2;
 *
 *     &#64;Formula(value="concat(this.str1,this.str2)")
 *     private String formula1;
 *
 *     &#64;Formula(name="myconcat")
 *     private String formula2;
 * }
 *
 * &#64;Callback
 * public class ExampleSupport{
 *    &#64;NamedFormula
 *    public String myconcat({@link net.vpc.upa.CustomFormulaContext} ctx){
 *      String str1=ctx.getUpdateDocument().getString("str1")
 *      String str2=ctx.getUpdateDocument().getString("str2")
 *      return str1+str2;
 *    }
 * }
 * </pre></blockquote>
 * public Double alpha14AD(CustomFormulaContext ctx){
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public interface CustomFormulaContext extends BaseFormulaContext {

    Field getField();

    Object getObjectId();

    Document reloadUpdateDocument();

    Object reloadUpdateObject();
}
