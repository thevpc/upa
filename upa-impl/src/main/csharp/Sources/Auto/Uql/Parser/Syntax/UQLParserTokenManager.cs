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



namespace Net.Vpc.Upa.Impl.Uql.Parser.Syntax
{


    /** Token Manager. */
    public class UQLParserTokenManager : Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParserConstants {

        /** Debug output. */
        public System.IO.TextWriter debugStream = System.Console.Out;

        /** Set debug output. */
        public virtual void SetDebugStream(System.IO.TextWriter ds) {
            debugStream = ds;
        }

        private int JjStopStringLiteralDfa_0(int pos, long active0, long active1) {
            switch(pos) {
                case 0:
                    if ((active0 & 0x4000000000000000L) != 0L) return 4;
                    if ((active0 & 0x7ffffffffc0L) != 0L) {
                        jjmatchedKind = 51;
                        return 37;
                    }
                    return -1;
                case 1:
                    if ((active0 & 0x1204a00c200L) != 0L) return 37;
                    if ((active0 & 0x6dfb5ff3dc0L) != 0L) {
                        if (jjmatchedPos != 1) {
                            jjmatchedKind = 51;
                            jjmatchedPos = 1;
                        }
                        return 37;
                    }
                    return -1;
                case 2:
                    if ((active0 & 0x44020202400L) != 0L) return 37;
                    if ((active0 & 0x29fd7df1bc0L) != 0L) {
                        jjmatchedKind = 51;
                        jjmatchedPos = 2;
                        return 37;
                    }
                    return -1;
                case 3:
                    if ((active0 & 0x215468213c0L) != 0L) {
                        if (jjmatchedPos != 3) {
                            jjmatchedKind = 51;
                            jjmatchedPos = 3;
                        }
                        return 37;
                    }
                    if ((active0 & 0x8a915d0800L) != 0L) return 37;
                    return -1;
                case 4:
                    if ((active0 & 0x210001203c0L) != 0L) {
                        jjmatchedKind = 51;
                        jjmatchedPos = 4;
                        return 37;
                    }
                    if ((active0 & 0x546801000L) != 0L) return 37;
                    return -1;
                case 5:
                    if ((active0 & 0x10001203c0L) != 0L) return 37;
                    if ((active0 & 0x20000000000L) != 0L) {
                        jjmatchedKind = 51;
                        jjmatchedPos = 5;
                        return 37;
                    }
                    return -1;
                case 6:
                    if ((active0 & 0x20000000000L) != 0L) {
                        jjmatchedKind = 51;
                        jjmatchedPos = 6;
                        return 37;
                    }
                    return -1;
                default:
                    return -1;
            }
        }

        private int JjStartNfa_0(int pos, long active0, long active1) {
            return JjMoveNfa_0(JjStopStringLiteralDfa_0(pos, active0, active1), pos + 1);
        }

        private int JjStopAtPos(int pos, int kind) {
            jjmatchedKind = kind;
            jjmatchedPos = pos;
            return pos + 1;
        }

