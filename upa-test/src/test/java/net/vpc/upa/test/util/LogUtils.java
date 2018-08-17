package net.vpc.upa.test.util;

import java.io.PrintWriter;
import java.io.StringWriter;
import java.util.Date;
import java.util.logging.*;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:00 PM
 */
public class LogUtils {
    static{
        java.util.logging.Logger rootLogger = java.util.logging.Logger.getLogger("");
        rootLogger.setLevel(Level.FINE);
        for (Handler handler : rootLogger.getHandlers()) {
            handler.setLevel(Level.FINE);
            handler.setFormatter(new LogFormatter());
            handler.setFilter(new Filter() {
                public boolean isLoggable(LogRecord record) {
                    return record.getLoggerName().startsWith("net.vpc.");
                }
            });
        }
    }

    public static void silence(){
        java.util.logging.Logger rootLogger = java.util.logging.Logger.getLogger("");
        rootLogger.setLevel(Level.OFF);
        for (Handler handler : rootLogger.getHandlers()) {
            handler.setLevel(Level.OFF);
            handler.setFormatter(new LogFormatter());
            handler.setFilter(new Filter() {
                public boolean isLoggable(LogRecord record) {
                    return record.getLoggerName().startsWith("net.vpc.");
                }
            });
        }
    }

    public static void prepare(){
        //do nothing
    }

    private static final class LogFormatter extends Formatter {

        private static final String LINE_SEPARATOR = System.getProperty("line.separator");

        @Override
        public String format(LogRecord record) {
            StringBuilder sb = new StringBuilder();

            sb.append(new Date(record.getMillis()))
                    .append(" ")
                    .append(record.getLevel().getLocalizedName())
                    .append(": ")
                    .append(formatMessage(record))
                    .append(LINE_SEPARATOR);

            if (record.getThrown() != null) {
                try {
                    StringWriter sw = new StringWriter();
                    PrintWriter pw = new PrintWriter(sw);
                    record.getThrown().printStackTrace(pw);
                    pw.close();
                    sb.append(sw.toString());
                } catch (Exception ex) {
                    // ignore
                }
            }

            return sb.toString();
        }
    }
}
