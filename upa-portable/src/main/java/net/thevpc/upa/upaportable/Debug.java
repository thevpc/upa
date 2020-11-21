package net.thevpc.upa.upaportable;

import java.text.DecimalFormat;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/30/12 11:15 AM
 */
public class Debug {
    static DecimalFormat decimalFormat = new DecimalFormat("000");
//    public static final void println(Object s){
//
//    }

    public static final void println(Object s){
        StackTraceElement[] stackTrace = new Throwable().getStackTrace();
        StringBuilder sb=new StringBuilder();
        int length = stackTrace.length;
        sb.append(decimalFormat.format(length));
        String className = stackTrace[1].getClassName();
        className=className.substring(className.lastIndexOf('.')+1);
        String methodName=stackTrace[1].getMethodName();
        String lineNbr=String.valueOf(stackTrace[1].getLineNumber());

        for(int i=0;i< length;i++){
            sb.append(' ');
        }
        sb.append("[");
        sb.append(className);
        sb.append(".");
        sb.append(methodName);
        sb.append(":");
        sb.append(lineNbr);
        sb.append("]");
        sb.append(" ");
        sb.append(s);
        System.out.println(sb);
    }
}