        private int JjMoveStringLiteralDfa0_0() {
            switch(curChar) {
                case (char)33:
                    jjmatchedKind = 66;
                    return JjMoveStringLiteralDfa1_0(0x0L, 0x200L);
                case (char)37:
                    return JjStopAtPos(0, 86);
                case (char)38:
                    jjmatchedKind = 83;
                    return JjMoveStringLiteralDfa1_0(0x0L, 0x1000L);
                case (char)40:
                    return JjStopAtPos(0, 54);
                case (char)41:
                    return JjStopAtPos(0, 55);
                case (char)42:
                    return JjStopAtPos(0, 81);
                case (char)43:
                    jjmatchedKind = 79;
                    return JjMoveStringLiteralDfa1_0(0x0L, 0x2000L);
                case (char)44:
                    return JjStopAtPos(0, 61);
                case (char)45:
                    jjmatchedKind = 80;
                    return JjMoveStringLiteralDfa1_0(0x0L, 0x4000L);
                case (char)46:
                    return JjStartNfaWithStates_0(0, 62, 4);
                case (char)47:
                    return JjStopAtPos(0, 82);
                case (char)58:
                    return JjStopAtPos(0, 69);
                case (char)59:
                    return JjStopAtPos(0, 60);
                case (char)60:
                    jjmatchedKind = 65;
                    return JjMoveStringLiteralDfa1_0(0x0L, 0x800480L);
                case (char)61:
                    jjmatchedKind = 63;
                    return JjMoveStringLiteralDfa1_0(0x0L, 0x40L);
                case (char)62:
                    jjmatchedKind = 64;
                    return JjMoveStringLiteralDfa1_0(0x0L, 0x3000100L);
                case (char)63:
                    return JjStopAtPos(0, 68);
                case (char)91:
                    return JjStopAtPos(0, 58);
                case (char)93:
                    return JjStopAtPos(0, 59);
                case (char)94:
                    return JjStopAtPos(0, 85);
                case (char)65:
                case (char)97:
                    return JjMoveStringLiteralDfa1_0(0x20002000L, 0x0L);
                case (char)66:
                case (char)98:
                    return JjMoveStringLiteralDfa1_0(0x8000000L, 0x0L);
                case (char)67:
                case (char)99:
                    return JjMoveStringLiteralDfa1_0(0x400040000L, 0x0L);
                case (char)68:
                case (char)100:
                    return JjMoveStringLiteralDfa1_0(0x20010000100L, 0x0L);
                case (char)69:
                case (char)101:
                    return JjMoveStringLiteralDfa1_0(0x380000L, 0x0L);
                case (char)70:
                case (char)102:
                    return JjMoveStringLiteralDfa1_0(0x200800800L, 0x0L);
                case (char)71:
                case (char)103:
                    return JjMoveStringLiteralDfa1_0(0x4000000L, 0x0L);
                case (char)72:
                case (char)104:
                    return JjMoveStringLiteralDfa1_0(0x1000000000L, 0x0L);
                case (char)73:
                case (char)105:
                    return JjMoveStringLiteralDfa1_0(0x10040008200L, 0x0L);
                case (char)74:
                case (char)106:
                    return JjMoveStringLiteralDfa1_0(0x800000000L, 0x0L);
                case (char)76:
                case (char)108:
                    return JjMoveStringLiteralDfa1_0(0x8080000000L, 0x0L);
                case (char)78:
                case (char)110:
                    return JjMoveStringLiteralDfa1_0(0x4001000000L, 0x0L);
                case (char)79:
                case (char)111:
                    return JjMoveStringLiteralDfa1_0(0x2002004000L, 0x0L);
                case (char)82:
                case (char)114:
                    return JjMoveStringLiteralDfa1_0(0x100000000L, 0x0L);
                case (char)83:
                case (char)115:
                    return JjMoveStringLiteralDfa1_0(0x20440L, 0x0L);
                case (char)84:
                case (char)116:
                    return JjMoveStringLiteralDfa1_0(0x40000410000L, 0x0L);
                case (char)85:
                case (char)117:
                    return JjMoveStringLiteralDfa1_0(0x80L, 0x0L);
                case (char)87:
                case (char)119:
                    return JjMoveStringLiteralDfa1_0(0x1000L, 0x0L);
                case (char)123:
                    return JjStopAtPos(0, 56);
                case (char)124:
                    jjmatchedKind = 84;
                    return JjMoveStringLiteralDfa1_0(0x0L, 0x800L);
                case (char)125:
                    return JjStopAtPos(0, 57);
                case (char)126:
                    return JjStopAtPos(0, 67);
                default:
                    return JjMoveNfa_0(0, 0);
            }
        }

        private int JjMoveStringLiteralDfa1_0(long active0, long active1) {
            try {
                curChar = input_stream.ReadChar();
            } catch (System.IO.IOException e) {
                JjStopStringLiteralDfa_0(0, active0, active1);
                return 1;
            }
            switch(curChar) {
                case (char)38:
                    if ((active1 & 0x1000L) != 0L) return JjStopAtPos(1, 76);
                    break;
                case (char)43:
                    if ((active1 & 0x2000L) != 0L) return JjStopAtPos(1, 77);
                    break;
                case (char)45:
                    if ((active1 & 0x4000L) != 0L) return JjStopAtPos(1, 78);
                    break;
                case (char)60:
                    if ((active1 & 0x800000L) != 0L) return JjStopAtPos(1, 87);
                    break;
                case (char)61:
                    if ((active1 & 0x40L) != 0L) return JjStopAtPos(1, 70); else if ((active1 & 0x80L) != 0L) return JjStopAtPos(1, 71); else if ((active1 & 0x100L) != 0L) return JjStopAtPos(1, 72); else if ((active1 & 0x200L) != 0L) return JjStopAtPos(1, 73);
                    break;
                case (char)62:
                    if ((active1 & 0x400L) != 0L) return JjStopAtPos(1, 74); else if ((active1 & 0x1000000L) != 0L) {
                        jjmatchedKind = 88;
                        jjmatchedPos = 1;
                    }
                    return JjMoveStringLiteralDfa2_0(active0, 0L, active1, 0x2000000L);
                case (char)65:
                case (char)97:
                    return JjMoveStringLiteralDfa2_0(active0, 0x1000840000L, active1, 0L);
                case (char)69:
                case (char)101:
                    return JjMoveStringLiteralDfa2_0(active0, 0x90000540L, active1, 0L);
                case (char)70:
                case (char)102:
                    if ((active0 & 0x8000L) != 0L) return JjStartNfaWithStates_0(1, 15, 37);
                    break;
                case (char)72:
                case (char)104:
                    return JjMoveStringLiteralDfa2_0(active0, 0x11000L, active1, 0L);
                case (char)73:
                case (char)105:
                    return JjMoveStringLiteralDfa2_0(active0, 0x28100000000L, active1, 0L);
                case (char)76:
                case (char)108:
                    return JjMoveStringLiteralDfa2_0(active0, 0x180000L, active1, 0L);
                case (char)78:
                case (char)110:
                    if ((active0 & 0x2000000000L) != 0L) return JjStartNfaWithStates_0(1, 37, 37); else if ((active0 & 0x10000000000L) != 0L) {
                        jjmatchedKind = 40;
                        jjmatchedPos = 1;
                    }
                    return JjMoveStringLiteralDfa2_0(active0, 0x40202200L, active1, 0L);
                case (char)79:
                case (char)111:
                    return JjMoveStringLiteralDfa2_0(active0, 0x44800000000L, active1, 0L);
                case (char)80:
                case (char)112:
                    return JjMoveStringLiteralDfa2_0(active0, 0x80L, active1, 0L);
                case (char)82:
                case (char)114:
                    if ((active0 & 0x4000L) != 0L) {
                        jjmatchedKind = 14;
                        jjmatchedPos = 1;
                    }
                    return JjMoveStringLiteralDfa2_0(active0, 0x406400800L, active1, 0L);
                case (char)83:
                case (char)115:
                    return JjMoveStringLiteralDfa2_0(active0, 0x20000000L, active1, 0L);
                case (char)85:
                case (char)117:
                    return JjMoveStringLiteralDfa2_0(active0, 0x201000000L, active1, 0L);
                case (char)87:
                case (char)119:
                    return JjMoveStringLiteralDfa2_0(active0, 0x20000L, active1, 0L);
                case (char)89:
                case (char)121:
                    if ((active0 & 0x8000000L) != 0L) return JjStartNfaWithStates_0(1, 27, 37);
                    break;
                case (char)124:
                    if ((active1 & 0x800L) != 0L) return JjStopAtPos(1, 75);
                    break;
                default:
                    break;
            }
            return JjStartNfa_0(0, active0, active1);
        }

