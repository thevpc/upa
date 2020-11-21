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



namespace Net.TheVpc.Upa.Impl.Uql
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class ExpressionTranslationManager {

        private static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager)).FullName);

        private Net.TheVpc.Upa.Impl.Util.ClassMap<Net.TheVpc.Upa.Impl.Uql.ExpressionTranslator> expressionProviders = new Net.TheVpc.Upa.Impl.Util.ClassMap<Net.TheVpc.Upa.Impl.Uql.ExpressionTranslator>();

        private Net.TheVpc.Upa.PersistenceUnit persistenceUnit;

        private Net.TheVpc.Upa.Impl.Uql.DefaultExpressionManager expressionManager;

        public ExpressionTranslationManager(Net.TheVpc.Upa.Impl.Uql.DefaultExpressionManager expressionManager, Net.TheVpc.Upa.PersistenceUnit persistenceUnit) {
            this.persistenceUnit = persistenceUnit;
            this.expressionManager = expressionManager;
            Register0(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression), new Net.TheVpc.Upa.Impl.Uql.Compiler.CompiledExpressionToExpressionCompiler());
            Register0(typeof(Net.TheVpc.Upa.Expressions.IdEnumerationExpression), new Net.TheVpc.Upa.Impl.Uql.Compiler.IdEnumerationExpressionCompiler());
            Register0(typeof(Net.TheVpc.Upa.Expressions.IdExpression), new Net.TheVpc.Upa.Impl.Uql.Compiler.KeyExpressionCompiler());
            Register0(typeof(Net.TheVpc.Upa.Expressions.And), new Net.TheVpc.Upa.Impl.Uql.Compiler.AndExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Or), new Net.TheVpc.Upa.Impl.Uql.Compiler.OrExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Plus), new Net.TheVpc.Upa.Impl.Uql.Compiler.PlusExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Minus), new Net.TheVpc.Upa.Impl.Uql.Compiler.MinusExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Div), new Net.TheVpc.Upa.Impl.Uql.Compiler.DivExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Mul), new Net.TheVpc.Upa.Impl.Uql.Compiler.MulExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Reminder), new Net.TheVpc.Upa.Impl.Uql.Compiler.ReminderExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Like), new Net.TheVpc.Upa.Impl.Uql.Compiler.LikeExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.LessThan), new Net.TheVpc.Upa.Impl.Uql.Compiler.LessThanExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.LessEqualThan), new Net.TheVpc.Upa.Impl.Uql.Compiler.LessEqualThanExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.GreaterThan), new Net.TheVpc.Upa.Impl.Uql.Compiler.GreaterThanExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.GreaterEqualThan), new Net.TheVpc.Upa.Impl.Uql.Compiler.GreaterEqualThanExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Equals), new Net.TheVpc.Upa.Impl.Uql.Compiler.EqualsExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Not), new Net.TheVpc.Upa.Impl.Uql.Compiler.NotExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Negative), new Net.TheVpc.Upa.Impl.Uql.Compiler.NegativeExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Different), new Net.TheVpc.Upa.Impl.Uql.Compiler.DifferentExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.LShift), new Net.TheVpc.Upa.Impl.Uql.Compiler.LShiftExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.RShift), new Net.TheVpc.Upa.Impl.Uql.Compiler.RShiftExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.URShift), new Net.TheVpc.Upa.Impl.Uql.Compiler.URShiftExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Avg), new Net.TheVpc.Upa.Impl.Uql.Compiler.AvgExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Min), new Net.TheVpc.Upa.Impl.Uql.Compiler.MinExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Max), new Net.TheVpc.Upa.Impl.Uql.Compiler.MaxExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Sum), new Net.TheVpc.Upa.Impl.Uql.Compiler.SumExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Between), new Net.TheVpc.Upa.Impl.Uql.Compiler.BetweenExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.BitAnd), new Net.TheVpc.Upa.Impl.Uql.Compiler.BitAndExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.BitOr), new Net.TheVpc.Upa.Impl.Uql.Compiler.BitOrExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.XOr), new Net.TheVpc.Upa.Impl.Uql.Compiler.XOrExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Cast), new Net.TheVpc.Upa.Impl.Uql.Compiler.CastExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Coalesce), new Net.TheVpc.Upa.Impl.Uql.Compiler.CoalesceExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Complement), new Net.TheVpc.Upa.Impl.Uql.Compiler.ComplementExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Concat), new Net.TheVpc.Upa.Impl.Uql.Compiler.ConcatExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Count), new Net.TheVpc.Upa.Impl.Uql.Compiler.CountExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.D2V), new Net.TheVpc.Upa.Impl.Uql.Compiler.D2VExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.I2V), new Net.TheVpc.Upa.Impl.Uql.Compiler.I2VExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Var), new Net.TheVpc.Upa.Impl.Uql.Compiler.VarExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Param), new Net.TheVpc.Upa.Impl.Uql.Compiler.ParamExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Literal), new Net.TheVpc.Upa.Impl.Uql.Compiler.LiteralExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Uplet), new Net.TheVpc.Upa.Impl.Uql.Compiler.UpletExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.UserExpression), new Net.TheVpc.Upa.Impl.Uql.Compiler.UserExpressionExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Select), new Net.TheVpc.Upa.Impl.Uql.Compiler.SelectExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.EntityName), new Net.TheVpc.Upa.Impl.Uql.Compiler.EntityNameExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Insert), new Net.TheVpc.Upa.Impl.Uql.Compiler.InsertExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.InsertSelection), new Net.TheVpc.Upa.Impl.Uql.Compiler.InsertSelectionExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Update), new Net.TheVpc.Upa.Impl.Uql.Compiler.UpdateExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.Delete), new Net.TheVpc.Upa.Impl.Uql.Compiler.DeleteExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.CurrentTime), new Net.TheVpc.Upa.Impl.Uql.Compiler.CurrentTimeExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.CurrentTimestamp), new Net.TheVpc.Upa.Impl.Uql.Compiler.CurrentTimestampExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.CurrentDate), new Net.TheVpc.Upa.Impl.Uql.Compiler.CurrentDateExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.CurrentUser), new Net.TheVpc.Upa.Impl.Uql.Compiler.CurrentUserExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.DatePart), new Net.TheVpc.Upa.Impl.Uql.Compiler.DatePartExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.DateDiff), new Net.TheVpc.Upa.Impl.Uql.Compiler.DateDiffExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.DateAdd), new Net.TheVpc.Upa.Impl.Uql.Compiler.DateAddExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.DateTrunc), new Net.TheVpc.Upa.Impl.Uql.Compiler.DateTruncExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Impl.Uql.QLFunctionExpression), new Net.TheVpc.Upa.Impl.Uql.Compiler.QLFunctionExpressionExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.InSelection), new Net.TheVpc.Upa.Impl.Uql.Compiler.InSelectionExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.InCollection), new Net.TheVpc.Upa.Impl.Uql.Compiler.InCollectionExpressionTranslator());
            Register0(typeof(Net.TheVpc.Upa.Expressions.IsHierarchyDescendent), new Net.TheVpc.Upa.Impl.Uql.Compiler.IsHierarchyDescendentExpressionTranslator());
        }

        public virtual Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        public virtual void Register(System.Type t, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslator compiler) {
            Register0(t, compiler);
        }

        private void Register0(System.Type t, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslator compiler) {
            expressionProviders.Put(t, compiler);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression CompileExpression(Net.TheVpc.Upa.Expressions.Expression expression, Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig config) {
            if (/*IsLoggable=*/true) {
            }
            //expected api 1.2.1
            //            log.log(Level.FINE,"Compiling Expression " + expression);
            if (expression == null) {
                throw new System.NullReferenceException("Null Expression could not be compiled");
            }
            Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList dec = new Net.TheVpc.Upa.Impl.Uql.DefaultExpressionDeclarationList(null);
            if (config.GetAliasToEntityContext() != null) {
                foreach (System.Collections.Generic.KeyValuePair<string , string> entry in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,string>>(config.GetAliasToEntityContext())) {
                    // check entity existence
                    persistenceUnit.GetEntity((entry).Value);
                    dec.ExportDeclaration((entry).Key, Net.TheVpc.Upa.Impl.Uql.DecObjectType.ENTITY, (entry).Value, null);
                }
            }
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression s = TranslateAny(expression, dec);
            if (s is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement) {
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement qs = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement) s;
                System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField> fields = qs.GetFields();
                for (int i = 0; i < (fields).Count; i++) {
                    Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField field = fields[i];
                    field.SetIndex(i);
                }
            }
            return s;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateAny(Net.TheVpc.Upa.Expressions.Expression o, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (o == null) {
                return null;
            }
            object o0 = o;
            while (true) {
                Net.TheVpc.Upa.Impl.Uql.ExpressionTranslator p = expressionProviders.Get(o0.GetType());
                if (p == null) {
                    throw new System.ArgumentException ("No compiler found for " + o0.GetType());
                }
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e = p.TranslateExpression(o0, this, declarations);
                if (e == null) {
                    throw new System.NullReferenceException();
                }
                if (e is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledExpandableExpression) {
                    e = ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledExpandableExpression) e).Expand(persistenceUnit);
                }
                if (e == null) {
                    throw new System.NullReferenceException();
                }
                if (e == o0) {
                    return e;
                }
                o0 = e;
            }
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.DefaultExpressionManager GetExpressionManager() {
            return expressionManager;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] TranslateArray(Net.TheVpc.Upa.Expressions.Expression[] e, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (e == null) {
                return null;
            }
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] ce = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[e.Length];
            for (int i = 0; i < ce.Length; i++) {
                ce[i] = TranslateAny(e[i], declarations);
            }
            return ce;
        }
    }
}
