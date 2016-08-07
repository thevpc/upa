package net.vpc.upa.tutorial.desktop;

import java.io.PrintWriter;
import java.io.StringWriter;
import java.util.Date;
import java.util.logging.*;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:00 PM
 */
public class LogUtils {
    public static boolean logEnabled=true;
    static{
        java.util.logging.Logger rootLogger = java.util.logging.Logger.getLogger("");
        rootLogger.setLevel(Level.FINEST);
        for (Handler handler : rootLogger.getHandlers()) {
            handler.setLevel(Level.FINEST);
            handler.setFormatter(new LogFormatter());
            handler.setFilter(new Filter() {
                @Override
                public boolean isLoggable(LogRecord record) {
//                    return record.getLoggerName().startsWith("*net.vpc.upa.impl.persistence.DefaultUConnection");
                    return logEnabled && record.getLoggerName().startsWith("net.vpc.");
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