        private int JjMoveStringLiteralDfa2_0(long old0, long active0, long old1, long active1) {
            if (((active0 &= old0) | (active1 &= old1)) == 0L) return JjStartNfa_0(0, old0, old1);
            try {
                curChar = input_stream.ReadChar();
            } catch (System.IO.IOException e) {
                JjStopStringLiteralDfa_0(1, active0, active1);
                return 2;
            }
            switch(curChar) {
                case (char)62:
                    if ((active1 & 0x2000000L) != 0L) return JjStopAtPos(2, 89);
                    break;
                case (char)67:
                case (char)99:
                    if ((active0 & 0x20000000L) != 0L) return JjStartNfaWithStates_0(2, 29, 37);
                    break;
                case (char)68:
                case (char)100:
                    if ((active0 & 0x2000L) != 0L) return JjStartNfaWithStates_0(2, 13, 37); else if ((active0 & 0x200000L) != 0L) return JjStartNfaWithStates_0(2, 21, 37);
                    return JjMoveStringLiteralDfa3_0(active0, 0x2000080L, active1, 0L);
                case (char)69:
                case (char)101:
                    return JjMoveStringLiteralDfa3_0(active0, 0x11000L, active1, 0L);
                case (char)70:
                case (char)102:
                    return JjMoveStringLiteralDfa3_0(active0, 0x80000000L, active1, 0L);
                case (char)71:
                case (char)103:
                    return JjMoveStringLiteralDfa3_0(active0, 0x100000000L, active1, 0L);
                case (char)73:
                case (char)105:
                    return JjMoveStringLiteralDfa3_0(active0, 0x800020000L, active1, 0L);
                case (char)75:
                case (char)107:
                    return JjMoveStringLiteralDfa3_0(active0, 0x8000000000L, active1, 0L);
                case (char)76:
                case (char)108:
                    return JjMoveStringLiteralDfa3_0(active0, 0x201800140L, active1, 0L);
                case (char)78:
                case (char)110:
                    return JjMoveStringLiteralDfa3_0(active0, 0x40000000L, active1, 0L);
                case (char)79:
                case (char)111:
                    return JjMoveStringLiteralDfa3_0(active0, 0x404000800L, active1, 0L);
                case (char)80:
                case (char)112:
                    if ((active0 & 0x40000000000L) != 0L) return JjStartNfaWithStates_0(2, 42, 37);
                    break;
                case (char)83:
                case (char)115:
                    return JjMoveStringLiteralDfa3_0(active0, 0x200101c0200L, active1, 0L);
                case (char)84:
                case (char)116:
                    if ((active0 & 0x400L) != 0L) return JjStartNfaWithStates_0(2, 10, 37); else if ((active0 & 0x4000000000L) != 0L) return JjStartNfaWithStates_0(2, 38, 37);
                    break;
                case (char)85:
                case (char)117:
                    return JjMoveStringLiteralDfa3_0(active0, 0x400000L, active1, 0L);
                case (char)86:
                case (char)118:
                    return JjMoveStringLiteralDfa3_0(active0, 0x1000000000L, active1, 0L);
                default:
                    break;
            }
            return JjStartNfa_0(1, active0, active1);
        }

