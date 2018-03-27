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



namespace Net.Vpc.Upa.Impl.Uql
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class ExpressionTranslationManager {

        private static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager)).FullName);

        private Net.Vpc.Upa.Impl.Util.ClassMap<Net.Vpc.Upa.Impl.Uql.ExpressionTranslator> expressionProviders = new Net.Vpc.Upa.Impl.Util.ClassMap<Net.Vpc.Upa.Impl.Uql.ExpressionTranslator>();

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        private Net.Vpc.Upa.Impl.Uql.DefaultExpressionManager expressionManager;

        public ExpressionTranslationManager(Net.Vpc.Upa.Impl.Uql.DefaultExpressionManager expressionManager, Net.Vpc.Upa.PersistenceUnit persistenceUnit) {
            this.persistenceUnit = persistenceUnit;
            this.expressionManager = expressionManager;
            Register0(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression), new Net.Vpc.Upa.Impl.Uql.Compiler.CompiledExpressionToExpressionCompiler());
            Register0(typeof(Net.Vpc.Upa.Expressions.IdEnumerationExpression), new Net.Vpc.Upa.Impl.Uql.Compiler.IdEnumerationExpressionCompiler());
            Register0(typeof(Net.Vpc.Upa.Expressions.IdExpression), new Net.Vpc.Upa.Impl.Uql.Compiler.KeyExpressionCompiler());
            Register0(typeof(Net.Vpc.Upa.Expressions.And), new Net.Vpc.Upa.Impl.Uql.Compiler.AndExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Or), new Net.Vpc.Upa.Impl.Uql.Compiler.OrExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Plus), new Net.Vpc.Upa.Impl.Uql.Compiler.PlusExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Minus), new Net.Vpc.Upa.Impl.Uql.Compiler.MinusExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Div), new Net.Vpc.Upa.Impl.Uql.Compiler.DivExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Mul), new Net.Vpc.Upa.Impl.Uql.Compiler.MulExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Reminder), new Net.Vpc.Upa.Impl.Uql.Compiler.ReminderExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Like), new Net.Vpc.Upa.Impl.Uql.Compiler.LikeExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.LessThan), new Net.Vpc.Upa.Impl.Uql.Compiler.LessThanExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.LessEqualThan), new Net.Vpc.Upa.Impl.Uql.Compiler.LessEqualThanExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.GreaterThan), new Net.Vpc.Upa.Impl.Uql.Compiler.GreaterThanExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.GreaterEqualThan), new Net.Vpc.Upa.Impl.Uql.Compiler.GreaterEqualThanExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Equals), new Net.Vpc.Upa.Impl.Uql.Compiler.EqualsExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Not), new Net.Vpc.Upa.Impl.Uql.Compiler.NotExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Negative), new Net.Vpc.Upa.Impl.Uql.Compiler.NegativeExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Different), new Net.Vpc.Upa.Impl.Uql.Compiler.DifferentExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.LShift), new Net.Vpc.Upa.Impl.Uql.Compiler.LShiftExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.RShift), new Net.Vpc.Upa.Impl.Uql.Compiler.RShiftExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.URShift), new Net.Vpc.Upa.Impl.Uql.Compiler.URShiftExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Avg), new Net.Vpc.Upa.Impl.Uql.Compiler.AvgExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Min), new Net.Vpc.Upa.Impl.Uql.Compiler.MinExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Max), new Net.Vpc.Upa.Impl.Uql.Compiler.MaxExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Sum), new Net.Vpc.Upa.Impl.Uql.Compiler.SumExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Between), new Net.Vpc.Upa.Impl.Uql.Compiler.BetweenExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.BitAnd), new Net.Vpc.Upa.Impl.Uql.Compiler.BitAndExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.BitOr), new Net.Vpc.Upa.Impl.Uql.Compiler.BitOrExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.XOr), new Net.Vpc.Upa.Impl.Uql.Compiler.XOrExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Cast), new Net.Vpc.Upa.Impl.Uql.Compiler.CastExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Coalesce), new Net.Vpc.Upa.Impl.Uql.Compiler.CoalesceExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Complement), new Net.Vpc.Upa.Impl.Uql.Compiler.ComplementExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Concat), new Net.Vpc.Upa.Impl.Uql.Compiler.ConcatExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Count), new Net.Vpc.Upa.Impl.Uql.Compiler.CountExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.D2V), new Net.Vpc.Upa.Impl.Uql.Compiler.D2VExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.I2V), new Net.Vpc.Upa.Impl.Uql.Compiler.I2VExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Var), new Net.Vpc.Upa.Impl.Uql.Compiler.VarExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Param), new Net.Vpc.Upa.Impl.Uql.Compiler.ParamExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Literal), new Net.Vpc.Upa.Impl.Uql.Compiler.LiteralExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Uplet), new Net.Vpc.Upa.Impl.Uql.Compiler.UpletExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.UserExpression), new Net.Vpc.Upa.Impl.Uql.Compiler.UserExpressionExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Select), new Net.Vpc.Upa.Impl.Uql.Compiler.SelectExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.EntityName), new Net.Vpc.Upa.Impl.Uql.Compiler.EntityNameExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Insert), new Net.Vpc.Upa.Impl.Uql.Compiler.InsertExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.InsertSelection), new Net.Vpc.Upa.Impl.Uql.Compiler.InsertSelectionExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Update), new Net.Vpc.Upa.Impl.Uql.Compiler.UpdateExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.Delete), new Net.Vpc.Upa.Impl.Uql.Compiler.DeleteExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.CurrentTime), new Net.Vpc.Upa.Impl.Uql.Compiler.CurrentTimeExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.CurrentTimestamp), new Net.Vpc.Upa.Impl.Uql.Compiler.CurrentTimestampExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.CurrentDate), new Net.Vpc.Upa.Impl.Uql.Compiler.CurrentDateExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.CurrentUser), new Net.Vpc.Upa.Impl.Uql.Compiler.CurrentUserExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.DatePart), new Net.Vpc.Upa.Impl.Uql.Compiler.DatePartExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.DateDiff), new Net.Vpc.Upa.Impl.Uql.Compiler.DateDiffExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.DateAdd), new Net.Vpc.Upa.Impl.Uql.Compiler.DateAddExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.DateTrunc), new Net.Vpc.Upa.Impl.Uql.Compiler.DateTruncExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Impl.Uql.QLFunctionExpression), new Net.Vpc.Upa.Impl.Uql.Compiler.QLFunctionExpressionExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.InSelection), new Net.Vpc.Upa.Impl.Uql.Compiler.InSelectionExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.InCollection), new Net.Vpc.Upa.Impl.Uql.Compiler.InCollectionExpressionTranslator());
            Register0(typeof(Net.Vpc.Upa.Expressions.IsHierarchyDescendent), new Net.Vpc.Upa.Impl.Uql.Compiler.IsHierarchyDescendentExpressionTranslator());
        }

        public virtual Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        public virtual void Register(System.Type t, Net.Vpc.Upa.Impl.Uql.ExpressionTranslator compiler) {
            Register0(t, compiler);
        }

        private void Register0(System.Type t, Net.Vpc.Upa.Impl.Uql.ExpressionTranslator compiler) {
            expressionProviders.Put(t, compiler);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression CompileExpression(Net.Vpc.Upa.Expressions.Expression expression, Net.Vpc.Upa.Persistence.ExpressionCompilerConfig config) {
            if (/*IsLoggable=*/true) {
            }
            //expected api 1.2.1
            //            log.log(Level.FINE,"Compiling Expression " + expression);
            if (expression == null) {
                throw new System.NullReferenceException("Null Expression could not be compiled");
            }
            Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList dec = new Net.Vpc.Upa.Impl.Uql.DefaultExpressionDeclarationList(null);
            if (config.GetAliasToEntityContext() != null) {
                foreach (System.Collections.Generic.KeyValuePair<string , string> entry in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,string>>(config.GetAliasToEntityContext())) {
                    // check entity existence
                    persistenceUnit.GetEntity((entry).Value);
                    dec.ExportDeclaration((entry).Key, Net.Vpc.Upa.Impl.Uql.DecObjectType.ENTITY, (entry).Value, null);
                }
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression s = TranslateAny(expression, dec);
            if (s is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement qs = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement) s;
                System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField> fields = qs.GetFields();
                for (int i = 0; i < (fields).Count; i++) {
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField field = fields[i];
                    field.SetIndex(i);
                }
            }
            return s;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateAny(Net.Vpc.Upa.Expressions.Expression o, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (o == null) {
                return null;
            }
            object o0 = o;
            while (true) {
                Net.Vpc.Upa.Impl.Uql.ExpressionTranslator p = expressionProviders.Get(o0.GetType());
                if (p == null) {
                    throw new System.ArgumentException ("No compiler found for " + o0.GetType());
                }
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e = p.TranslateExpression(o0, this, declarations);
                if (e == null) {
                    throw new System.NullReferenceException();
                }
                if (e is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledExpandableExpression) {
                    e = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledExpandableExpression) e).Expand(persistenceUnit);
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

        public virtual Net.Vpc.Upa.Impl.Uql.DefaultExpressionManager GetExpressionManager() {
            return expressionManager;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] TranslateArray(Net.Vpc.Upa.Expressions.Expression[] e, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (e == null) {
                return null;
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] ce = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[e.Length];
            for (int i = 0; i < ce.Length; i++) {
                ce[i] = TranslateAny(e[i], declarations);
            }
            return ce;
        }
    }
}
