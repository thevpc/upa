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



using System.Linq;
namespace Net.Vpc.Upa.Impl.Uql.Parser.Syntax
{


    /** UQL parser. */
    public class UQLParser : Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstants {

        private string GetIdentifierName(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token t) {
            if (t == null) {
                return null;
            }
            string s = t.image;
            if (s.StartsWith("`")) {
                return Net.Vpc.Upa.Impl.Util.Strings.UnescapeString(s.Substring(1, (s).Length - 1));
            } else {
                return s;
            }
        }

        private string GetStringLiteral(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token t) {
            string s = t.image;
            return Net.Vpc.Upa.Impl.Util.Strings.UnescapeString(s.Substring(1, (s).Length - 1));
        }

        public Net.Vpc.Upa.Expressions.Expression Any() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            Net.Vpc.Upa.Expressions.Expression r;
            if (Jj_2_1(2147483647)) {
                r = Select();
            } else if (Jj_2_2(2147483647)) {
                r = Update();
            } else if (Jj_2_3(2147483647)) {
                r = Delete();
            } else {
                switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IF:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.TRUE:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FALSE:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.NULL:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.NOT:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.INTEGER_LITERAL:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FLOATING_POINT_LITERAL:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.CHARACTER_LITERAL:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.STRING_LITERAL:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LPAREN:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.TILDE:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.COLON:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.PLUS:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.MINUS:
                        r = Expression();
                        break;
                    default:
                        jj_la1[0] = jj_gen;
                        Jj_consume_token(-1);
                        throw new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException();
                }
            }
            Jj_consume_token(0);
            {
                if (true) return r;
            }
            throw new System.Exception("Missing return statement in function");
        }

        /** Compilation unit. */
        public Net.Vpc.Upa.Expressions.Select Select() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            Net.Vpc.Upa.Expressions.Select r = new Net.Vpc.Upa.Expressions.Select();
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Parser.Syntax.DecoratedExpression> exprList = null;
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.JoinCriteria> joinList = null;
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> groupByList = null;
            Net.Vpc.Upa.Expressions.Expression having = null;
            Net.Vpc.Upa.Expressions.Select fromSelect = null;
            bool distinct = false;
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token fromToken = null;
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token fromAlias = null;
            Net.Vpc.Upa.Expressions.Expression where = null;
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Parser.Syntax.DecoratedExpression> orderList = null;
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token t;
            int top = -1;
            Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.SELECT);
            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.TOP:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.TOP);
                    t = Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.INTEGER_LITERAL);
                    top = (System.Convert.ToInt32(t.image));
                    break;
                default:
                    jj_la1[1] = jj_gen;
                    ;
                    break;
            }
            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.DISTINCT:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.DISTINCT);
                    distinct = true;
                    break;
                default:
                    jj_la1[2] = jj_gen;
                    ;
                    break;
            }
            exprList = NamedExpressionList();
            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FROM:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FROM);
                    switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                        case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER:
                            fromToken = Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER);
                            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER:
                                    fromAlias = Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER);
                                    break;
                                default:
                                    jj_la1[3] = jj_gen;
                                    ;
                                    break;
                            }
                            break;
                        case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LPAREN:
                            Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LPAREN);
                            fromSelect = Select();
                            Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.RPAREN);
                            fromAlias = Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER);
                            break;
                        default:
                            jj_la1[4] = jj_gen;
                            Jj_consume_token(-1);
                            throw new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException();
                    }
                    break;
                default:
                    jj_la1[5] = jj_gen;
                    ;
                    break;
            }
            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.INNER:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LEFT:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.RIGHT:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FULL:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.CROSS:
                    joinList = JoinList();
                    break;
                default:
                    jj_la1[6] = jj_gen;
                    ;
                    break;
            }
            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.WHERE:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.WHERE);
                    where = Expression();
                    break;
                default:
                    jj_la1[7] = jj_gen;
                    ;
                    break;
            }
            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.GROUP:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.GROUP);
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.BY);
                    groupByList = ExpressionList();
                    break;
                default:
                    jj_la1[8] = jj_gen;
                    ;
                    break;
            }
            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.HAVING:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.HAVING);
                    having = Expression();
                    break;
                default:
                    jj_la1[9] = jj_gen;
                    ;
                    break;
            }
            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.ORDER:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.ORDER);
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.BY);
                    orderList = OrderExpressionList();
                    break;
                default:
                    jj_la1[10] = jj_gen;
                    ;
                    break;
            }
            if (fromToken != null) {
                r.From(GetIdentifierName(fromToken), GetIdentifierName(fromAlias));
            } else if (fromSelect != null) {
                r.From(fromSelect, GetIdentifierName(fromAlias));
            }
            if (where != null) {
                r.Where(where);
            }
            if (exprList != null) {
                foreach (Net.Vpc.Upa.Impl.Uql.Parser.Syntax.DecoratedExpression ns in exprList) {
                    r.Field(ns.expression, ns.alias);
                }
            }
            if (orderList != null) {
                foreach (Net.Vpc.Upa.Impl.Uql.Parser.Syntax.DecoratedExpression ns in orderList) {
                    r.OrderBy(ns.expression, !ns.desc);
                }
            }
            if (joinList != null) {
                foreach (Net.Vpc.Upa.Expressions.JoinCriteria ns in joinList) {
                    r.Join(ns);
                }
            }
            if (groupByList != null) {
                foreach (Net.Vpc.Upa.Expressions.Expression ns in groupByList) {
                    r.GroupBy(ns);
                }
            }
            if (having != null) {
                r.Having(having);
            }
            if (distinct) {
                r.Distinct();
            }
            r.Top(top);
            {
                if (true) return r;
            }
            throw new System.Exception("Missing return statement in function");
        }

        public Net.Vpc.Upa.Expressions.Update Update() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            Net.Vpc.Upa.Expressions.Update r = new Net.Vpc.Upa.Expressions.Update();
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token entityToken = null;
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token fieldToken = null;
            Net.Vpc.Upa.Expressions.Expression fieldValue = null;
            Net.Vpc.Upa.Expressions.Expression where = null;
            Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.UPDATE);
            entityToken = Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER);
            r.Entity(GetIdentifierName(entityToken));
            Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.SET);
            fieldToken = Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER);
            Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.EQ);
            fieldValue = Expression();
            r.Set(GetIdentifierName(fieldToken), fieldValue);
            label_1: 
            while (true) {
                if (Jj_2_4(2147483647)) {
                    ;
                } else {
                    goto break_label_1;
                }
                fieldToken = Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER);
                Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.EQ);
                fieldValue = Expression();
                r.Set(GetIdentifierName(entityToken), fieldValue);
            }
            break_label_1 : {/*added by fwk*/}
            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.WHERE:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.WHERE);
                    where = Expression();
                    r.Where(where);
                    break;
                default:
                    jj_la1[11] = jj_gen;
                    ;
                    break;
            }
            {
                if (true) return r;
            }
            throw new System.Exception("Missing return statement in function");
        }

        public Net.Vpc.Upa.Expressions.Delete Delete() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            Net.Vpc.Upa.Expressions.Delete r = new Net.Vpc.Upa.Expressions.Delete();
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token entityToken = null;
            Net.Vpc.Upa.Expressions.Expression where = null;
            Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.DELETE);
            Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FROM);
            entityToken = Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER);
            r.From(GetIdentifierName(entityToken));
            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.WHERE:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.WHERE);
                    where = Expression();
                    r.Where(where);
                    break;
                default:
                    jj_la1[12] = jj_gen;
                    ;
                    break;
            }
            {
                if (true) return r;
            }
            throw new System.Exception("Missing return statement in function");
        }

        public System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.JoinCriteria> JoinList() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.JoinCriteria> r = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.JoinCriteria>();
            Net.Vpc.Upa.Expressions.JoinCriteria r0;
            Net.Vpc.Upa.Expressions.JoinCriteria ri;
            r0 = JoinDec();
            r.Add(r0);
            label_2: 
            while (true) {
                if (Jj_2_5(2147483647)) {
                    ;
                } else {
                    goto break_label_2;
                }
                ri = JoinDec();
                r.Add(ri);
            }
            break_label_2 : {/*added by fwk*/}
            {
                if (true) return r;
            }
            throw new System.Exception("Missing return statement in function");
        }

        public void JoinLookAhead() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.INNER:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.INNER);
                    break;
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LEFT:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LEFT);
                    break;
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.RIGHT:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.RIGHT);
                    break;
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FULL:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FULL);
                    break;
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.CROSS:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.CROSS);
                    break;
                default:
                    jj_la1[13] = jj_gen;
                    Jj_consume_token(-1);
                    throw new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException();
            }
        }

        public Net.Vpc.Upa.Expressions.JoinCriteria JoinDec() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            Net.Vpc.Upa.Expressions.JoinType type = Net.Vpc.Upa.Expressions.JoinType.CROSS_JOIN;
            Net.Vpc.Upa.Expressions.Expression condition = null;
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token fromAlias = null;
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token fromToken = null;
            Net.Vpc.Upa.Expressions.Select fromSelect = null;
            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.INNER:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.INNER);
                    type = Net.Vpc.Upa.Expressions.JoinType.INNER_JOIN;
                    break;
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LEFT:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LEFT);
                    type = Net.Vpc.Upa.Expressions.JoinType.LEFT_JOIN;
                    break;
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.RIGHT:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.RIGHT);
                    type = Net.Vpc.Upa.Expressions.JoinType.RIGHT_JOIN;
                    break;
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FULL:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FULL);
                    type = Net.Vpc.Upa.Expressions.JoinType.FULL_JOIN;
                    break;
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.CROSS:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.CROSS);
                    type = Net.Vpc.Upa.Expressions.JoinType.CROSS_JOIN;
                    break;
                default:
                    jj_la1[14] = jj_gen;
                    Jj_consume_token(-1);
                    throw new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException();
            }
            Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.JOIN);
            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER:
                    fromToken = Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER);
                    switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                        case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER:
                            fromAlias = Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER);
                            break;
                        default:
                            jj_la1[15] = jj_gen;
                            ;
                            break;
                    }
                    break;
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LPAREN:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LPAREN);
                    fromSelect = Select();
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.RPAREN);
                    fromAlias = Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER);
                    break;
                default:
                    jj_la1[16] = jj_gen;
                    Jj_consume_token(-1);
                    throw new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException();
            }
            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.ON:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.ON);
                    condition = Expression();
                    break;
                default:
                    jj_la1[17] = jj_gen;
                    ;
                    break;
            }
            {
                if (true) return new Net.Vpc.Upa.Expressions.JoinCriteria(type, (fromToken != null) ? (Net.Vpc.Upa.Expressions.NameOrSelect) new Net.Vpc.Upa.Expressions.EntityName(GetIdentifierName(fromToken)) : (Net.Vpc.Upa.Expressions.NameOrSelect) fromSelect, GetIdentifierName(fromAlias), condition);
            }
            throw new System.Exception("Missing return statement in function");
        }

        public System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Parser.Syntax.DecoratedExpression> NamedExpressionList() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Parser.Syntax.DecoratedExpression> r = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Parser.Syntax.DecoratedExpression>();
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.DecoratedExpression r0;
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.DecoratedExpression ri;
            r0 = NamedExpression();
            r.Add(r0);
            label_3: 
            while (true) {
                switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.COMMA:
                        ;
                        break;
                    default:
                        jj_la1[18] = jj_gen;
                        goto break_label_3;
                }
                Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.COMMA);
                ri = NamedExpression();
                r.Add(ri);
            }
            break_label_3 : {/*added by fwk*/}
            {
                if (true) return r;
            }
            throw new System.Exception("Missing return statement in function");
        }

        public System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Parser.Syntax.DecoratedExpression> OrderExpressionList() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Parser.Syntax.DecoratedExpression> r = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Parser.Syntax.DecoratedExpression>();
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.DecoratedExpression r0;
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.DecoratedExpression ri;
            r0 = OrderExpression();
            r.Add(r0);
            label_4: 
            while (true) {
                switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.COMMA:
                        ;
                        break;
                    default:
                        jj_la1[19] = jj_gen;
                        goto break_label_4;
                }
                Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.COMMA);
                ri = OrderExpression();
                r.Add(ri);
            }
            break_label_4 : {/*added by fwk*/}
            {
                if (true) return r;
            }
            throw new System.Exception("Missing return statement in function");
        }

        public Net.Vpc.Upa.Impl.Uql.Parser.Syntax.DecoratedExpression OrderExpression() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.DecoratedExpression r = new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.DecoratedExpression();
            bool orderDesc = false;
            r.expression = Expression();
            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.DESC:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.ASC:
                    switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                        case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.DESC:
                            Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.DESC);
                            orderDesc = true;
                            break;
                        case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.ASC:
                            Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.ASC);
                            orderDesc = false;
                            break;
                        default:
                            jj_la1[20] = jj_gen;
                            Jj_consume_token(-1);
                            throw new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException();
                    }
                    break;
                default:
                    jj_la1[21] = jj_gen;
                    ;
                    break;
            }
            r.desc = orderDesc;
            {
                if (true) return r;
            }
            throw new System.Exception("Missing return statement in function");
        }

        public Net.Vpc.Upa.Impl.Uql.Parser.Syntax.DecoratedExpression NamedExpression() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.DecoratedExpression r = new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.DecoratedExpression();
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token t = null;
            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.STAR:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.STAR);
                    switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                        case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.DOT:
                            Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.DOT);
                            t = Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER);
                            break;
                        default:
                            jj_la1[22] = jj_gen;
                            ;
                            break;
                    }
                    Net.Vpc.Upa.Expressions.Star p = new Net.Vpc.Upa.Expressions.Star();
                    Net.Vpc.Upa.Expressions.Var v;
                    if (t != null) {
                        v = new Net.Vpc.Upa.Expressions.Var(p, GetIdentifierName(t));
                        r.expression = v;
                    } else {
                        r.expression = p;
                    }
                    {
                        if (true) return r;
                    }
                    break;
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IF:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.TRUE:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FALSE:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.NULL:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.NOT:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.INTEGER_LITERAL:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FLOATING_POINT_LITERAL:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.CHARACTER_LITERAL:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.STRING_LITERAL:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LPAREN:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.TILDE:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.COLON:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.PLUS:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.MINUS:
                    r.expression = Expression();
                    switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                        case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER:
                            t = Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER);
                            break;
                        default:
                            jj_la1[23] = jj_gen;
                            ;
                            break;
                    }
                    if (t != null) {
                        r.alias = GetIdentifierName(t);
                    }
                    {
                        if (true) return r;
                    }
                    break;
                default:
                    jj_la1[24] = jj_gen;
                    Jj_consume_token(-1);
                    throw new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException();
            }
            throw new System.Exception("Missing return statement in function");
        }

        public System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> ExpressionList() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> r = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>();
            Net.Vpc.Upa.Expressions.Expression r0;
            Net.Vpc.Upa.Expressions.Expression ri;
            r0 = Expression();
            r.Add(r0);
            label_5: 
            while (true) {
                switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.COMMA:
                        ;
                        break;
                    default:
                        jj_la1[25] = jj_gen;
                        goto break_label_5;
                }
                Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.COMMA);
                ri = Expression();
                r.Add(ri);
            }
            break_label_5 : {/*added by fwk*/}
            {
                if (true) return r;
            }
            throw new System.Exception("Missing return statement in function");
        }

        public Net.Vpc.Upa.Expressions.Expression Expression() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            Net.Vpc.Upa.Expressions.Expression r;
            r = OrExpression();
            {
                if (true) return r;
            }
            throw new System.Exception("Missing return statement in function");
        }

        public Net.Vpc.Upa.Expressions.Expression OrExpression() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            Net.Vpc.Upa.Expressions.Expression left;
            Net.Vpc.Upa.Expressions.Expression right = null;
            left = AndExpression();
            label_6: 
            while (true) {
                switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.OR:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.SC_OR:
                        ;
                        break;
                    default:
                        jj_la1[26] = jj_gen;
                        goto break_label_6;
                }
                switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.OR:
                        Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.OR);
                        break;
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.SC_OR:
                        Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.SC_OR);
                        break;
                    default:
                        jj_la1[27] = jj_gen;
                        Jj_consume_token(-1);
                        throw new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException();
                }
                right = AndExpression();
                left = new Net.Vpc.Upa.Expressions.Or(left, right);
            }
            break_label_6 : {/*added by fwk*/}
            {
                if (true) return left;
            }
            throw new System.Exception("Missing return statement in function");
        }

        public Net.Vpc.Upa.Expressions.Expression AndExpression() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            Net.Vpc.Upa.Expressions.Expression left;
            Net.Vpc.Upa.Expressions.Expression right = null;
            left = CompExpression();
            label_7: 
            while (true) {
                switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.AND:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.SC_AND:
                        ;
                        break;
                    default:
                        jj_la1[28] = jj_gen;
                        goto break_label_7;
                }
                switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.AND:
                        Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.AND);
                        break;
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.SC_AND:
                        Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.SC_AND);
                        break;
                    default:
                        jj_la1[29] = jj_gen;
                        Jj_consume_token(-1);
                        throw new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException();
                }
                right = CompExpression();
                left = new Net.Vpc.Upa.Expressions.And(left, right);
            }
            break_label_7 : {/*added by fwk*/}
            {
                if (true) return left;
            }
            throw new System.Exception("Missing return statement in function");
        }

        public Net.Vpc.Upa.Expressions.Expression CompExpression() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            Net.Vpc.Upa.Expressions.Expression r;
            Net.Vpc.Upa.Expressions.Expression n = null;
            Net.Vpc.Upa.Expressions.BinaryOperator op;
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> parameters = null;
            r = PlusExpression();
            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LIKE:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IN:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.EQ2:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.GT:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LT:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.EQ:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LE:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.GE:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.NE:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.NE2:
                    if (Jj_2_7(2147483647)) {
                        Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IN);
                        Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LPAREN);
                        if (Jj_2_6(2147483647)) {
                            n = Select();
                        } else {
                            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IF:
                                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.TRUE:
                                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FALSE:
                                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.NULL:
                                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.NOT:
                                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.INTEGER_LITERAL:
                                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FLOATING_POINT_LITERAL:
                                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.CHARACTER_LITERAL:
                                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.STRING_LITERAL:
                                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER:
                                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LPAREN:
                                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.TILDE:
                                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.COLON:
                                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.PLUS:
                                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.MINUS:
                                    parameters = ExpressionList();
                                    break;
                                default:
                                    jj_la1[30] = jj_gen;
                                    Jj_consume_token(-1);
                                    throw new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException();
                            }
                        }
                        Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.RPAREN);
                        if (n != null) {
                            r = new Net.Vpc.Upa.Expressions.InSelection(r, (Net.Vpc.Upa.Expressions.Select) n);
                        } else {
                            r = new Net.Vpc.Upa.Expressions.InCollection(r, parameters);
                        }
                        n = null;
                        parameters = null;
                    } else if (Jj_2_8(2147483647)) {
                        switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.EQ:
                                Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.EQ);
                                op = Net.Vpc.Upa.Expressions.BinaryOperator.EQ;
                                break;
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.EQ2:
                                Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.EQ2);
                                op = Net.Vpc.Upa.Expressions.BinaryOperator.EQ;
                                break;
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.NE:
                                Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.NE);
                                op = Net.Vpc.Upa.Expressions.BinaryOperator.DIFF;
                                break;
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.NE2:
                                Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.NE2);
                                op = Net.Vpc.Upa.Expressions.BinaryOperator.DIFF;
                                break;
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LT:
                                Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LT);
                                op = Net.Vpc.Upa.Expressions.BinaryOperator.LT;
                                break;
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LE:
                                Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LE);
                                op = Net.Vpc.Upa.Expressions.BinaryOperator.LE;
                                break;
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.GT:
                                Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.GT);
                                op = Net.Vpc.Upa.Expressions.BinaryOperator.GT;
                                break;
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.GE:
                                Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.GE);
                                op = Net.Vpc.Upa.Expressions.BinaryOperator.GE;
                                break;
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LIKE:
                                Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LIKE);
                                op = Net.Vpc.Upa.Expressions.BinaryOperator.LIKE;
                                break;
                            default:
                                jj_la1[31] = jj_gen;
                                Jj_consume_token(-1);
                                throw new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException();
                        }
                        n = PlusExpression();
                        switch(op) {
                            case Net.Vpc.Upa.Expressions.BinaryOperator.EQ:
                                {
                                    r = new Net.Vpc.Upa.Expressions.Equals(r, n);
                                    break;
                                }
                            case Net.Vpc.Upa.Expressions.BinaryOperator.DIFF:
                                {
                                    r = new Net.Vpc.Upa.Expressions.Different(r, n);
                                    break;
                                }
                            case Net.Vpc.Upa.Expressions.BinaryOperator.LT:
                                {
                                    r = new Net.Vpc.Upa.Expressions.LessThan(r, n);
                                    break;
                                }
                            case Net.Vpc.Upa.Expressions.BinaryOperator.LE:
                                {
                                    r = new Net.Vpc.Upa.Expressions.LessEqualThan(r, n);
                                    break;
                                }
                            case Net.Vpc.Upa.Expressions.BinaryOperator.GT:
                                {
                                    r = new Net.Vpc.Upa.Expressions.GreaterThan(r, n);
                                    break;
                                }
                            case Net.Vpc.Upa.Expressions.BinaryOperator.GE:
                                {
                                    r = new Net.Vpc.Upa.Expressions.GreaterEqualThan(r, n);
                                    break;
                                }
                            case Net.Vpc.Upa.Expressions.BinaryOperator.LIKE:
                                {
                                    r = new Net.Vpc.Upa.Expressions.Like(r, n);
                                    break;
                                }
                        }
                    } else {
                        Jj_consume_token(-1);
                        throw new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException();
                    }
                    break;
                default:
                    jj_la1[32] = jj_gen;
                    ;
                    break;
            }
            {
                if (true) return r;
            }
            throw new System.Exception("Missing return statement in function");
        }

        public Net.Vpc.Upa.Expressions.Expression PlusExpression() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            Net.Vpc.Upa.Expressions.Expression left;
            Net.Vpc.Upa.Expressions.Expression right;
            Net.Vpc.Upa.Expressions.BinaryOperator op;
            left = MulExpression();
            label_8: 
            while (true) {
                switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.PLUS:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.MINUS:
                        ;
                        break;
                    default:
                        jj_la1[33] = jj_gen;
                        goto break_label_8;
                }
                switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.PLUS:
                        Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.PLUS);
                        op = Net.Vpc.Upa.Expressions.BinaryOperator.PLUS;
                        break;
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.MINUS:
                        Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.MINUS);
                        op = Net.Vpc.Upa.Expressions.BinaryOperator.MINUS;
                        break;
                    default:
                        jj_la1[34] = jj_gen;
                        Jj_consume_token(-1);
                        throw new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException();
                }
                right = MulExpression();
                switch(op) {
                    case Net.Vpc.Upa.Expressions.BinaryOperator.PLUS:
                        {
                            left = new Net.Vpc.Upa.Expressions.Plus(left, right);
                            break;
                        }
                    case Net.Vpc.Upa.Expressions.BinaryOperator.MINUS:
                        {
                            left = new Net.Vpc.Upa.Expressions.Minus(left, right);
                            break;
                        }
                }
            }
            break_label_8 : {/*added by fwk*/}
            {
                if (true) return left;
            }
            throw new System.Exception("Missing return statement in function");
        }

        public Net.Vpc.Upa.Expressions.Expression MulExpression() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            Net.Vpc.Upa.Expressions.Expression left;
            Net.Vpc.Upa.Expressions.Expression right;
            Net.Vpc.Upa.Expressions.BinaryOperator op;
            left = PowExpression();
            label_9: 
            while (true) {
                switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.STAR:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.SLASH:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.REM:
                        ;
                        break;
                    default:
                        jj_la1[35] = jj_gen;
                        goto break_label_9;
                }
                switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.SLASH:
                        Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.SLASH);
                        op = Net.Vpc.Upa.Expressions.BinaryOperator.DIV;
                        break;
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.STAR:
                        Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.STAR);
                        op = Net.Vpc.Upa.Expressions.BinaryOperator.MUL;
                        break;
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.REM:
                        Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.REM);
                        op = Net.Vpc.Upa.Expressions.BinaryOperator.REM;
                        break;
                    default:
                        jj_la1[36] = jj_gen;
                        Jj_consume_token(-1);
                        throw new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException();
                }
                right = PowExpression();
                switch(op) {
                    case Net.Vpc.Upa.Expressions.BinaryOperator.DIV:
                        {
                            left = new Net.Vpc.Upa.Expressions.Div(left, right);
                            break;
                        }
                    case Net.Vpc.Upa.Expressions.BinaryOperator.MUL:
                        {
                            left = new Net.Vpc.Upa.Expressions.Mul(left, right);
                            break;
                        }
                    case Net.Vpc.Upa.Expressions.BinaryOperator.REM:
                        {
                            left = new Net.Vpc.Upa.Expressions.Reminder(left, right);
                            break;
                        }
                }
            }
            break_label_9 : {/*added by fwk*/}
            {
                if (true) return left;
            }
            throw new System.Exception("Missing return statement in function");
        }

        public Net.Vpc.Upa.Expressions.Expression PowExpression() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            Net.Vpc.Upa.Expressions.Expression left;
            Net.Vpc.Upa.Expressions.Expression right;
            Net.Vpc.Upa.Expressions.BinaryOperator op;
            left = PrimaryExpression();
            label_10: 
            while (true) {
                switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.BIT_AND:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.BIT_OR:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.XOR:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LSHIFT:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.RSIGNEDSHIFT:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.RUNSIGNEDSHIFT:
                        ;
                        break;
                    default:
                        jj_la1[37] = jj_gen;
                        goto break_label_10;
                }
                switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.BIT_AND:
                        Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.BIT_AND);
                        op = Net.Vpc.Upa.Expressions.BinaryOperator.BIT_AND;
                        break;
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.BIT_OR:
                        Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.BIT_OR);
                        op = Net.Vpc.Upa.Expressions.BinaryOperator.BIT_OR;
                        break;
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.XOR:
                        Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.XOR);
                        op = Net.Vpc.Upa.Expressions.BinaryOperator.XOR;
                        break;
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LSHIFT:
                        Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LSHIFT);
                        op = Net.Vpc.Upa.Expressions.BinaryOperator.LSHIFT;
                        break;
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.RSIGNEDSHIFT:
                        Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.RSIGNEDSHIFT);
                        op = Net.Vpc.Upa.Expressions.BinaryOperator.RSHIFT;
                        break;
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.RUNSIGNEDSHIFT:
                        Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.RUNSIGNEDSHIFT);
                        op = Net.Vpc.Upa.Expressions.BinaryOperator.URSHIFT;
                        break;
                    default:
                        jj_la1[38] = jj_gen;
                        Jj_consume_token(-1);
                        throw new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException();
                }
                right = PrimaryExpression();
                switch(op) {
                    case Net.Vpc.Upa.Expressions.BinaryOperator.BIT_AND:
                        {
                            left = new Net.Vpc.Upa.Expressions.BitAnd(left, right);
                            break;
                        }
                    case Net.Vpc.Upa.Expressions.BinaryOperator.BIT_OR:
                        {
                            left = new Net.Vpc.Upa.Expressions.BitOr(left, right);
                            break;
                        }
                    case Net.Vpc.Upa.Expressions.BinaryOperator.XOR:
                        {
                            left = new Net.Vpc.Upa.Expressions.XOr(left, right);
                            break;
                        }
                    case Net.Vpc.Upa.Expressions.BinaryOperator.LSHIFT:
                        {
                            left = new Net.Vpc.Upa.Expressions.LShift(left, right);
                            break;
                        }
                    case Net.Vpc.Upa.Expressions.BinaryOperator.RSHIFT:
                        {
                            left = new Net.Vpc.Upa.Expressions.RShift(left, right);
                            break;
                        }
                    case Net.Vpc.Upa.Expressions.BinaryOperator.URSHIFT:
                        {
                            left = new Net.Vpc.Upa.Expressions.URShift(left, right);
                            break;
                        }
                }
            }
            break_label_10 : {/*added by fwk*/}
            {
                if (true) return left;
            }
            throw new System.Exception("Missing return statement in function");
        }

        public Net.Vpc.Upa.Expressions.Expression Param() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token t = null;
            Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.COLON);
            t = Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER);
            {
                if (true) return new Net.Vpc.Upa.Expressions.Param(GetIdentifierName(t));
            }
            throw new System.Exception("Missing return statement in function");
        }

        public Net.Vpc.Upa.Expressions.Expression VarOrFunction() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token t = null;
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token start;
            bool fct = false;
            bool indexer = false;
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> parameters = null;
            System.Collections.Generic.IList<string> vars = new System.Collections.Generic.List<string>();
            start = Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER);
            if (Jj_2_9(2147483647)) {
                Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LPAREN);
                switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IF:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.TRUE:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FALSE:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.NULL:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.NOT:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.INTEGER_LITERAL:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FLOATING_POINT_LITERAL:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.CHARACTER_LITERAL:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.STRING_LITERAL:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LPAREN:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.TILDE:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.COLON:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.PLUS:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.MINUS:
                        parameters = ExpressionList();
                        break;
                    default:
                        jj_la1[39] = jj_gen;
                        ;
                        break;
                }
                Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.RPAREN);
                fct = true;
            } else if (Jj_2_10(2147483647)) {
                Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LBRACKET);
                switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IF:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.TRUE:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FALSE:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.NULL:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.NOT:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.INTEGER_LITERAL:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FLOATING_POINT_LITERAL:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.CHARACTER_LITERAL:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.STRING_LITERAL:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LPAREN:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.TILDE:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.COLON:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.PLUS:
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.MINUS:
                        parameters = ExpressionList();
                        break;
                    default:
                        jj_la1[40] = jj_gen;
                        ;
                        break;
                }
                Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.RBRACKET);
                indexer = true;
            } else {
                label_11: 
                while (true) {
                    switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                        case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.DOT:
                            ;
                            break;
                        default:
                            jj_la1[41] = jj_gen;
                            goto break_label_11;
                    }
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.DOT);
                    switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                        case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER:
                            t = Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER);
                            vars.Add(GetIdentifierName(t));
                            break;
                        case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.STAR:
                            t = Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.STAR);
                            vars.Add(GetIdentifierName(t));
                            break;
                        default:
                            jj_la1[42] = jj_gen;
                            Jj_consume_token(-1);
                            throw new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException();
                    }
                }
                break_label_11 : {/*added by fwk*/}
            }
            if (fct) {
                {
                    if (true) return Net.Vpc.Upa.Impl.Uql.Parser.Syntax.FunctionFactory.CreateFunction(GetIdentifierName(start), parameters == null ? ((System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression>)(new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>())) : parameters);
                }
            } else if (indexer) {
                if (parameters == null) {
                    parameters = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>();
                }
                Net.Vpc.Upa.Expressions.Var v = new Net.Vpc.Upa.Expressions.IndexedVar(GetIdentifierName(start), parameters.ToArray());
                foreach (string s in vars) {
                    v = new Net.Vpc.Upa.Expressions.Var(v, s);
                }
                {
                    if (true) return v;
                }
            } else {
                Net.Vpc.Upa.Expressions.Var v = new Net.Vpc.Upa.Expressions.Var(GetIdentifierName(start));
                foreach (string s in vars) {
                    v = new Net.Vpc.Upa.Expressions.Var(v, s);
                }
                {
                    if (true) return v;
                }
            }
            throw new System.Exception("Missing return statement in function");
        }

        public Net.Vpc.Upa.Expressions.Expression PrimaryExpression() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            Net.Vpc.Upa.Expressions.Expression r;
            bool isMinus = false;
            bool isNot = false;
            bool isTilde = false;
            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LPAREN:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LPAREN);
                    if (Jj_2_11(2147483647)) {
                        r = Select();
                    } else {
                        switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IF:
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.TRUE:
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FALSE:
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.NULL:
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.NOT:
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.INTEGER_LITERAL:
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FLOATING_POINT_LITERAL:
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.CHARACTER_LITERAL:
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.STRING_LITERAL:
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER:
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LPAREN:
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.TILDE:
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.COLON:
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.PLUS:
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.MINUS:
                                r = Expression();
                                break;
                            default:
                                jj_la1[43] = jj_gen;
                                Jj_consume_token(-1);
                                throw new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException();
                        }
                    }
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.RPAREN);
                    break;
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.MINUS:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.MINUS);
                    isMinus = true;
                    r = PrimaryExpression();
                    break;
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.PLUS:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.PLUS);
                    r = Expression();
                    break;
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.NOT:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.NOT);
                    isNot = true;
                    r = PrimaryExpression();
                    break;
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.TILDE:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.TILDE);
                    isTilde = true;
                    r = PrimaryExpression();
                    break;
                default:
                    jj_la1[44] = jj_gen;
                    if (Jj_2_12(2147483647)) {
                        r = Param();
                    } else if (Jj_2_13(2147483647)) {
                        r = If();
                    } else if (Jj_2_14(2147483647)) {
                        r = Literal();
                    } else {
                        switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                            case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER:
                                r = VarOrFunction();
                                break;
                            default:
                                jj_la1[45] = jj_gen;
                                Jj_consume_token(-1);
                                throw new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException();
                        }
                    }
                    break;
            }
            if (isMinus) {
                r = new Net.Vpc.Upa.Expressions.Negative(r);
            }
            if (isNot) {
                r = new Net.Vpc.Upa.Expressions.Not(r);
            }
            if (isTilde) {
                r = new Net.Vpc.Upa.Expressions.Complement(r);
            }
            {
                if (true) return r;
            }
            throw new System.Exception("Missing return statement in function");
        }

        public Net.Vpc.Upa.Expressions.Literal Literal() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            Net.Vpc.Upa.Expressions.Literal r;
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token t;
            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.INTEGER_LITERAL:
                    t = Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.INTEGER_LITERAL);
                    r = new Net.Vpc.Upa.Expressions.Literal(System.Convert.ToInt32(t.image));
                    break;
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FLOATING_POINT_LITERAL:
                    t = Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FLOATING_POINT_LITERAL);
                    r = new Net.Vpc.Upa.Expressions.Literal(System.Convert.ToDouble(t.image));
                    break;
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.CHARACTER_LITERAL:
                    t = Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.CHARACTER_LITERAL);
                    r = new Net.Vpc.Upa.Expressions.Literal(GetStringLiteral(t));
                    break;
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.STRING_LITERAL:
                    t = Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.STRING_LITERAL);
                    r = new Net.Vpc.Upa.Expressions.Literal(GetStringLiteral(t));
                    break;
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.TRUE:
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FALSE:
                    r = BooleanLiteral();
                    break;
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.NULL:
                    r = NullLiteral();
                    break;
                default:
                    jj_la1[46] = jj_gen;
                    Jj_consume_token(-1);
                    throw new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException();
            }
            {
                if (true) return r;
            }
            throw new System.Exception("Missing return statement in function");
        }

        public Net.Vpc.Upa.Expressions.Literal BooleanLiteral() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.TRUE:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.TRUE);
                    {
                        if (true) return new Net.Vpc.Upa.Expressions.Literal(true);
                    }
                    break;
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FALSE:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FALSE);
                    {
                        if (true) return new Net.Vpc.Upa.Expressions.Literal(false);
                    }
                    break;
                default:
                    jj_la1[47] = jj_gen;
                    Jj_consume_token(-1);
                    throw new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException();
            }
            throw new System.Exception("Missing return statement in function");
        }

        public Net.Vpc.Upa.Expressions.Literal NullLiteral() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.NULL);
            {
                if (true) return new Net.Vpc.Upa.Expressions.Literal(null, null);
            }
            throw new System.Exception("Missing return statement in function");
        }

        public Net.Vpc.Upa.Expressions.Expression Switch() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            Net.Vpc.Upa.Expressions.Expression e;
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> expressions = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>();
            Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.SWITCH);
            e = Expression();
            expressions.Add(e);
            Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.CASE);
            e = Expression();
            expressions.Add(e);
            Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.THEN);
            e = Expression();
            expressions.Add(e);
            label_12: 
            while (true) {
                switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.CASE:
                        ;
                        break;
                    default:
                        jj_la1[48] = jj_gen;
                        goto break_label_12;
                }
                Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.CASE);
                e = Expression();
                expressions.Add(e);
                Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.THEN);
                e = Expression();
                expressions.Add(e);
            }
            break_label_12 : {/*added by fwk*/}
            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.ELSE:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.ELSE);
                    e = Expression();
                    expressions.Add(e);
                    break;
                default:
                    jj_la1[49] = jj_gen;
                    ;
                    break;
            }
            Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.END);
            {
                if (true) return new Net.Vpc.Upa.Expressions.Decode(expressions);
            }
            throw new System.Exception("Missing return statement in function");
        }

        public Net.Vpc.Upa.Expressions.Expression If() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            Net.Vpc.Upa.Expressions.Expression e;
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> expressions = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>();
            Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IF);
            e = Expression();
            expressions.Add(e);
            Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.THEN);
            e = Expression();
            expressions.Add(e);
            label_13: 
            while (true) {
                switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                    case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.ELSEIF:
                        ;
                        break;
                    default:
                        jj_la1[50] = jj_gen;
                        goto break_label_13;
                }
                Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.ELSEIF);
                e = Expression();
                expressions.Add(e);
                Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.THEN);
                e = Expression();
                expressions.Add(e);
            }
            break_label_13 : {/*added by fwk*/}
            switch((jj_ntk == -1) ? Jj_ntk() : jj_ntk) {
                case Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.ELSE:
                    Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.ELSE);
                    e = Expression();
                    expressions.Add(e);
                    break;
                default:
                    jj_la1[51] = jj_gen;
                    ;
                    break;
            }
            Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.END);
            {
                if (true) return new Net.Vpc.Upa.Expressions.If(expressions);
            }
            throw new System.Exception("Missing return statement in function");
        }

        public Net.Vpc.Upa.Expressions.Expression Function() /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token t;
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> parameters;
            t = Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER);
            Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LPAREN);
            parameters = ExpressionList();
            Jj_consume_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.RPAREN);
            {
                if (true) return Net.Vpc.Upa.Impl.Uql.Parser.Syntax.FunctionFactory.CreateFunction(GetIdentifierName(t), parameters);
            }
            throw new System.Exception("Missing return statement in function");
        }

        private bool Jj_2_1(int xla) {
            jj_la = xla;
            jj_lastpos = jj_scanpos = token;
            try {
                return !Jj_3_1();
            } catch (Net.Vpc.Upa.Impl.Uql.Parser.Syntax.LookaheadSuccess ls) {
                return true;
            } finally {
                Jj_save(0, xla);
            }
        }

        private bool Jj_2_2(int xla) {
            jj_la = xla;
            jj_lastpos = jj_scanpos = token;
            try {
                return !Jj_3_2();
            } catch (Net.Vpc.Upa.Impl.Uql.Parser.Syntax.LookaheadSuccess ls) {
                return true;
            } finally {
                Jj_save(1, xla);
            }
        }

        private bool Jj_2_3(int xla) {
            jj_la = xla;
            jj_lastpos = jj_scanpos = token;
            try {
                return !Jj_3_3();
            } catch (Net.Vpc.Upa.Impl.Uql.Parser.Syntax.LookaheadSuccess ls) {
                return true;
            } finally {
                Jj_save(2, xla);
            }
        }

        private bool Jj_2_4(int xla) {
            jj_la = xla;
            jj_lastpos = jj_scanpos = token;
            try {
                return !Jj_3_4();
            } catch (Net.Vpc.Upa.Impl.Uql.Parser.Syntax.LookaheadSuccess ls) {
                return true;
            } finally {
                Jj_save(3, xla);
            }
        }

        private bool Jj_2_5(int xla) {
            jj_la = xla;
            jj_lastpos = jj_scanpos = token;
            try {
                return !Jj_3_5();
            } catch (Net.Vpc.Upa.Impl.Uql.Parser.Syntax.LookaheadSuccess ls) {
                return true;
            } finally {
                Jj_save(4, xla);
            }
        }

        private bool Jj_2_6(int xla) {
            jj_la = xla;
            jj_lastpos = jj_scanpos = token;
            try {
                return !Jj_3_6();
            } catch (Net.Vpc.Upa.Impl.Uql.Parser.Syntax.LookaheadSuccess ls) {
                return true;
            } finally {
                Jj_save(5, xla);
            }
        }

        private bool Jj_2_7(int xla) {
            jj_la = xla;
            jj_lastpos = jj_scanpos = token;
            try {
                return !Jj_3_7();
            } catch (Net.Vpc.Upa.Impl.Uql.Parser.Syntax.LookaheadSuccess ls) {
                return true;
            } finally {
                Jj_save(6, xla);
            }
        }

        private bool Jj_2_8(int xla) {
            jj_la = xla;
            jj_lastpos = jj_scanpos = token;
            try {
                return !Jj_3_8();
            } catch (Net.Vpc.Upa.Impl.Uql.Parser.Syntax.LookaheadSuccess ls) {
                return true;
            } finally {
                Jj_save(7, xla);
            }
        }

        private bool Jj_2_9(int xla) {
            jj_la = xla;
            jj_lastpos = jj_scanpos = token;
            try {
                return !Jj_3_9();
            } catch (Net.Vpc.Upa.Impl.Uql.Parser.Syntax.LookaheadSuccess ls) {
                return true;
            } finally {
                Jj_save(8, xla);
            }
        }

        private bool Jj_2_10(int xla) {
            jj_la = xla;
            jj_lastpos = jj_scanpos = token;
            try {
                return !Jj_3_10();
            } catch (Net.Vpc.Upa.Impl.Uql.Parser.Syntax.LookaheadSuccess ls) {
                return true;
            } finally {
                Jj_save(9, xla);
            }
        }

        private bool Jj_2_11(int xla) {
            jj_la = xla;
            jj_lastpos = jj_scanpos = token;
            try {
                return !Jj_3_11();
            } catch (Net.Vpc.Upa.Impl.Uql.Parser.Syntax.LookaheadSuccess ls) {
                return true;
            } finally {
                Jj_save(10, xla);
            }
        }

        private bool Jj_2_12(int xla) {
            jj_la = xla;
            jj_lastpos = jj_scanpos = token;
            try {
                return !Jj_3_12();
            } catch (Net.Vpc.Upa.Impl.Uql.Parser.Syntax.LookaheadSuccess ls) {
                return true;
            } finally {
                Jj_save(11, xla);
            }
        }

        private bool Jj_2_13(int xla) {
            jj_la = xla;
            jj_lastpos = jj_scanpos = token;
            try {
                return !Jj_3_13();
            } catch (Net.Vpc.Upa.Impl.Uql.Parser.Syntax.LookaheadSuccess ls) {
                return true;
            } finally {
                Jj_save(12, xla);
            }
        }

        private bool Jj_2_14(int xla) {
            jj_la = xla;
            jj_lastpos = jj_scanpos = token;
            try {
                return !Jj_3_14();
            } catch (Net.Vpc.Upa.Impl.Uql.Parser.Syntax.LookaheadSuccess ls) {
                return true;
            } finally {
                Jj_save(13, xla);
            }
        }

        private bool Jj_3_5() {
            if (Jj_3R_14()) return true;
            return false;
        }

        private bool Jj_3R_18() {
            if (Jj_scan_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.CHARACTER_LITERAL)) return true;
            return false;
        }

        private bool Jj_3_4() {
            if (Jj_scan_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IDENTIFIER)) return true;
            return false;
        }

        private bool Jj_3_9() {
            if (Jj_scan_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LPAREN)) return true;
            return false;
        }

        private bool Jj_3R_17() {
            if (Jj_scan_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FLOATING_POINT_LITERAL)) return true;
            return false;
        }

        private bool Jj_3_8() {
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token xsp;
            xsp = jj_scanpos;
            if (Jj_scan_token(70)) {
                jj_scanpos = xsp;
                if (Jj_scan_token(63)) {
                    jj_scanpos = xsp;
                    if (Jj_scan_token(73)) {
                        jj_scanpos = xsp;
                        if (Jj_scan_token(74)) {
                            jj_scanpos = xsp;
                            if (Jj_scan_token(65)) {
                                jj_scanpos = xsp;
                                if (Jj_scan_token(71)) {
                                    jj_scanpos = xsp;
                                    if (Jj_scan_token(72)) {
                                        jj_scanpos = xsp;
                                        if (Jj_scan_token(64)) {
                                            jj_scanpos = xsp;
                                            if (Jj_scan_token(39)) return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool Jj_3R_16() {
            if (Jj_scan_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.INTEGER_LITERAL)) return true;
            return false;
        }

        private bool Jj_3R_15() {
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token xsp;
            xsp = jj_scanpos;
            if (Jj_3R_16()) {
                jj_scanpos = xsp;
                if (Jj_3R_17()) {
                    jj_scanpos = xsp;
                    if (Jj_3R_18()) {
                        jj_scanpos = xsp;
                        if (Jj_3R_19()) {
                            jj_scanpos = xsp;
                            if (Jj_3R_20()) {
                                jj_scanpos = xsp;
                                if (Jj_3R_21()) return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool Jj_3R_23() {
            if (Jj_scan_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.NULL)) return true;
            return false;
        }

        private bool Jj_3_14() {
            if (Jj_3R_15()) return true;
            return false;
        }

        private bool Jj_3_13() {
            if (Jj_scan_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IF)) return true;
            return false;
        }

        private bool Jj_3_3() {
            if (Jj_scan_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.DELETE)) return true;
            return false;
        }

        private bool Jj_3_12() {
            if (Jj_scan_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.COLON)) return true;
            return false;
        }

        private bool Jj_3R_25() {
            if (Jj_scan_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.FALSE)) return true;
            return false;
        }

        private bool Jj_3_6() {
            if (Jj_scan_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.SELECT)) return true;
            return false;
        }

        private bool Jj_3_2() {
            if (Jj_scan_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.UPDATE)) return true;
            return false;
        }

        private bool Jj_3_11() {
            if (Jj_scan_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.SELECT)) return true;
            return false;
        }

        private bool Jj_3R_24() {
            if (Jj_scan_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.TRUE)) return true;
            return false;
        }

        private bool Jj_3R_22() {
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token xsp;
            xsp = jj_scanpos;
            if (Jj_3R_24()) {
                jj_scanpos = xsp;
                if (Jj_3R_25()) return true;
            }
            return false;
        }

        private bool Jj_3_1() {
            if (Jj_scan_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.SELECT)) return true;
            return false;
        }

        private bool Jj_3R_21() {
            if (Jj_3R_23()) return true;
            return false;
        }

        private bool Jj_3_7() {
            if (Jj_scan_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.IN)) return true;
            return false;
        }

        private bool Jj_3R_20() {
            if (Jj_3R_22()) return true;
            return false;
        }

        private bool Jj_3_10() {
            if (Jj_scan_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.LBRACKET)) return true;
            return false;
        }

        private bool Jj_3R_14() {
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token xsp;
            xsp = jj_scanpos;
            if (Jj_scan_token(30)) {
                jj_scanpos = xsp;
                if (Jj_scan_token(31)) {
                    jj_scanpos = xsp;
                    if (Jj_scan_token(32)) {
                        jj_scanpos = xsp;
                        if (Jj_scan_token(33)) {
                            jj_scanpos = xsp;
                            if (Jj_scan_token(34)) return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool Jj_3R_19() {
            if (Jj_scan_token(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.STRING_LITERAL)) return true;
            return false;
        }

        /** Generated Token Manager. */
        public Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserTokenManager token_source;

        internal Net.Vpc.Upa.Impl.Uql.Parser.Syntax.SimpleCharStream jj_input_stream;

        /** Current token. */
        public Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token token;

        /** Next token. */
        public Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token jj_nt;

        private int jj_ntk;

        private Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token jj_scanpos;
        private Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token jj_lastpos;

        private int jj_la;

        private int jj_gen;

        private readonly int[] jj_la1 = new int[52];

        private static int[] jj_la1_0;

        private static int[] jj_la1_1;

        private static int[] jj_la1_2;

        static UQLParser(){
            Jj_la1_init_0();
            Jj_la1_init_1();
            Jj_la1_init_2();
        }

        private static void Jj_la1_init_0() {
            jj_la1_0 = new int[] { 0x1c08000, 0x0, 0x0, 0x0, 0x0, 0x800, unchecked((int)0xc0000000), 0x1000, 0x4000000, 0x0, 0x2000000, 0x1000, 0x1000, unchecked((int)0xc0000000), unchecked((int)0xc0000000), 0x0, 0x0, 0x0, 0x0, 0x0, 0x30000000, 0x30000000, 0x0, 0x0, 0x1c08000, 0x0, 0x4000, 0x4000, 0x2000, 0x2000, 0x1c08000, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x1c08000, 0x1c08000, 0x0, 0x0, 0x1c08000, 0x0, 0x0, 0x1c00000, 0xc00000, 0x40000, 0x80000, 0x100000, 0x80000 };
        }

        private static void Jj_la1_init_1() {
            jj_la1_1 = new int[] { 0x4e8840, 0x400, 0x200, 0x80000, 0x480000, 0x0, 0x7, 0x0, 0x0, 0x10, 0x0, 0x0, 0x0, 0x7, 0x7, 0x80000, 0x480000, 0x20, 0x20000000, 0x20000000, 0x0, 0x0, 0x40000000, 0x80000, 0x4e8840, 0x20000000, 0x0, 0x0, 0x0, 0x0, 0x4e8840, unchecked((int)0x80000080), unchecked((int)0x80000180), 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x4e8840, 0x4e8840, 0x40000000, 0x80000, 0x4e8840, 0x400040, 0x80000, 0x68800, 0x0, 0x0, 0x0, 0x0, 0x0 };
        }

        private static void Jj_la1_init_2() {
            jj_la1_2 = new int[] { 0x18028, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x38028, 0x0, 0x800, 0x800, 0x1000, 0x1000, 0x18028, 0x7c3, 0x7c3, 0x18000, 0x18000, 0x460000, 0x460000, 0x3b80000, 0x3b80000, 0x18028, 0x18028, 0x0, 0x20000, 0x18028, 0x18008, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };
        }

        private readonly Net.Vpc.Upa.Impl.Uql.Parser.Syntax.JJCalls[] jj_2_rtns = new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.JJCalls[14];

        private bool jj_rescan = false;

        private int jj_gc = 0;

        /** Constructor with InputStream. */
        public UQLParser(System.IO.Stream stream)  : this(stream, null){

        }

        /** Constructor with InputStream and supplied encoding */
        public UQLParser(System.IO.Stream stream, string encoding) {
            try {
                jj_input_stream = new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.SimpleCharStream(stream, encoding, 1, 1);
            } catch (System.Exception e) {
                throw new System.Exception("RuntimeException", e);
            }
            token_source = new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserTokenManager(jj_input_stream);
            token = new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token();
            jj_ntk = -1;
            jj_gen = 0;
            for (int i = 0; i < 52; i++) jj_la1[i] = -1;
            for (int i = 0; i < jj_2_rtns.Length; i++) jj_2_rtns[i] = new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.JJCalls();
        }

        /** Reinitialise. */
        public virtual void ReInit(System.IO.Stream stream) {
            ReInit(stream, null);
        }

        /** Reinitialise. */
        public virtual void ReInit(System.IO.Stream stream, string encoding) {
            try {
                jj_input_stream.ReInit(stream, encoding, 1, 1);
            } catch (System.Exception e) {
                throw new System.Exception("RuntimeException", e);
            }
            token_source.ReInit(jj_input_stream);
            token = new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token();
            jj_ntk = -1;
            jj_gen = 0;
            for (int i = 0; i < 52; i++) jj_la1[i] = -1;
            for (int i = 0; i < jj_2_rtns.Length; i++) jj_2_rtns[i] = new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.JJCalls();
        }

        /** Constructor. */
        public UQLParser(System.IO.TextReader stream) {
            jj_input_stream = new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.SimpleCharStream(stream, 1, 1);
            token_source = new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserTokenManager(jj_input_stream);
            token = new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token();
            jj_ntk = -1;
            jj_gen = 0;
            for (int i = 0; i < 52; i++) jj_la1[i] = -1;
            for (int i = 0; i < jj_2_rtns.Length; i++) jj_2_rtns[i] = new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.JJCalls();
        }

        /** Reinitialise. */
        public virtual void ReInit(System.IO.TextReader stream) {
            jj_input_stream.ReInit(stream, 1, 1);
            token_source.ReInit(jj_input_stream);
            token = new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token();
            jj_ntk = -1;
            jj_gen = 0;
            for (int i = 0; i < 52; i++) jj_la1[i] = -1;
            for (int i = 0; i < jj_2_rtns.Length; i++) jj_2_rtns[i] = new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.JJCalls();
        }

        /** Constructor with generated Token Manager. */
        public UQLParser(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserTokenManager tm) {
            token_source = tm;
            token = new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token();
            jj_ntk = -1;
            jj_gen = 0;
            for (int i = 0; i < 52; i++) jj_la1[i] = -1;
            for (int i = 0; i < jj_2_rtns.Length; i++) jj_2_rtns[i] = new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.JJCalls();
        }

        /** Reinitialise. */
        public virtual void ReInit(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserTokenManager tm) {
            token_source = tm;
            token = new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token();
            jj_ntk = -1;
            jj_gen = 0;
            for (int i = 0; i < 52; i++) jj_la1[i] = -1;
            for (int i = 0; i < jj_2_rtns.Length; i++) jj_2_rtns[i] = new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.JJCalls();
        }

        private Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token Jj_consume_token(int kind) /* throws Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException */  {
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token oldToken;
            if ((oldToken = token).next != null) token = token.next; else token = token.next = token_source.GetNextToken();
            jj_ntk = -1;
            if (token.kind == kind) {
                jj_gen++;
                if (++jj_gc > 100) {
                    jj_gc = 0;
                    for (int i = 0; i < jj_2_rtns.Length; i++) {
                        Net.Vpc.Upa.Impl.Uql.Parser.Syntax.JJCalls c = jj_2_rtns[i];
                        while (c != null) {
                            if (c.gen < jj_gen) c.first = null;
                            c = c.next;
                        }
                    }
                }
                return token;
            }
            token = oldToken;
            jj_kind = kind;
            throw GenerateParseException();
        }

        private readonly Net.Vpc.Upa.Impl.Uql.Parser.Syntax.LookaheadSuccess jj_ls = new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.LookaheadSuccess();

        private bool Jj_scan_token(int kind) {
            if (jj_scanpos == jj_lastpos) {
                jj_la--;
                if (jj_scanpos.next == null) {
                    jj_lastpos = jj_scanpos = jj_scanpos.next = token_source.GetNextToken();
                } else {
                    jj_lastpos = jj_scanpos = jj_scanpos.next;
                }
            } else {
                jj_scanpos = jj_scanpos.next;
            }
            if (jj_rescan) {
                int i = 0;
                Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token tok = token;
                while (tok != null && tok != jj_scanpos) {
                    i++;
                    tok = tok.next;
                }
                if (tok != null) Jj_add_error_token(kind, i);
            }
            if (jj_scanpos.kind != kind) return true;
            if (jj_la == 0 && jj_scanpos == jj_lastpos) throw jj_ls;
            return false;
        }

        /** Get the next Token. */
        public Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token GetNextToken() {
            if (token.next != null) token = token.next; else token = token.next = token_source.GetNextToken();
            jj_ntk = -1;
            jj_gen++;
            return token;
        }

        /** Get the specific Token. */
        public Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token GetToken(int index) {
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token t = token;
            for (int i = 0; i < index; i++) {
                if (t.next != null) t = t.next; else t = t.next = token_source.GetNextToken();
            }
            return t;
        }

        private int Jj_ntk() {
            if ((jj_nt = token.next) == null) return (jj_ntk = (token.next = token_source.GetNextToken()).kind); else return (jj_ntk = jj_nt.kind);
        }

        private System.Collections.Generic.IList<int[]> jj_expentries = new System.Collections.Generic.List<int[]>();

        private int[] jj_expentry;

        private int jj_kind = -1;

        private int[] jj_lasttokens = new int[100];

        private int jj_endpos;

        private void Jj_add_error_token(int kind, int pos) {
            if (pos >= 100) return;
            if (pos == jj_endpos + 1) {
                jj_lasttokens[jj_endpos++] = kind;
            } else if (jj_endpos != 0) {
                jj_expentry = new int[jj_endpos];
                for (int i = 0; i < jj_endpos; i++) {
                    jj_expentry[i] = jj_lasttokens[i];
                }
                jj_entries_loop: 
                for (System.Collections.Generic.IEnumerator<int[]> it = jj_expentries.GetEnumerator(); it.MoveNext(); ) {
                    int[] oldentry = (int[]) ((it).Current);
                    if (oldentry.Length == jj_expentry.Length) {
                        for (int i = 0; i < jj_expentry.Length; i++) {
                            if (oldentry[i] != jj_expentry[i]) {
                                goto  continue_jj_entries_loop;
                            }
                        }
                        jj_expentries.Add(jj_expentry);
                        goto break_jj_entries_loop;
                    }
                    continue_jj_entries_loop : {/*added by fwk*/}
                }
                break_jj_entries_loop : {/*added by fwk*/}
                if (pos != 0) jj_lasttokens[(jj_endpos = pos) - 1] = kind;
            }
        }

        /** Generate ParseException. */
        public virtual Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException GenerateParseException() {
            jj_expentries.Clear();
            bool[] la1tokens = new bool[90];
            if (jj_kind >= 0) {
                la1tokens[jj_kind] = true;
                jj_kind = -1;
            }
            for (int i = 0; i < 52; i++) {
                if (jj_la1[i] == jj_gen) {
                    for (int j = 0; j < 32; j++) {
                        if ((jj_la1_0[i] & (1 << j)) != 0) {
                            la1tokens[j] = true;
                        }
                        if ((jj_la1_1[i] & (1 << j)) != 0) {
                            la1tokens[32 + j] = true;
                        }
                        if ((jj_la1_2[i] & (1 << j)) != 0) {
                            la1tokens[64 + j] = true;
                        }
                    }
                }
            }
            for (int i = 0; i < 90; i++) {
                if (la1tokens[i]) {
                    jj_expentry = new int[1];
                    jj_expentry[0] = i;
                    jj_expentries.Add(jj_expentry);
                }
            }
            jj_endpos = 0;
            Jj_rescan_token();
            Jj_add_error_token(0, 0);
            int[][] exptokseq = new int[(jj_expentries).Count][];
            for (int i = 0; i < (jj_expentries).Count; i++) {
                exptokseq[i] = jj_expentries[i];
            }
            return new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException(token, exptokseq, Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstantsIHelper.tokenImage);
        }

        /** Enable tracing. */
        public void Enable_tracing() {
        }

        /** Disable tracing. */
        public void Disable_tracing() {
        }

        private void Jj_rescan_token() {
            jj_rescan = true;
            for (int i = 0; i < 14; i++) {
                try {
                    Net.Vpc.Upa.Impl.Uql.Parser.Syntax.JJCalls p = jj_2_rtns[i];
                    do {
                        if (p.gen > jj_gen) {
                            jj_la = p.arg;
                            jj_lastpos = jj_scanpos = p.first;
                            switch(i) {
                                case 0:
                                    Jj_3_1();
                                    break;
                                case 1:
                                    Jj_3_2();
                                    break;
                                case 2:
                                    Jj_3_3();
                                    break;
                                case 3:
                                    Jj_3_4();
                                    break;
                                case 4:
                                    Jj_3_5();
                                    break;
                                case 5:
                                    Jj_3_6();
                                    break;
                                case 6:
                                    Jj_3_7();
                                    break;
                                case 7:
                                    Jj_3_8();
                                    break;
                                case 8:
                                    Jj_3_9();
                                    break;
                                case 9:
                                    Jj_3_10();
                                    break;
                                case 10:
                                    Jj_3_11();
                                    break;
                                case 11:
                                    Jj_3_12();
                                    break;
                                case 12:
                                    Jj_3_13();
                                    break;
                                case 13:
                                    Jj_3_14();
                                    break;
                            }
                        }
                        p = p.next;
                    } while (p != null);
                } catch (Net.Vpc.Upa.Impl.Uql.Parser.Syntax.LookaheadSuccess ls) {
                }
            }
            jj_rescan = false;
        }

        private void Jj_save(int index, int xla) {
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.JJCalls p = jj_2_rtns[index];
            while (p.gen > jj_gen) {
                if (p.next == null) {
                    p = p.next = new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.JJCalls();
                    break;
                }
                p = p.next;
            }
            p.gen = jj_gen + xla - jj_la;
            p.first = token;
            p.arg = xla;
        }
    }
}