        private int JjMoveStringLiteralDfa3_0(long old0, long active0, long old1, long active1) {
            if (((active0 &= old0) | (active1 &= old1)) == 0L) return JjStartNfa_0(1, old0, old1);
            try {
                curChar = input_stream.ReadChar();
            } catch (System.IO.IOException e) {
                JjStopStringLiteralDfa_0(2, active0, 0L);
                return 3;
            }
            switch(curChar) {
                case (char)65:
                case (char)97:
                    return JjMoveStringLiteralDfa4_0(active0, 0x80L);
                case (char)67:
                case (char)99:
                    if ((active0 & 0x10000000L) != 0L) return JjStartNfaWithStates_0(3, 28, 37);
                    break;
                case (char)69:
                case (char)101:
                    if ((active0 & 0x40000L) != 0L) return JjStartNfaWithStates_0(3, 18, 37); else if ((active0 & 0x80000L) != 0L) {
                        jjmatchedKind = 19;
                        jjmatchedPos = 3;
                    } else if ((active0 & 0x400000L) != 0L) return JjStartNfaWithStates_0(3, 22, 37); else if ((active0 & 0x8000000000L) != 0L) return JjStartNfaWithStates_0(3, 39, 37);
                    return JjMoveStringLiteralDfa4_0(active0, 0x42100340L);
                case (char)72:
                case (char)104:
                    return JjMoveStringLiteralDfa4_0(active0, 0x100000000L);
                case (char)73:
                case (char)105:
                    return JjMoveStringLiteralDfa4_0(active0, 0x1000000000L);
                case (char)76:
                case (char)108:
                    if ((active0 & 0x1000000L) != 0L) return JjStartNfaWithStates_0(3, 24, 37); else if ((active0 & 0x200000000L) != 0L) return JjStartNfaWithStates_0(3, 33, 37);
                    break;
                case (char)77:
                case (char)109:
                    if ((active0 & 0x800L) != 0L) return JjStartNfaWithStates_0(3, 11, 37);
                    break;
                case (char)78:
                case (char)110:
                    if ((active0 & 0x10000L) != 0L) return JjStartNfaWithStates_0(3, 16, 37); else if ((active0 & 0x800000000L) != 0L) return JjStartNfaWithStates_0(3, 35, 37);
                    break;
                case (char)82:
                case (char)114:
                    return JjMoveStringLiteralDfa4_0(active0, 0x1000L);
                case (char)83:
                case (char)115:
                    return JjMoveStringLiteralDfa4_0(active0, 0x400800000L);
                case (char)84:
                case (char)116:
                    if ((active0 & 0x80000000L) != 0L) return JjStartNfaWithStates_0(3, 31, 37);
                    return JjMoveStringLiteralDfa4_0(active0, 0x20000020000L);
                case (char)85:
                case (char)117:
                    return JjMoveStringLiteralDfa4_0(active0, 0x4000000L);
                default:
                    break;
            }
            return JjStartNfa_0(2, active0, 0L);
        }

        private int JjMoveStringLiteralDfa4_0(long old0, long active0) {
            if (((active0 &= old0)) == 0L) return JjStartNfa_0(2, old0, 0L);
            try {
                curChar = input_stream.ReadChar();
            } catch (System.IO.IOException e) {
                JjStopStringLiteralDfa_0(3, active0, 0L);
                return 4;
            }
            switch(curChar) {
                case (char)67:
                case (char)99:
                    return JjMoveStringLiteralDfa5_0(active0, 0x20040L);
                case (char)69:
                case (char)101:
                    if ((active0 & 0x1000L) != 0L) return JjStartNfaWithStates_0(4, 12, 37); else if ((active0 & 0x800000L) != 0L) return JjStartNfaWithStates_0(4, 23, 37);
                    break;
                case (char)73:
                case (char)105:
                    return JjMoveStringLiteralDfa5_0(active0, 0x20000100000L);
                case (char)78:
                case (char)110:
                    return JjMoveStringLiteralDfa5_0(active0, 0x1000000000L);
                case (char)80:
                case (char)112:
                    if ((active0 & 0x4000000L) != 0L) return JjStartNfaWithStates_0(4, 26, 37);
                    break;
                case (char)82:
                case (char)114:
                    if ((active0 & 0x2000000L) != 0L) return JjStartNfaWithStates_0(4, 25, 37); else if ((active0 & 0x40000000L) != 0L) return JjStartNfaWithStates_0(4, 30, 37);
                    return JjMoveStringLiteralDfa5_0(active0, 0x200L);
                case (char)83:
                case (char)115:
                    if ((active0 & 0x400000000L) != 0L) return JjStartNfaWithStates_0(4, 34, 37);
                    break;
                case (char)84:
                case (char)116:
                    if ((active0 & 0x100000000L) != 0L) return JjStartNfaWithStates_0(4, 32, 37);
                    return JjMoveStringLiteralDfa5_0(active0, 0x180L);
                default:
                    break;
            }
            return JjStartNfa_0(3, active0, 0L);
        }

        private int JjMoveStringLiteralDfa5_0(long old0, long active0) {
            if (((active0 &= old0)) == 0L) return JjStartNfa_0(3, old0, 0L);
            try {
                curChar = input_stream.ReadChar();
            } catch (System.IO.IOException e) {
                JjStopStringLiteralDfa_0(4, active0, 0L);
                return 5;
            }
            switch(curChar) {
                case (char)69:
                case (char)101:
                    if ((active0 & 0x80L) != 0L) return JjStartNfaWithStates_0(5, 7, 37); else if ((active0 & 0x100L) != 0L) return JjStartNfaWithStates_0(5, 8, 37);
                    break;
                case (char)70:
                case (char)102:
                    if ((active0 & 0x100000L) != 0L) return JjStartNfaWithStates_0(5, 20, 37);
                    break;
                case (char)71:
                case (char)103:
                    if ((active0 & 0x1000000000L) != 0L) return JjStartNfaWithStates_0(5, 36, 37);
                    break;
                case (char)72:
                case (char)104:
                    if ((active0 & 0x20000L) != 0L) return JjStartNfaWithStates_0(5, 17, 37);
                    break;
                case (char)78:
                case (char)110:
                    return JjMoveStringLiteralDfa6_0(active0, 0x20000000000L);
                case (char)84:
                case (char)116:
                    if ((active0 & 0x40L) != 0L) return JjStartNfaWithStates_0(5, 6, 37); else if ((active0 & 0x200L) != 0L) return JjStartNfaWithStates_0(5, 9, 37);
                    break;
                default:
                    break;
            }
            return JjStartNfa_0(4, active0, 0L);
        }

