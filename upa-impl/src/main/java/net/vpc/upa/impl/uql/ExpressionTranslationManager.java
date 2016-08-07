/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql;

import net.vpc.upa.impl.uql.compiledexpression.CompiledQueryField;
import net.vpc.upa.impl.uql.compiledexpression.CompiledQueryStatement;
import net.vpc.upa.impl.uql.compiler.CurrentTimeExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.DateDiffExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.D2VExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.CastExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.ParamExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.LShiftExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.RShiftExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.DeleteExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.CurrentUserExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.AvgExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.InSelectionExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.XOrExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.I2VExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.MinExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.LiteralExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.EqualsExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.DifferentExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.GreaterEqualThanExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.EntityNameExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.CoalesceExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.DateAddExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.DatePartExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.CurrentDateExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.UpletExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.CurrentTimestampExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.URShiftExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.MaxExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.ComplementExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.SumExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.InsertSelectionExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.BitOrExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.BitAndExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.ConcatExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.QLFunctionExpressionExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.BetweenExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.UserExpressionExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.CountExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.UpdateExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.InsertExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.SelectExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.DateTruncExpressionTranslator;
import net.vpc.upa.impl.uql.compiler.*;

