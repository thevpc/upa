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
            Register0(typeof(Net.Vpc.Upa.Impl.Uql.Expression.KeyEnumerationExpression), new Net.Vpc.Upa.Impl.Uql.Compiler.KeyEnumerationExpressionCompiler());
            Register0(typeof(Net.Vpc.Upa.Impl.Uql.Expression.KeyExpression), new Net.Vpc.Upa.Impl.Uql.Compiler.KeyExpressionCompiler());
            Register0(typeof(Net.Vpc.Upa.Expressions.And), new Net.Vpc.Upa.Impl.Uql.Compiler.AndExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Or), new Net.Vpc.Upa.Impl.Uql.Compiler.OrExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Plus), new Net.Vpc.Upa.Impl.Uql.Compiler.PlusExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Minus), new Net.Vpc.Upa.Impl.Uql.Compiler.MinusExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Div), new Net.Vpc.Upa.Impl.Uql.Compiler.DivExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Mul), new Net.Vpc.Upa.Impl.Uql.Compiler.MulExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Reminder), new Net.Vpc.Upa.Impl.Uql.Compiler.ReminderExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Like), new Net.Vpc.Upa.Impl.Uql.Compiler.LikeExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.LessThan), new Net.Vpc.Upa.Impl.Uql.Compiler.LessThanExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.LessEqualThan), new Net.Vpc.Upa.Impl.Uql.Compiler.LessEqualThanExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.GreaterThan), new Net.Vpc.Upa.Impl.Uql.Compiler.GreaterThanExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.GreaterEqualThan), new Net.Vpc.Upa.Impl.Uql.Compiler.GreaterEqualThanExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Equals), new Net.Vpc.Upa.Impl.Uql.Compiler.EqualsExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Not), new Net.Vpc.Upa.Impl.Uql.Compiler.NotExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Negative), new Net.Vpc.Upa.Impl.Uql.Compiler.NegativeExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Different), new Net.Vpc.Upa.Impl.Uql.Compiler.DifferentExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.LShift), new Net.Vpc.Upa.Impl.Uql.Compiler.LShiftExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.RShift), new Net.Vpc.Upa.Impl.Uql.Compiler.RShiftExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.URShift), new Net.Vpc.Upa.Impl.Uql.Compiler.URShiftExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Avg), new Net.Vpc.Upa.Impl.Uql.Compiler.AvgExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Min), new Net.Vpc.Upa.Impl.Uql.Compiler.MinExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Max), new Net.Vpc.Upa.Impl.Uql.Compiler.MaxExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Sum), new Net.Vpc.Upa.Impl.Uql.Compiler.SumExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Between), new Net.Vpc.Upa.Impl.Uql.Compiler.BetweenExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.BitAnd), new Net.Vpc.Upa.Impl.Uql.Compiler.BitAndExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.BitOr), new Net.Vpc.Upa.Impl.Uql.Compiler.BitOrExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.XOr), new Net.Vpc.Upa.Impl.Uql.Compiler.XOrExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Cast), new Net.Vpc.Upa.Impl.Uql.Compiler.CastExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Coalesce), new Net.Vpc.Upa.Impl.Uql.Compiler.CoalesceExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Complement), new Net.Vpc.Upa.Impl.Uql.Compiler.ComplementExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Concat), new Net.Vpc.Upa.Impl.Uql.Compiler.ConcatExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Count), new Net.Vpc.Upa.Impl.Uql.Compiler.CountExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.D2V), new Net.Vpc.Upa.Impl.Uql.Compiler.D2VExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.I2V), new Net.Vpc.Upa.Impl.Uql.Compiler.I2VExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Var), new Net.Vpc.Upa.Impl.Uql.Compiler.VarExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Param), new Net.Vpc.Upa.Impl.Uql.Compiler.ParamExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Literal), new Net.Vpc.Upa.Impl.Uql.Compiler.LiteralExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Uplet), new Net.Vpc.Upa.Impl.Uql.Compiler.UpletExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.UserExpression), new Net.Vpc.Upa.Impl.Uql.Compiler.UserExpressionExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Select), new Net.Vpc.Upa.Impl.Uql.Compiler.SelectExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.EntityName), new Net.Vpc.Upa.Impl.Uql.Compiler.EntityNameExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Insert), new Net.Vpc.Upa.Impl.Uql.Compiler.InsertExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.InsertSelection), new Net.Vpc.Upa.Impl.Uql.Compiler.InsertSelectionExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Update), new Net.Vpc.Upa.Impl.Uql.Compiler.UpdateExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.Delete), new Net.Vpc.Upa.Impl.Uql.Compiler.DeleteExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.CurrentTime), new Net.Vpc.Upa.Impl.Uql.Compiler.CurrentTimeExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.CurrentTimestamp), new Net.Vpc.Upa.Impl.Uql.Compiler.CurrentTimestampExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.CurrentDate), new Net.Vpc.Upa.Impl.Uql.Compiler.CurrentDateExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.CurrentUser), new Net.Vpc.Upa.Impl.Uql.Compiler.CurrentUserExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.DatePart), new Net.Vpc.Upa.Impl.Uql.Compiler.DatePartExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.DateDiff), new Net.Vpc.Upa.Impl.Uql.Compiler.DateDiffExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.DateAdd), new Net.Vpc.Upa.Impl.Uql.Compiler.DateAddExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.DateTrunc), new Net.Vpc.Upa.Impl.Uql.Compiler.DateTruncExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Impl.Uql.QLFunctionExpression), new Net.Vpc.Upa.Impl.Uql.Compiler.QLFunctionExpressionExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.InSelection), new Net.Vpc.Upa.Impl.Uql.Compiler.InSelectionExpressionTranslator(this));
            Register0(typeof(Net.Vpc.Upa.Expressions.IsHierarchyDescendent), new Net.Vpc.Upa.Impl.Uql.Compiler.IsHierarchyDescendentExpressionTranslator(this));
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
                foreach (System.Collections.Generic.KeyValuePair<string , string> entry in config.GetAliasToEntityContext()) {
                    // check entity existence
                    persistenceUnit.GetEntity((entry).Value);
                    dec.ExportDeclaration((entry).Key, Net.Vpc.Upa.Impl.Uql.DecObjectType.ENTITY, (entry).Value, null);
                }
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression s = CompileAny(expression, dec);
            return s;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression CompileAny(object o, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
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

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] CompileArray(Net.Vpc.Upa.Expressions.Expression[] e, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (e == null) {
                return null;
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] ce = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[e.Length];
            for (int i = 0; i < ce.Length; i++) {
                ce[i] = CompileAny(e[i], declarations);
            }
            return ce;
        }
    }
}
