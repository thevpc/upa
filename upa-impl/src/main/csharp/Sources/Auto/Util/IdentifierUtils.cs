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



namespace Net.Vpc.Upa.Impl.Util
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */

    public class IdentifierUtils {

        public static readonly string LOCAL_SYSTEM_ID = GenerateID();

        public const string ALPHA_CHARS = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";

        public const string ALPHA_NUM_CHARS = "qwertyuiopasdfghjklzxcvbnm1234567890QWERTYUIOPASDFGHJKLZXCVBNM";

        public const string ALPHA_NUM_DASH_CHARS = "qwertyuiopasdfghjklzxcvbnm_1234567890QWERTYUIOPASDFGHJKLZXCVBNM";

        public static string GenerateID() {
            return GenerateID(16);
        }

        public static string GenerateID(int nbChar) {
            if (nbChar < 0) {
                return null;
            }
            string id = System.Convert.ToString((new Net.Vpc.Upa.Types.DateTime()).GetTime(), 16);
            string aleat = System.Convert.ToString(Net.Vpc.Upa.Impl.FwkConvertUtils.Random());
            string ID = id + aleat.Substring(1);
            if ((ID).Length > nbChar) {
                ID = ID.Substring(0, nbChar);
            }
            return ID;
        }

        public static string GenerateString(int minNbr, int maxNbr, string startChars, string middleChars, string endChars) {
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
                nbr += (int) (System.Math.Round(Net.Vpc.Upa.Impl.FwkConvertUtils.Random() * (double) (maxNbr - minNbr)) % (long) (maxNbr - minNbr));
            }
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            s.Append(RandomChar(startChars));
            for (int i = 0; i < nbr - 1; i++) {
                s.Append(RandomChar(middleChars));
            }
            if ((s).Length < nbr) {
                s.Append(RandomChar(endChars));
            }
            return s.ToString();
        }

        public static string GenerateID(int nbr, string chars) {
            return GenerateID(nbr, chars, chars, chars);
        }

        public static string GenerateID(int nbr, string startChars, string middleChars, string endChars) {
            return GenerateID(nbr, nbr, startChars, middleChars, endChars);
        }

        public static string GenerateID(int minNbr, int maxNbr, string startChars, string middleChars, string endChars) {
            if (startChars == null) {
                startChars = ALPHA_CHARS;
            }
            if (middleChars == null) {
                middleChars = ALPHA_NUM_DASH_CHARS;
            }
            if (endChars == null) {
                endChars = ALPHA_NUM_CHARS;
            }
            int nbr = maxNbr <= minNbr ? minNbr : (int) (System.Math.Round(Net.Vpc.Upa.Impl.FwkConvertUtils.Random() * (double) (maxNbr - minNbr)) % (long) (maxNbr - minNbr)) + minNbr;
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            s.Append(RandomChar(startChars));
            for (int i = 0; i < nbr - 1; i++) {
                s.Append(RandomChar(middleChars));
            }
            if ((s).Length < nbr) {
                s.Append(RandomChar(endChars));
            }
            return s.ToString();
        }

        public static char RandomChar(string chars) {
            return chars[(int) (System.Math.Round(Net.Vpc.Upa.Impl.FwkConvertUtils.Random() * (double) (chars).Length) % (long) (chars).Length)];
        }
    }
}