import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.expressions.And;
import net.vpc.upa.expressions.Avg;
import net.vpc.upa.expressions.Between;
import net.vpc.upa.expressions.BitAnd;
import net.vpc.upa.expressions.BitOr;
import net.vpc.upa.expressions.Cast;
import net.vpc.upa.expressions.Coalesce;
import net.vpc.upa.expressions.Complement;
import net.vpc.upa.expressions.Concat;
import net.vpc.upa.expressions.Count;
import net.vpc.upa.expressions.CurrentDate;
import net.vpc.upa.expressions.CurrentTime;
import net.vpc.upa.expressions.CurrentTimestamp;
import net.vpc.upa.expressions.CurrentUser;
import net.vpc.upa.expressions.D2V;
import net.vpc.upa.expressions.DateAdd;
import net.vpc.upa.expressions.DateDiff;
import net.vpc.upa.expressions.DatePart;
import net.vpc.upa.expressions.DateTrunc;
import net.vpc.upa.expressions.Delete;
import net.vpc.upa.expressions.Different;
import net.vpc.upa.expressions.Div;
import net.vpc.upa.expressions.EntityName;
import net.vpc.upa.expressions.Equals;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.GreaterEqualThan;
import net.vpc.upa.expressions.GreaterThan;
import net.vpc.upa.expressions.I2V;
import net.vpc.upa.expressions.InSelection;
import net.vpc.upa.expressions.Insert;
import net.vpc.upa.expressions.InsertSelection;
import net.vpc.upa.expressions.LShift;
import net.vpc.upa.expressions.LessEqualThan;
import net.vpc.upa.expressions.LessThan;
import net.vpc.upa.expressions.Like;
import net.vpc.upa.expressions.Literal;
import net.vpc.upa.expressions.Max;
import net.vpc.upa.expressions.Min;
import net.vpc.upa.expressions.Minus;
import net.vpc.upa.expressions.Mul;
import net.vpc.upa.expressions.Negative;
import net.vpc.upa.expressions.Not;
import net.vpc.upa.expressions.Or;
import net.vpc.upa.expressions.Param;
import net.vpc.upa.expressions.Plus;
import net.vpc.upa.expressions.RShift;
import net.vpc.upa.expressions.Reminder;
import net.vpc.upa.expressions.Select;
import net.vpc.upa.expressions.Sum;
import net.vpc.upa.expressions.IsHierarchyDescendent;
import net.vpc.upa.expressions.URShift;
import net.vpc.upa.expressions.Update;
import net.vpc.upa.expressions.Uplet;
import net.vpc.upa.expressions.UserExpression;
import net.vpc.upa.expressions.Var;
import net.vpc.upa.expressions.XOr;
import net.vpc.upa.impl.uql.compiledexpression.CompiledExpandableExpression;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;
import net.vpc.upa.expressions.IdEnumerationExpression;
import net.vpc.upa.expressions.InCollection;
import net.vpc.upa.expressions.IdExpression;
import net.vpc.upa.impl.util.ClassMap;
import net.vpc.upa.persistence.ExpressionCompilerConfig;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class ExpressionTranslationManager {

    private static Logger log = Logger.getLogger(ExpressionTranslationManager.class.getName());
    private ClassMap<ExpressionTranslator> expressionProviders = new ClassMap<ExpressionTranslator>();
    private PersistenceUnit persistenceUnit;
    private DefaultExpressionManager expressionManager;

    public ExpressionTranslationManager(DefaultExpressionManager expressionManager, PersistenceUnit persistenceUnit) {
        this.persistenceUnit = persistenceUnit;
        this.expressionManager = expressionManager;
        register0(DefaultCompiledExpression.class, new CompiledExpressionToExpressionCompiler());
        register0(IdEnumerationExpression.class, new IdEnumerationExpressionCompiler());
        register0(IdExpression.class, new KeyExpressionCompiler());
        register0(And.class, new AndExpressionTranslator());
        register0(Or.class, new OrExpressionTranslator());
        register0(Plus.class, new PlusExpressionTranslator());
        register0(Minus.class, new MinusExpressionTranslator());
        register0(Div.class, new DivExpressionTranslator());
        register0(Mul.class, new MulExpressionTranslator());
        register0(Reminder.class, new ReminderExpressionTranslator());
        register0(Like.class, new LikeExpressionTranslator());
        register0(LessThan.class, new LessThanExpressionTranslator());
        register0(LessEqualThan.class, new LessEqualThanExpressionTranslator());
        register0(GreaterThan.class, new GreaterThanExpressionTranslator());
        register0(GreaterEqualThan.class, new GreaterEqualThanExpressionTranslator());
        register0(Equals.class, new EqualsExpressionTranslator());
        register0(Not.class, new NotExpressionTranslator());
        register0(Negative.class, new NegativeExpressionTranslator());
        register0(Different.class, new DifferentExpressionTranslator());
        register0(LShift.class, new LShiftExpressionTranslator());
        register0(RShift.class, new RShiftExpressionTranslator());
        register0(URShift.class, new URShiftExpressionTranslator());
        register0(Avg.class, new AvgExpressionTranslator());
        register0(Min.class, new MinExpressionTranslator());
        register0(Max.class, new MaxExpressionTranslator());
        register0(Sum.class, new SumExpressionTranslator());
        register0(Between.class, new BetweenExpressionTranslator());
        register0(BitAnd.class, new BitAndExpressionTranslator());
        register0(BitOr.class, new BitOrExpressionTranslator());
        register0(XOr.class, new XOrExpressionTranslator());
        register0(Cast.class, new CastExpressionTranslator());
        register0(Coalesce.class, new CoalesceExpressionTranslator());
        register0(Complement.class, new ComplementExpressionTranslator());
        register0(Concat.class, new ConcatExpressionTranslator());
        register0(Count.class, new CountExpressionTranslator());
        register0(D2V.class, new D2VExpressionTranslator());
        register0(I2V.class, new I2VExpressionTranslator());
        register0(Var.class, new VarExpressionTranslator());
        register0(Param.class, new ParamExpressionTranslator());
        register0(Literal.class, new LiteralExpressionTranslator());
        register0(Uplet.class, new UpletExpressionTranslator());
        register0(UserExpression.class, new UserExpressionExpressionTranslator());
        register0(Select.class, new SelectExpressionTranslator());
        register0(EntityName.class, new EntityNameExpressionTranslator());
        register0(Insert.class, new InsertExpressionTranslator());
        register0(InsertSelection.class, new InsertSelectionExpressionTranslator());
        register0(Update.class, new UpdateExpressionTranslator());
        register0(Delete.class, new DeleteExpressionTranslator());
        register0(CurrentTime.class, new CurrentTimeExpressionTranslator());
        register0(CurrentTimestamp.class, new CurrentTimestampExpressionTranslator());
        register0(CurrentDate.class, new CurrentDateExpressionTranslator());
        register0(CurrentUser.class, new CurrentUserExpressionTranslator());
        register0(DatePart.class, new DatePartExpressionTranslator());
        register0(DateDiff.class, new DateDiffExpressionTranslator());
        register0(DateAdd.class, new DateAddExpressionTranslator());
        register0(DateTrunc.class, new DateTruncExpressionTranslator());
        register0(QLFunctionExpression.class, new QLFunctionExpressionExpressionTranslator());
        register0(InSelection.class, new InSelectionExpressionTranslator());
        register0(InCollection.class, new InCollectionExpressionTranslator());
        register0(IsHierarchyDescendent.class, new IsHierarchyDescendentExpressionTranslator());
    }

    public PersistenceUnit getPersistenceUnit() {
        return persistenceUnit;
    }

    public void register(Class t, ExpressionTranslator compiler) {
        register0(t, compiler);
    }

    private void register0(Class t, ExpressionTranslator compiler) {
        expressionProviders.put(t, compiler);
    }

    public DefaultCompiledExpression compileExpression(Expression expression, ExpressionCompilerConfig config) {
        if (log.isLoggable(Level.FINE)) {
            //expected api 1.2.1
//            log.log(Level.FINE,"Compiling Expression " + expression);
        }
        if (expression == null) {
            throw new NullPointerException("Null Expression could not be compiled");
        }
        ExpressionDeclarationList dec = new DefaultExpressionDeclarationList(null);
        if (config.getAliasToEntityContext() != null) {
            for (Map.Entry<String, String> entry : config.getAliasToEntityContext().entrySet()) {

                // check entity existence
                persistenceUnit.getEntity(entry.getValue());

                dec.exportDeclaration(entry.getKey(), DecObjectType.ENTITY, entry.getValue(), null);
            }
        }
        DefaultCompiledExpression s = translateAny(expression, dec);

        if (s instanceof CompiledQueryStatement) {
            CompiledQueryStatement qs=(CompiledQueryStatement) s;
            java.util.List<CompiledQueryField> fields = qs.getFields();
            for (int i = 0; i < fields.size(); i++) {
                CompiledQueryField field = fields.get(i);
                field.setIndex(i);
            }
        }

        return s;
    }

    public DefaultCompiledExpression translateAny(Expression o, ExpressionDeclarationList declarations) {
        if (o == null) {
            return null;
        }
        Object o0 = o;
        while (true) {
            ExpressionTranslator p = expressionProviders.get(o0.getClass());
            if (p == null) {
                throw new IllegalArgumentException("No compiler found for " + o0.getClass());
            }
            DefaultCompiledExpression e = p.translateExpression(o0, this, declarations);
            if (e == null) {
                throw new NullPointerException();
            }
            if (e instanceof CompiledExpandableExpression) {
                e = ((CompiledExpandableExpression) e).expand(persistenceUnit);
            }
            if (e == null) {
                throw new NullPointerException();
            }
            if (e == o0) {
                return e;
            }
            o0 = e;
        }
    }

    public DefaultExpressionManager getExpressionManager() {
        return expressionManager;
    }

    public DefaultCompiledExpression[] translateArray(Expression[] e, ExpressionDeclarationList declarations) {
        if (e == null) {
            return null;
        }
        DefaultCompiledExpression[] ce = new DefaultCompiledExpression[e.length];
        for (int i = 0; i < ce.length; i++) {
            ce[i] = translateAny(e[i], declarations);
        }
        return ce;
    }
}
