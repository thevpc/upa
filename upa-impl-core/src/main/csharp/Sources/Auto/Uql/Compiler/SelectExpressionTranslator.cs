/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa.Impl.Uql.Compiler
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class SelectExpressionTranslator : Net.TheVpc.Upa.Impl.Uql.ExpressionTranslator {

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompileSelect((Net.TheVpc.Upa.Expressions.Select) o, manager, declarations);
        }

        protected internal virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect CompileSelect(Net.TheVpc.Upa.Expressions.Select v, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect s = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect();
            s.SetDistinct(v.IsDistinct());
            s.SetTop(v.GetTop());
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect nameOrSelect = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect) manager.TranslateAny(v.GetEntity(), declarations);
            string entityAlias = v.GetEntityAlias();
            System.Collections.Generic.HashSet<string> aliases = new System.Collections.Generic.HashSet<string>();
            if (entityAlias == null) {
                if (nameOrSelect is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) {
                    entityAlias = ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) nameOrSelect).GetName();
                } else {
                    entityAlias = "ALIAS";
                }
                int i = 0;
                while (true) {
                    string a2 = i == 0 ? entityAlias : (entityAlias + i);
                    if (!aliases.Contains(a2)) {
                        aliases.Add(a2);
                        entityAlias = a2;
                        break;
                    }
                    i++;
                }
            }
            s.From(nameOrSelect, entityAlias);
            for (int i = 0; i < v.CountJoins(); i++) {
                Net.TheVpc.Upa.Expressions.JoinCriteria c = v.GetJoin(i);
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect jnameOrSelect = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect) manager.TranslateAny(c.GetEntity(), declarations);
                entityAlias = c.GetEntityAlias();
                if (entityAlias == null) {
                    if (nameOrSelect is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) {
                        entityAlias = ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) nameOrSelect).GetName();
                    } else {
                        entityAlias = "ALIAS";
                    }
                    i = 0;
                    while (true) {
                        string a2 = i == 0 ? entityAlias : (entityAlias + i);
                        if (!aliases.Contains(a2)) {
                            aliases.Add(a2);
                            entityAlias = a2;
                            break;
                        }
                        i++;
                    }
                }
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria cc = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria(c.GetJoinType(), jnameOrSelect, entityAlias, manager.TranslateAny(c.GetCondition(), declarations));
                s.Join(cc);
            }
            for (int i = 0; i < v.CountFields(); i++) {
                Net.TheVpc.Upa.Expressions.QueryField field = v.GetField(i);
                s.Field(manager.TranslateAny(field.GetExpression(), declarations), field.GetAlias());
            }
            s.Where(manager.TranslateAny(v.GetWhere(), declarations));
            s.Having(manager.TranslateAny(v.GetHaving(), declarations));
            for (int i = 0; i < v.CountGroupByItems(); i++) {
                Net.TheVpc.Upa.Expressions.Expression c = v.GetGroupBy(i);
                s.GroupBy(manager.TranslateAny(c, declarations));
            }
            for (int i = 0; i < v.CountOrderByItems(); i++) {
                Net.TheVpc.Upa.Expressions.Expression c = v.GetOrderBy(i);
                s.OrderBy(manager.TranslateAny(c, declarations), v.IsOrderAscending(i));
            }
            return s;
        }
    }
}