        private int JjMoveStringLiteralDfa6_0(long old0, long active0) {
            if (((active0 &= old0)) == 0L) return JjStartNfa_0(4, old0, 0L);
            try {
                curChar = input_stream.ReadChar();
            } catch (System.IO.IOException e) {
                JjStopStringLiteralDfa_0(5, active0, 0L);
                return 6;
            }
            switch(curChar) {
                case (char)67:
                case (char)99:
                    return JjMoveStringLiteralDfa7_0(active0, 0x20000000000L);
                default:
                    break;
            }
            return JjStartNfa_0(5, active0, 0L);
        }

        private int JjMoveStringLiteralDfa7_0(long old0, long active0) {
            if (((active0 &= old0)) == 0L) return JjStartNfa_0(5, old0, 0L);
            try {
                curChar = input_stream.ReadChar();
            } catch (System.IO.IOException e) {
                JjStopStringLiteralDfa_0(6, active0, 0L);
                return 7;
            }
            switch(curChar) {
                case (char)84:
                case (char)116:
                    if ((active0 & 0x20000000000L) != 0L) return JjStartNfaWithStates_0(7, 41, 37);
                    break;
                default:
                    break;
            }
            return JjStartNfa_0(6, active0, 0L);
        }

        private int JjStartNfaWithStates_0(int pos, int kind, int state) {
            jjmatchedKind = kind;
            jjmatchedPos = pos;
            try {
                curChar = input_stream.ReadChar();
            } catch (System.IO.IOException e) {
                return pos + 1;
            }
            return JjMoveNfa_0(state, pos + 1);
        }

        internal static readonly long[] jjbitVec0 = { 0x0L, 0x0L, unchecked((long)0xffffffffffffffffL), unchecked((long)0xffffffffffffffffL) };

