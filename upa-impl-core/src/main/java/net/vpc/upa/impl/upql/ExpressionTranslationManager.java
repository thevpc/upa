/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.upql;

import net.vpc.upa.impl.upql.ext.toext.ExistsExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.IsHierarchyDescendantExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.ExpExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.ReminderExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.InCollectionExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.NotExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.NegativeExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.UnionExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.PlusExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.OrExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.IdEnumerationExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.DayExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.IdExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.IfExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.MinuteExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.YearExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.MulExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.DivExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.VarExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.LikeExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.LessThanExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.AndExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.LessEqualThanExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.GreaterThanExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.SecondExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.CompiledExpressionToExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.MinusExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.MonthExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.HourExpressionTranslator;
import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.expressions.*;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.upql.ext.toext.CurrentTimeExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.DateDiffExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.ToStringExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.CastExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.ParamExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.LShiftExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.RShiftExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.DeleteExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.CurrentUserExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.AvgExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.InSelectionExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.XOrExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.MinExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.LiteralExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.EqualsExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.DifferentExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.GreaterEqualThanExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.EntityNameExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.CoalesceExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.DateAddExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.DatePartExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.CurrentDateExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.UpletExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.CurrentTimestampExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.URShiftExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.MaxExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.ComplementExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.SumExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.InsertSelectionExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.BitOrExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.BitAndExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.ConcatExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.QLFunctionExpressionExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.BetweenExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.UserExpressionExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.CountExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.UpdateExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.InsertExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.SelectExpressionTranslator;
import net.vpc.upa.impl.upql.ext.toext.DateTruncExpressionTranslator;

import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.impl.upql.ext.expr.CompiledExpandableExpression;
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
        register0(CompiledExpressionExt.class, new CompiledExpressionToExpressionTranslator());
        register0(IdEnumerationExpression.class, new IdEnumerationExpressionTranslator());
        register0(IdExpression.class, new IdExpressionTranslator());
        register0(And.class, new AndExpressionTranslator());
        register0(If.class, new IfExpressionTranslator());
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
        register0(ToString.class, new ToStringExpressionTranslator());
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
        register0(Second.class, new SecondExpressionTranslator());
        register0(Minute.class, new MinuteExpressionTranslator());
        register0(Hour.class, new HourExpressionTranslator());
        register0(Day.class, new DayExpressionTranslator());
        register0(Month.class, new MonthExpressionTranslator());
        register0(Month.class, new MonthExpressionTranslator());
        register0(Year.class, new YearExpressionTranslator());
        register0(QLFunctionExpression.class, new QLFunctionExpressionExpressionTranslator());
        register0(InSelection.class, new InSelectionExpressionTranslator());
        register0(InCollection.class, new InCollectionExpressionTranslator());
        register0(IsHierarchyDescendant.class, new IsHierarchyDescendantExpressionTranslator());
        register0(Exists.class, new ExistsExpressionTranslator());
        register0(Exp.class, new ExpExpressionTranslator());
        register0(Union.class, new UnionExpressionTranslator());
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

    public CompiledExpressionExt translateExpression(Expression expression, ExpressionCompilerConfig config) {
        if (log.isLoggable(Level.FINE)) {
            //expected api 1.2.1
//            log.log(Level.FINE,"Compiling Expression " + expression);
        }
        if (expression == null) {
            throw new NullPointerException("Null Expression could not be compiled");
        }
        ExpressionDeclarationList dec = new DefaultExpressionDeclarationList(null);
        for (Map.Entry<String, String> entry : config.getAliasToEntityContext().entrySet()) {

            // check entity existence
            persistenceUnit.getEntity(entry.getValue());

            dec.exportDeclaration(entry.getKey(), DecObjectType.ENTITY, entry.getValue(), null);
        }
        CompiledExpressionExt s = translateAny(expression, dec);

//        if (s instanceof CompiledQueryStatement) {
//            CompiledQueryStatement qs=(CompiledQueryStatement) s;
//            java.util.List<CompiledQueryField> fields = qs.getFields();
//            for (int i = 0; i < fields.size(); i++) {
//                CompiledQueryField field = fields.get(i);
//                field.setIndex(i);
//            }
//        }

        return s;
    }

    public CompiledExpressionExt translateAny(Expression o, ExpressionDeclarationList declarations) {
        if (o == null) {
            return null;
        }
        Object o0 = o;
        while (true) {
            ExpressionTranslator p = expressionProviders.get(o0.getClass());
            if (p == null) {
                throw new IllegalUPAArgumentException("No compiler found for " + o0.getClass());
            }
            CompiledExpressionExt e = p.translateExpression(o0, this, declarations);
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

    public CompiledExpressionExt[] translateArray(Expression[] e, ExpressionDeclarationList declarations) {
        if (e == null) {
            return null;
        }
        CompiledExpressionExt[] ce = new CompiledExpressionExt[e.length];
        for (int i = 0; i < ce.length; i++) {
            ce[i] = translateAny(e[i], declarations);
        }
        return ce;
    }
}