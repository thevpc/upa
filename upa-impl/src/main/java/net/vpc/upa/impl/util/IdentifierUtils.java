/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util;

import java.util.Date;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@Deprecated
public class IdentifierUtils {

    public static final String LOCAL_SYSTEM_ID = generateID();
    public static final String ALPHA_CHARS = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
    public static final String ALPHA_NUM_CHARS = "qwertyuiopasdfghjklzxcvbnm1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
    public static final String ALPHA_NUM_DASH_CHARS = "qwertyuiopasdfghjklzxcvbnm_1234567890QWERTYUIOPASDFGHJKLZXCVBNM";

    public static String generateID() {
        return generateID(16);
    }

    public static String generateID(int nbChar) {
        if (nbChar < 0) {
            return null;
        }
        String id = Long.toString((new Date()).getTime(), 16);
        String aleat = Double.toString(Math.random());
        String ID = id + aleat.substring(1);
        if (ID.length() > nbChar) {
            ID = ID.substring(0, nbChar);
        }
        return ID;
    }

    public static String generateString(int minNbr, int maxNbr, String startChars, String middleChars, String endChars) {
        if (startChars == null) {
            startChars = ALPHA_CHARS;
        }
        if (middleChars == null) {
            middleChars = "qwertyuiopasdfghjklzxcvbnm1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
        }
        if (endChars == null) {
            endChars = "qwertyuiopasdfghjklzxcvbnm1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
        }
        int nbr = minNbr;
        if (maxNbr > minNbr) {
            nbr += (int) (Math.round(Math.random() * (double) (maxNbr - minNbr)) % (long) (maxNbr - minNbr));
        }
        StringBuilder s = new StringBuilder();
        s.append(randomChar(startChars));
        for (int i = 0; i < nbr - 1; i++) {
            s.append(randomChar(middleChars));
        }

        if (s.length() < nbr) {
            s.append(randomChar(endChars));
        }
        return s.toString();
    }

    public static String generateID(int nbr, String chars) {
        return generateID(nbr, chars, chars, chars);
    }

    public static String generateID(int nbr, String startChars, String middleChars, String endChars) {
        return generateID(nbr, nbr, startChars, middleChars, endChars);
    }

    public static String generateID(int minNbr, int maxNbr, String startChars, String middleChars, String endChars) {
        if (startChars == null) {
            startChars = ALPHA_CHARS;
        }
        if (middleChars == null) {
            middleChars = ALPHA_NUM_DASH_CHARS;
        }
        if (endChars == null) {
            endChars = ALPHA_NUM_CHARS;
        }
        int nbr = maxNbr <= minNbr ? minNbr : (int) (Math.round(Math.random() * (double) (maxNbr - minNbr)) % (long) (maxNbr - minNbr)) + minNbr;
        StringBuilder s = new StringBuilder();
        s.append(randomChar(startChars));
        for (int i = 0; i < nbr - 1; i++) {
            s.append(randomChar(middleChars));
        }

        if (s.length() < nbr) {
            s.append(randomChar(endChars));
        }
        return s.toString();
    }

//    public static String generateRandomIdsList(long min, long max, long requestedSize) {
//        TreeSet ts = new TreeSet();
//        long width = max - min;
//        Long alea;
//        for (; (long) ts.size() < requestedSize; ts.add(alea)) {
//            alea = new Long(Math.round(Math.random() * (double) width) + min);
//        }
//
//        StringBuilder sb = new StringBuilder();
//        Iterator i = ts.iterator();
//        while (i.hasNext()) {
//            sb.append(",").append(i.next());
//        }
//        return sb.toString().substring(1);
//    }

    public static char randomChar(String chars) {
        return chars.charAt((int) (Math.round(Math.random() * (double) chars.length()) % (long) chars.length()));
    }
}