        private int JjMoveNfa_0(int startState, int curPos) {
            int startsAt = 0;
            jjnewStateCnt = 57;
            int i = 1;
            jjstateSet[0] = startState;
            int kind = 0x7fffffff;
            for (; ; ) {
                if (++jjround == 0x7fffffff) ReInitRounds();
                if (curChar < 64) {
                    long l = 1L << curChar;
                    do {
                        switch(jjstateSet[--i]) {
                            case 0:
                                if ((0x3ff000000000000L & l) != 0L) JjCheckNAddStates(0, 6); else if (curChar == 36) {
                                    if (kind > 51) kind = 51;
                                    JjCheckNAdd(37);
                                } else if (curChar == 34) JjCheckNAddStates(7, 9); else if (curChar == 39) JjCheckNAddStates(10, 12); else if (curChar == 46) JjCheckNAdd(4);
                                if ((0x3fe000000000000L & l) != 0L) {
                                    if (kind > 43) kind = 43;
                                    JjCheckNAddTwoStates(1, 2);
                                } else if (curChar == 48) {
                                    if (kind > 43) kind = 43;
                                    JjCheckNAddStates(13, 15);
                                }
                                break;
                            case 1:
                                if ((0x3ff000000000000L & l) == 0L) break;
                                if (kind > 43) kind = 43;
                                JjCheckNAddTwoStates(1, 2);
                                break;
                            case 3:
                                if (curChar == 46) JjCheckNAdd(4);
                                break;
                            case 4:
                                if ((0x3ff000000000000L & l) == 0L) break;
                                if (kind > 47) kind = 47;
                                JjCheckNAddStates(16, 18);
                                break;
                            case 6:
                                if ((0x280000000000L & l) != 0L) JjCheckNAdd(7);
                                break;
                            case 7:
                                if ((0x3ff000000000000L & l) == 0L) break;
                                if (kind > 47) kind = 47;
                                JjCheckNAddTwoStates(7, 8);
                                break;
                            case 9:
                                if (curChar == 39) JjCheckNAddStates(10, 12);
                                break;
                            case 10:
                                if ((unchecked((long)0xffffff7fffffdbffL) & l) != 0L) JjCheckNAddStates(10, 12);
                                break;
                            case 12:
                                if ((0x8400000000L & l) != 0L) JjCheckNAddStates(10, 12);
                                break;
                            case 13:
                                if (curChar == 39 && kind > 49) kind = 49;
                                break;
                            case 14:
                                if ((0xff000000000000L & l) != 0L) JjCheckNAddStates(19, 22);
                                break;
                            case 15:
                                if ((0xff000000000000L & l) != 0L) JjCheckNAddStates(10, 12);
                                break;
                            case 16:
                                if ((0xf000000000000L & l) != 0L) jjstateSet[jjnewStateCnt++] = 17;
                                break;
                            case 17:
                                if ((0xff000000000000L & l) != 0L) JjCheckNAdd(15);
                                break;
                            case 18:
                                if (curChar == 34) JjCheckNAddStates(7, 9);
                                break;
                            case 19:
                                if ((unchecked((long)0xfffffffbffffdbffL) & l) != 0L) JjCheckNAddStates(7, 9);
                                break;
                            case 21:
                                if ((0x8400000000L & l) != 0L) JjCheckNAddStates(7, 9);
                                break;
                            case 22:
                                if (curChar == 34 && kind > 50) kind = 50;
                                break;
                            case 23:
                                if ((0xff000000000000L & l) != 0L) JjCheckNAddStates(23, 26);
                                break;
                            case 24:
                                if ((0xff000000000000L & l) != 0L) JjCheckNAddStates(7, 9);
                                break;
                            case 25:
                                if ((0xf000000000000L & l) != 0L) jjstateSet[jjnewStateCnt++] = 26;
                                break;
                            case 26:
                                if ((0xff000000000000L & l) != 0L) JjCheckNAdd(24);
                                break;
                            case 28:
                                if ((unchecked((long)0xffffffffffffdbffL) & l) != 0L) JjCheckNAddStates(27, 29);
                                break;
                            case 30:
                                if ((0x8400000000L & l) != 0L) JjCheckNAddStates(27, 29);
                                break;
                            case 32:
                                if ((0xff000000000000L & l) != 0L) JjCheckNAddStates(30, 33);
                                break;
                            case 33:
                                if ((0xff000000000000L & l) != 0L) JjCheckNAddStates(27, 29);
                                break;
                            case 34:
                                if ((0xf000000000000L & l) != 0L) jjstateSet[jjnewStateCnt++] = 35;
                                break;
                            case 35:
                                if ((0xff000000000000L & l) != 0L) JjCheckNAdd(33);
                                break;
                            case 36:
                                if (curChar != 36) break;
                                if (kind > 51) kind = 51;
                                JjCheckNAdd(37);
                                break;
                            case 37:
                                if ((0x3ff000000000000L & l) == 0L) break;
                                if (kind > 51) kind = 51;
                                JjCheckNAdd(37);
                                break;
                            case 38:
                                if ((0x3ff000000000000L & l) != 0L) JjCheckNAddStates(0, 6);
                                break;
                            case 39:
                                if ((0x3ff000000000000L & l) != 0L) JjCheckNAddTwoStates(39, 40);
                                break;
                            case 40:
                                if (curChar != 46) break;
                                if (kind > 47) kind = 47;
                                JjCheckNAddStates(34, 36);
                                break;
                            case 41:
                                if ((0x3ff000000000000L & l) == 0L) break;
                                if (kind > 47) kind = 47;
                                JjCheckNAddStates(34, 36);
                                break;
                            case 43:
                                if ((0x280000000000L & l) != 0L) JjCheckNAdd(44);
                                break;
                            case 44:
                                if ((0x3ff000000000000L & l) == 0L) break;
                                if (kind > 47) kind = 47;
                                JjCheckNAddTwoStates(44, 8);
                                break;
                            case 45:
                                if ((0x3ff000000000000L & l) != 0L) JjCheckNAddTwoStates(45, 46);
                                break;
                            case 47:
                                if ((0x280000000000L & l) != 0L) JjCheckNAdd(48);
                                break;
                            case 48:
                                if ((0x3ff000000000000L & l) == 0L) break;
                                if (kind > 47) kind = 47;
                                JjCheckNAddTwoStates(48, 8);
                                break;
                            case 49:
                                if ((0x3ff000000000000L & l) != 0L) JjCheckNAddStates(37, 39);
                                break;
                            case 51:
                                if ((0x280000000000L & l) != 0L) JjCheckNAdd(52);
                                break;
                            case 52:
                                if ((0x3ff000000000000L & l) != 0L) JjCheckNAddTwoStates(52, 8);
                                break;
                            case 53:
                                if (curChar != 48) break;
                                if (kind > 43) kind = 43;
                                JjCheckNAddStates(13, 15);
                                break;
                            case 55:
                                if ((0x3ff000000000000L & l) == 0L) break;
                                if (kind > 43) kind = 43;
                                JjCheckNAddTwoStates(55, 2);
                                break;
                            case 56:
                                if ((0xff000000000000L & l) == 0L) break;
                                if (kind > 43) kind = 43;
                                JjCheckNAddTwoStates(56, 2);
                                break;
                            default:
                                break;
                        }
                    } while (i != startsAt);
                } else if (curChar < 128) {
                    long l = 1L << (curChar & 077);
                    do {
                        switch(jjstateSet[--i]) {
                            case 0:
                                if ((0x7fffffe87fffffeL & l) != 0L) {
                                    if (kind > 51) kind = 51;
                                    JjCheckNAdd(37);
                                } else if (curChar == 96) JjCheckNAddStates(27, 29);
                                break;
                            case 2:
                                if ((0x100000001000L & l) != 0L && kind > 43) kind = 43;
                                break;
                            case 5:
                                if ((0x2000000020L & l) != 0L) JjAddStates(40, 41);
                                break;
                            case 8:
                                if ((0x5000000050L & l) != 0L && kind > 47) kind = 47;
                                break;
                            case 10:
                                if ((unchecked((long)0xffffffffefffffffL) & l) != 0L) JjCheckNAddStates(10, 12);
                                break;
                            case 11:
                                if (curChar == 92) JjAddStates(42, 44);
                                break;
                            case 12:
                                if ((0x14404410144044L & l) != 0L) JjCheckNAddStates(10, 12);
                                break;
                            case 19:
                                if ((unchecked((long)0xffffffffefffffffL) & l) != 0L) JjCheckNAddStates(7, 9);
                                break;
                            case 20:
                                if (curChar == 92) JjAddStates(45, 47);
                                break;
                            case 21:
                                if ((0x14404410144044L & l) != 0L) JjCheckNAddStates(7, 9);
                                break;
                            case 27:
                                if (curChar == 96) JjCheckNAddStates(27, 29);
                                break;
                            case 28:
                                if ((unchecked((long)0xfffffffeefffffffL) & l) != 0L) JjCheckNAddStates(27, 29);
                                break;
                            case 29:
                                if (curChar == 92) JjAddStates(48, 50);
                                break;
                            case 30:
                                if ((0x14404410144044L & l) != 0L) JjCheckNAddStates(27, 29);
                                break;
                            case 31:
                                if (curChar == 96 && kind > 51) kind = 51;
                                break;
                            case 36:
                            case 37:
                                if ((0x7fffffe87fffffeL & l) == 0L) break;
                                if (kind > 51) kind = 51;
                                JjCheckNAdd(37);
                                break;
                            case 42:
                                if ((0x2000000020L & l) != 0L) JjAddStates(51, 52);
                                break;
                            case 46:
                                if ((0x2000000020L & l) != 0L) JjAddStates(53, 54);
                                break;
                            case 50:
                                if ((0x2000000020L & l) != 0L) JjAddStates(55, 56);
                                break;
                            case 54:
                                if ((0x100000001000000L & l) != 0L) JjCheckNAdd(55);
                                break;
                            case 55:
                                if ((0x7e0000007eL & l) == 0L) break;
                                if (kind > 43) kind = 43;
                                JjCheckNAddTwoStates(55, 2);
                                break;
                            default:
                                break;
                        }
                    } while (i != startsAt);
                } else {
                    int i2 = (curChar & 0xff) >> 6;
                    long l2 = 1L << (curChar & 077);
                    do {
                        switch(jjstateSet[--i]) {
                            case 10:
                                if ((jjbitVec0[i2] & l2) != 0L) JjAddStates(10, 12);
                                break;
                            case 19:
                                if ((jjbitVec0[i2] & l2) != 0L) JjAddStates(7, 9);
                                break;
                            case 28:
                                if ((jjbitVec0[i2] & l2) != 0L) JjAddStates(27, 29);
                                break;
                            default:
                                break;
                        }
                    } while (i != startsAt);
                }
                if (kind != 0x7fffffff) {
                    jjmatchedKind = kind;
                    jjmatchedPos = curPos;
                    kind = 0x7fffffff;
                }
                ++curPos;
                if ((i = jjnewStateCnt) == (startsAt = 57 - (jjnewStateCnt = startsAt))) return curPos;
                try {
                    curChar = input_stream.ReadChar();
                } catch (System.IO.IOException e) {
                    return curPos;
                }
            }
        }

