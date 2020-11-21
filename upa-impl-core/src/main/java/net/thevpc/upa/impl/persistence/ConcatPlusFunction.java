//package net.thevpc.database.persistence;
//
//import net.thevpc.database.parser.Function;
//
//
///**
// * Created by IntelliJ IDEA.
// * User: vpc
// * Date: 22 mai 2003
// * Time: 17:17:34
// * 
// */
//public class ConcatPlusFunction extends Function {
//    public String simplify(String functionName, String[] params, java.util.HashMap context) {
//        if(params.length<2){
//            throw new UPAIllegalArgumentException("function '"+functionName+"' requieres at least 2 arguments.\n Error near "+functionName+"("+StringFormatter.format(params)+")");
//        }else{
//            return StringFormatter.format(params,"(",", ",")",null);
////            StringBuffer sb=new StringBuffer("(");
////            sb.append(params[0]);
////            for(int i=1;i<params.length;i++){
////                sb.append('+').append(params[i]);
////            }
////            sb.append(")");
////            return sb.toString();
//        }
//    }
//}
