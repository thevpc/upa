/*
 * Created by IntelliJ IDEA.
 * User: taha
 * Date: 20 sept. 02
 * Time: 22:05:29
 * To change template for new class use 
 * Code Style | Class Templates options (Tools | IDE Options).
 */
package net.vpc.upa.impl.util;

import net.vpc.upa.exceptions.UPAIllegalArgumentException;

class StringFormatter implements Formatter {
    public static final byte LEFT_ALIGN = 0;
    public static final byte RIGTH_ALIGN = 1;
    public static final byte CENTER_ALIGN = 2;
    private int width;
    private char white;
    private int position;

    public StringFormatter() {
        this(-1, ' ', 0);
    }

    public StringFormatter(int width) {
        this(width, ' ', 0);
    }

    public StringFormatter(int width, int position) {
        this(width, ' ', position);
    }

    public StringFormatter(int width, char white, int position) {
        this.width = width;
        this.white = white;
        this.position = position;
        if (position != LEFT_ALIGN && position != RIGTH_ALIGN && position != CENTER_ALIGN) {
            throw new UPAIllegalArgumentException("Expected StringFormatter.LEFT_ALIGN | RIGTH_ALIGN | CENTER_ALIGN");
        }
    }

    public String format(Object object) {
        String string = object != null ? object.toString() : "";
        if (width < 0)
            return string;
        int remaining = width - string.length();
        if (remaining == 0)
            return string;
        if (remaining < 0)
            switch (position) {
                case RIGTH_ALIGN: // '\001'
                    return StringUtils.substring(string, remaining);

                case CENTER_ALIGN: // '\002'
                    return string = StringUtils.substring(string, remaining / 2, width + remaining / 2);

                case LEFT_ALIGN: // '\0'
                default:
                    return StringUtils.substring(string, 0, remaining);
            }
        char[] left;
        char[] rigth;
        switch (position) {
            case RIGTH_ALIGN: // '\001'
                left = new char[remaining];
                rigth = new char[0];
                break;

            case CENTER_ALIGN: // '\002'
                left = new char[remaining / 2];
                rigth = new char[remaining - remaining / 2];
                break;

            case LEFT_ALIGN: // '\0'
            default:
                left = new char[0];
                rigth = new char[remaining];
                break;
        }
        int len = rigth.length;
        for (int i = 0; i < len; i++){
            rigth[i] = white;
        }
        len = left.length;
        for (int i = 0; i < len; i++){
            left[i] = white;
        }
        StringBuilder sb = new StringBuilder();
        return sb.append(left).append(string).append(rigth).toString();
    }


}