        internal static readonly int[] jjnextStates = { 39, 40, 45, 46, 49, 50, 8, 19, 20, 22, 10, 11, 13, 54, 56, 2, 4, 5, 8, 10, 11, 15, 13, 19, 20, 24, 22, 28, 29, 31, 28, 29, 33, 31, 41, 42, 8, 49, 50, 8, 6, 7, 12, 14, 16, 21, 23, 25, 30, 32, 34, 43, 44, 47, 48, 51, 52 };

        /** Token literal values. */
        public static readonly string[] jjstrLiteralImages = { "", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "\0x28", "\0x29", "\0x7b", "\0x7d", "\0x5b", "\0x5d", "\0x3b", "\0x2c", "\0x2e", "\0x3d", "\0x3e", "\0x3c", "\0x21", "\0x7e", "\0x3f", "\0x3a", "\0x3d" + "\0x3d", "\0x3c" + "\0x3d", "\0x3e" + "\0x3d", "\0x21" + "\0x3d", "\0x3c" + "\0x3e", "\0x7c" + "\0x7c", "\0x26" + "\0x26", "\0x2b" + "\0x2b", "\0x2d" + "\0x2d", "\0x2b", "\0x2d", "\0x2a", "\0x2f", "\0x26", "\0x7c", "\0x5e", "\0x25", "\0x3c" + "\0x3c", "\0x3e" + "\0x3e", "\0x3e" + "\0x3e" + "\0x3e" };

        /** Lexer state names. */
        public static readonly string[] lexStateNames = { "DEFAULT" };

        internal static readonly long[] jjtoToken = { unchecked((long)0xffce8fffffffffc1L), 0x3ffffffL };

        internal static readonly long[] jjtoSkip = { 0x3eL, 0x0L };

        protected internal Net.Vpc.Upa.Impl.Uql.Parser.Syntax.SimpleCharStream input_stream;

        private readonly int[] jjrounds = new int[57];

        private readonly int[] jjstateSet = new int[114];

        protected internal char curChar;

