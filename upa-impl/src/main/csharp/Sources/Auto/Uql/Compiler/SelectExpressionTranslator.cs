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



namespace Net.Vpc.Upa.Impl.Uql.Compiler
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class SelectExpressionTranslator : Net.Vpc.Upa.Impl.Uql.ExpressionTranslator {

        private readonly Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager outer;

        public SelectExpressionTranslator(Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager outer) {
            this.outer = outer;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager expressionTranslationManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompileSelect((Net.Vpc.Upa.Expressions.Select) o, declarations);
        }

        protected internal virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect CompileSelect(Net.Vpc.Upa.Expressions.Select v, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect s = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect();
            s.SetDistinct(v.IsDistinct());
            s.SetTop(v.GetTop());
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect nameOrSelect = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect) outer.CompileAny(v.GetEntity(), declarations);
            string entityAlias = v.GetEntityAlias();
            System.Collections.Generic.HashSet<string> aliases = new System.Collections.Generic.HashSet<string>();
            if (entityAlias == null) {
                if (nameOrSelect is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) {
                    entityAlias = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) nameOrSelect).GetName();
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
                Net.Vpc.Upa.Expressions.JoinCriteria c = v.GetJoin(i);
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect jnameOrSelect = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect) outer.CompileAny(c.GetEntity(), declarations);
                entityAlias = c.GetEntityAlias();
                if (entityAlias == null) {
                    if (nameOrSelect is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) {
                        entityAlias = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) nameOrSelect).GetName();
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
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria cc = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria(c.GetJoinType(), jnameOrSelect, entityAlias, outer.CompileAny(c.GetCondition(), declarations));
                s.Join(cc);
            }
            for (int i = 0; i < v.CountFields(); i++) {
                Net.Vpc.Upa.Expressions.QueryField field = v.GetField(i);
                s.Field(outer.CompileAny(field.GetExpression(), declarations), field.GetAlias());
            }
            s.Where(outer.CompileAny(v.GetWhere(), declarations));
            s.Having(outer.CompileAny(v.GetHaving(), declarations));
            for (int i = 0; i < v.CountGroupByItems(); i++) {
                Net.Vpc.Upa.Expressions.Expression c = v.GetGroupBy(i);
                s.GroupBy(outer.CompileAny(c, declarations));
            }
            for (int i = 0; i < v.CountOrderByItems(); i++) {
                Net.Vpc.Upa.Expressions.Expression c = v.GetOrderBy(i);
                s.OrderBy(outer.CompileAny(c, declarations), v.IsOrderAscending(i));
            }
            return s;
        }
    }
}