        /** Constructor. */
        public UQLParserTokenManager(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.SimpleCharStream stream) {
            if (Net.Vpc.Upa.Impl.Uql.Parser.Syntax.SimpleCharStream.staticFlag) throw new System.Exception("ERROR: Cannot use a static CharStream class with a non-static lexical analyzer.");
            input_stream = stream;
        }

        /** Constructor. */
        public UQLParserTokenManager(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.SimpleCharStream stream, int lexState)  : this(stream){

            SwitchTo(lexState);
        }

        /** Reinitialise parser. */
        public virtual void ReInit(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.SimpleCharStream stream) {
            jjmatchedPos = jjnewStateCnt = 0;
            curLexState = defaultLexState;
            input_stream = stream;
            ReInitRounds();
        }

        private void ReInitRounds() {
            int i;
            jjround = unchecked((int)0x80000001);
            for (i = 57; i-- > 0; ) jjrounds[i] = unchecked((int)0x80000000);
        }

        /** Reinitialise parser. */
        public virtual void ReInit(Net.Vpc.Upa.Impl.Uql.Parser.Syntax.SimpleCharStream stream, int lexState) {
            ReInit(stream);
            SwitchTo(lexState);
        }

        /** Switch to specified lex state. */
        public virtual void SwitchTo(int lexState) {
            if (lexState >= 1 || lexState < 0) throw new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.TokenMgrError("Error: Ignoring invalid lexical state : " + lexState + ". State unchanged.", Net.Vpc.Upa.Impl.Uql.Parser.Syntax.TokenMgrError.INVALID_LEXICAL_STATE); else curLexState = lexState;
        }

        protected internal virtual Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token JjFillToken() {
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token t;
            string curTokenImage;
            int beginLine;
            int endLine;
            int beginColumn;
            int endColumn;
            string im = jjstrLiteralImages[jjmatchedKind];
            curTokenImage = (im == null) ? input_stream.GetImage() : im;
            beginLine = input_stream.GetBeginLine();
            beginColumn = input_stream.GetBeginColumn();
            endLine = input_stream.GetEndLine();
            endColumn = input_stream.GetEndColumn();
            t = Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token.NewToken(jjmatchedKind, curTokenImage);
            t.beginLine = beginLine;
            t.endLine = endLine;
            t.beginColumn = beginColumn;
            t.endColumn = endColumn;
            return t;
        }

        internal int curLexState = 0;

        internal int defaultLexState = 0;

        internal int jjnewStateCnt;

        internal int jjround;

        internal int jjmatchedPos;

        internal int jjmatchedKind;

        /** Get the next Token. */
        public virtual Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token GetNextToken() {
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.Token matchedToken;
            int curPos = 0;
            EOFLoop: 
            for (; ; ) {
                try {
                    curChar = input_stream.BeginToken();
                } catch (System.IO.IOException e) {
                    jjmatchedKind = 0;
                    matchedToken = JjFillToken();
                    return matchedToken;
                }
                try {
                    input_stream.Backup(0);
                    while (curChar <= 32 && (0x100003600L & (1L << curChar)) != 0L) curChar = input_stream.BeginToken();
                } catch (System.IO.IOException e1) {
                    goto  continue_EOFLoop;
                }
                jjmatchedKind = 0x7fffffff;
                jjmatchedPos = 0;
                curPos = JjMoveStringLiteralDfa0_0();
                if (jjmatchedKind != 0x7fffffff) {
                    if (jjmatchedPos + 1 < curPos) input_stream.Backup(curPos - jjmatchedPos - 1);
                    if ((jjtoToken[jjmatchedKind >> 6] & (1L << (jjmatchedKind & 077))) != 0L) {
                        matchedToken = JjFillToken();
                        return matchedToken;
                    } else {
                        goto  continue_EOFLoop;
                    }
                }
                int error_line = input_stream.GetEndLine();
                int error_column = input_stream.GetEndColumn();
                string error_after = null;
                bool EOFSeen = false;
                try {
                    input_stream.ReadChar();
                    input_stream.Backup(1);
                } catch (System.IO.IOException e1) {
                    EOFSeen = true;
                    error_after = curPos <= 1 ? "" : input_stream.GetImage();
                    if (curChar == '\n' || curChar == '\r') {
                        error_line++;
                        error_column = 0;
                    } else error_column++;
                }
                if (!EOFSeen) {
                    input_stream.Backup(1);
                    error_after = curPos <= 1 ? "" : input_stream.GetImage();
                }
                throw new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.TokenMgrError(EOFSeen, curLexState, error_line, error_column, error_after, curChar, Net.Vpc.Upa.Impl.Uql.Parser.Syntax.TokenMgrError.LEXICAL_ERROR);
                continue_EOFLoop : {/*added by fwk*/}
            }
        }

        private void JjCheckNAdd(int state) {
            if (jjrounds[state] != jjround) {
                jjstateSet[jjnewStateCnt++] = state;
                jjrounds[state] = jjround;
            }
        }

        private void JjAddStates(int start, int end) {
            do {
                jjstateSet[jjnewStateCnt++] = jjnextStates[start];
            } while (start++ != end);
        }

        private void JjCheckNAddTwoStates(int state1, int state2) {
            JjCheckNAdd(state1);
            JjCheckNAdd(state2);
        }

        private void JjCheckNAddStates(int start, int end) {
            do {
                JjCheckNAdd(jjnextStates[start]);
            } while (start++ != end);
        }
    }
}
