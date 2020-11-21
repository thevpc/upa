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



namespace Net.TheVpc.Upa.Impl.Util
{

    /**
     * This class provides encode/decode for RFC 2045 Base64 as defined by RFC 2045,
     * N. Freed and N. Borenstein. RFC 2045: Multipurpose Internet Mail Extensions
     * (MIME) Part One: Format of Internet Message Bodies. Reference 1996 Available
     * at: http://www.ietf.org/rfc/rfc2045.txt This class is used by XML PersistenceUnit
     * binary format validation
     *
     * This implementation does not encode/decode streaming data. You need the data
     * that you will encode/decode already on a byte arrray.
     *
     * @author Jeffrey Rodriguez
     * @author Sandy Gao
     * @version $Id: Base64.java,v 1.8 2003/05/08 20:11:55 elena Exp $
     */
    public sealed class Base64 {

        private const int BASELENGTH = 255;

        private const int LOOKUPLENGTH = 64;

        private const int TWENTYFOURBITGROUP = 24;

        private const int EIGHTBIT = 8;

        private const int SIXTEENBIT = 16;

        private const int SIXBIT = 6;

        private const int FOURBYTE = 4;

        private static readonly int SIGN = -128;

        private const char PAD = '=';

        private const bool fDebug = false;

        private static readonly byte[] base64Alphabet = new byte[BASELENGTH];

        private static readonly char[] lookUpBase64Alphabet = new char[LOOKUPLENGTH];

        static Base64(){
            for (int i = 0; i < BASELENGTH; i++) {
                base64Alphabet[i] = ((byte)127);
            }
            for (int i = 'Z'; i >= 'A'; i--) {
                base64Alphabet[i] = (byte) (i - 'A');
            }
            for (int i = 'z'; i >= 'a'; i--) {
                base64Alphabet[i] = (byte) (i - 'a' + 26);
            }
            for (int i = '9'; i >= '0'; i--) {
                base64Alphabet[i] = (byte) (i - '0' + 52);
            }
            base64Alphabet['+'] = ((byte)62);
            base64Alphabet['/'] = ((byte)63);
            for (int i = 0; i <= 25; i++) {
                lookUpBase64Alphabet[i] = (char) ('A' + i);
            }
            int j = 0;
            for (int i = 26; i <= 51; i++) {
                lookUpBase64Alphabet[i] = (char) ('a' + j);
                j++;
            }
            j = 0;
            for (int i = 52; i <= 61; i++) {
                lookUpBase64Alphabet[i] = (char) ('0' + j);
                j++;
            }
            lookUpBase64Alphabet[62] = (char) '+';
            lookUpBase64Alphabet[63] = (char) '/';
        }

        public static void Main(string[] args) {
            System.Console.Out.WriteLine("");
        }

        internal static bool IsWhiteSpace(char octect) {
            return (octect == ((char)0x20) || octect == ((char)0xd) || octect == ((char)0xa) || octect == ((char)0x9));
        }

        internal static bool IsPad(char octect) {
            return (octect == PAD);
        }

        internal static bool IsData(char octect) {
            return (base64Alphabet[octect] != -1);
        }

        internal static bool IsBase64(char octect) {
            return (IsWhiteSpace(octect) || IsPad(octect) || IsData(octect));
        }

        /**
             * Encodes hex octects into Base64
             *
             * @param binaryData Array containing binaryData
             * @return Encoded Base64 array
             */
        public static string Encode(byte[] binaryData) {
            if (binaryData == null) {
                return null;
            }
            int lengthDataBits = binaryData.Length * EIGHTBIT;
            if (lengthDataBits == 0) {
                return "";
            }
            int fewerThan24bits = lengthDataBits % TWENTYFOURBITGROUP;
            int numberTriplets = lengthDataBits / TWENTYFOURBITGROUP;
            int numberQuartet = fewerThan24bits != 0 ? numberTriplets + 1 : numberTriplets;
            int numberLines = (numberQuartet - 1) / 19 + 1;
            char[] encodedData/*[]*/ = null;
            encodedData = new char[numberQuartet * 4 + numberLines];
            byte k = ((byte)0);
            byte l = ((byte)0);
            byte b1 = ((byte)0);
            byte b2 = ((byte)0);
            byte b3 = ((byte)0);
            int encodedIndex = 0;
            int dataIndex = 0;
            int i = 0;
            if (fDebug) {
                System.Console.Out.WriteLine("number of triplets = " + numberTriplets);
            }
            for (int line = 0; line < numberLines - 1; line++) {
                for (int quartet = 0; quartet < 19; quartet++) {
                    b1 = binaryData[dataIndex++];
                    b2 = binaryData[dataIndex++];
                    b3 = binaryData[dataIndex++];
                    if (fDebug) {
                        System.Console.Out.WriteLine("b1= " + b1 + ", b2= " + b2 + ", b3= " + b3);
                    }
                    l = (byte) (b2 & ((byte)0x0f));
                    k = (byte) (b1 & ((byte)0x03));
                    byte val1 = ((b1 & SIGN) == 0) ? (byte) (b1 >> ((byte)2)) : (byte) ((b1) >> ((byte)2) ^ 0xc0);
                    byte val2 = ((b2 & SIGN) == 0) ? (byte) (b2 >> ((byte)4)) : (byte) ((b2) >> ((byte)4) ^ 0xf0);
                    byte val3 = ((b3 & SIGN) == 0) ? (byte) (b3 >> ((byte)6)) : (byte) ((b3) >> ((byte)6) ^ 0xfc);
                    if (fDebug) {
                        System.Console.Out.WriteLine("val2 = " + val2);
                        System.Console.Out.WriteLine("k4   = " + (k << ((byte)4)));
                        System.Console.Out.WriteLine("vak  = " + (val2 | (k << ((byte)4))));
                    }
                    encodedData[encodedIndex++] = lookUpBase64Alphabet[val1];
                    encodedData[encodedIndex++] = lookUpBase64Alphabet[val2 | (k << ((byte)4))];
                    encodedData[encodedIndex++] = lookUpBase64Alphabet[(l << ((byte)2)) | val3];
                    encodedData[encodedIndex++] = lookUpBase64Alphabet[b3 & ((byte)0x3f)];
                    i++;
                }
                encodedData[encodedIndex++] = ((char)0xa);
            }
            for (; i < numberTriplets; i++) {
                b1 = binaryData[dataIndex++];
                b2 = binaryData[dataIndex++];
                b3 = binaryData[dataIndex++];
                if (fDebug) {
                    System.Console.Out.WriteLine("b1= " + b1 + ", b2= " + b2 + ", b3= " + b3);
                }
                l = (byte) (b2 & ((byte)0x0f));
                k = (byte) (b1 & ((byte)0x03));
                byte val1 = ((b1 & SIGN) == 0) ? (byte) (b1 >> ((byte)2)) : (byte) ((b1) >> ((byte)2) ^ 0xc0);
                byte val2 = ((b2 & SIGN) == 0) ? (byte) (b2 >> ((byte)4)) : (byte) ((b2) >> ((byte)4) ^ 0xf0);
                byte val3 = ((b3 & SIGN) == 0) ? (byte) (b3 >> ((byte)6)) : (byte) ((b3) >> ((byte)6) ^ 0xfc);
                if (fDebug) {
                    System.Console.Out.WriteLine("val2 = " + val2);
                    System.Console.Out.WriteLine("k4   = " + (k << ((byte)4)));
                    System.Console.Out.WriteLine("vak  = " + (val2 | (k << ((byte)4))));
                }
                encodedData[encodedIndex++] = lookUpBase64Alphabet[val1];
                encodedData[encodedIndex++] = lookUpBase64Alphabet[val2 | (k << ((byte)4))];
                encodedData[encodedIndex++] = lookUpBase64Alphabet[(l << ((byte)2)) | val3];
                encodedData[encodedIndex++] = lookUpBase64Alphabet[b3 & ((byte)0x3f)];
            }
            // form integral number of 6-bit groups
            if (fewerThan24bits == EIGHTBIT) {
                b1 = binaryData[dataIndex];
                k = (byte) (b1 & ((byte)0x03));
                if (fDebug) {
                    System.Console.Out.WriteLine("b1=" + b1);
                    System.Console.Out.WriteLine("b1<<2 = " + (b1 >> ((byte)2)));
                }
                byte val1 = ((b1 & SIGN) == 0) ? (byte) (b1 >> ((byte)2)) : (byte) ((b1) >> ((byte)2) ^ 0xc0);
                encodedData[encodedIndex++] = lookUpBase64Alphabet[val1];
                encodedData[encodedIndex++] = lookUpBase64Alphabet[k << ((byte)4)];
                encodedData[encodedIndex++] = PAD;
                encodedData[encodedIndex++] = PAD;
            } else if (fewerThan24bits == SIXTEENBIT) {
                b1 = binaryData[dataIndex];
                b2 = binaryData[dataIndex + 1];
                l = (byte) (b2 & ((byte)0x0f));
                k = (byte) (b1 & ((byte)0x03));
                byte val1 = ((b1 & SIGN) == 0) ? (byte) (b1 >> ((byte)2)) : (byte) ((b1) >> ((byte)2) ^ 0xc0);
                byte val2 = ((b2 & SIGN) == 0) ? (byte) (b2 >> ((byte)4)) : (byte) ((b2) >> ((byte)4) ^ 0xf0);
                encodedData[encodedIndex++] = lookUpBase64Alphabet[val1];
                encodedData[encodedIndex++] = lookUpBase64Alphabet[val2 | (k << ((byte)4))];
                encodedData[encodedIndex++] = lookUpBase64Alphabet[l << ((byte)2)];
                encodedData[encodedIndex++] = PAD;
            }
            encodedData[encodedIndex] = ((char)0xa);
            return new string(encodedData);
        }

        /**
             * Decodes Base64 data into octects
             *
             * @param binaryData Byte array containing Base64 data
             * @return Array containind decoded data.
             */
        public static byte[] Decode(string encoded) {
            if (encoded == null) {
                return null;
            }
            char[] base64Data = encoded.ToCharArray();
            // remove white spaces
            int len = RemoveWhiteSpace(base64Data);
            if (len % FOURBYTE != 0) {
                return null;
            }
            //should be divisible by four
            int numberQuadruple = (len / FOURBYTE);
            if (numberQuadruple == 0) {
                return new byte[0];
            }
            byte[] decodedData/*[]*/ = null;
            byte b1 = ((byte)0);
            byte b2 = ((byte)0);
            byte b3 = ((byte)0);
            byte b4 = ((byte)0);
            byte marker0 = ((byte)0);
            byte marker1 = ((byte)0);
            char d1 = '\0';
            char d2 = '\0';
            char d3 = '\0';
            char d4 = '\0';
            int i = 0;
            int encodedIndex = 0;
            int dataIndex = 0;
            decodedData = new byte[(numberQuadruple) * 3];
            for (; i < numberQuadruple - 1; i++) {
                if (!IsData((d1 = base64Data[dataIndex++])) || !IsData((d2 = base64Data[dataIndex++])) || !IsData((d3 = base64Data[dataIndex++])) || !IsData((d4 = base64Data[dataIndex++]))) {
                    return null;
                }
                //if found "no data" just return null
                b1 = base64Alphabet[d1];
                b2 = base64Alphabet[d2];
                b3 = base64Alphabet[d3];
                b4 = base64Alphabet[d4];
                decodedData[encodedIndex++] = (byte) (b1 << ((byte)2) | b2 >> ((byte)4));
                decodedData[encodedIndex++] = (byte) (((b2 & ((byte)0xf)) << 4) | ((b3 >> ((byte)2)) & 0xf));
                decodedData[encodedIndex++] = (byte) (b3 << ((byte)6) | b4);
            }
            if (!IsData((d1 = base64Data[dataIndex++])) || !IsData((d2 = base64Data[dataIndex++]))) {
                return null;
            }
            //if found "no data" just return null
            b1 = base64Alphabet[d1];
            b2 = base64Alphabet[d2];
            d3 = base64Data[dataIndex++];
            d4 = base64Data[dataIndex++];
            if (!IsData((d3)) || !IsData((d4))) {
                //Check if they are PAD characters
                if (IsPad(d3) && IsPad(d4)) {
                    //Two PAD e.g. 3c[Pad][Pad]
                    if ((b2 & ((byte)0xf)) != 0) {
                        return null;
                    }
                    byte[] tmp = new byte[i * 3 + 1];
                    System.Array.Copy(decodedData, 0, tmp, 0, i * 3);
                    tmp[encodedIndex] = (byte) (b1 << ((byte)2) | b2 >> ((byte)4));
                    return tmp;
                } else if (!IsPad(d3) && IsPad(d4)) {
                    //One PAD  e.g. 3cQ[Pad]
                    b3 = base64Alphabet[d3];
                    if ((b3 & ((byte)0x3)) != 0) {
                        return null;
                    }
                    byte[] tmp = new byte[i * 3 + 2];
                    System.Array.Copy(decodedData, 0, tmp, 0, i * 3);
                    tmp[encodedIndex++] = (byte) (b1 << ((byte)2) | b2 >> ((byte)4));
                    tmp[encodedIndex] = (byte) (((b2 & ((byte)0xf)) << 4) | ((b3 >> ((byte)2)) & 0xf));
                    return tmp;
                } else {
                    return null;
                }
            } else {
                //No PAD e.g 3cQl
                b3 = base64Alphabet[d3];
                b4 = base64Alphabet[d4];
                decodedData[encodedIndex++] = (byte) (b1 << ((byte)2) | b2 >> ((byte)4));
                decodedData[encodedIndex++] = (byte) (((b2 & ((byte)0xf)) << 4) | ((b3 >> ((byte)2)) & 0xf));
                decodedData[encodedIndex++] = (byte) (b3 << ((byte)6) | b4);
            }
            return decodedData;
        }

        /**
             * remove WhiteSpace from MIME containing encoded Base64 data.
             *
             * @param data the byte array of base64 data (with WS)
             * @return the new length
             */
        internal static int RemoveWhiteSpace(char[] data) {
            if (data == null) {
                return 0;
            }
            // count characters that's not whitespace
            int newSize = 0;
            int len = data.Length;
            for (int i = 0; i < len; i++) {
                if (!IsWhiteSpace(data[i])) {
                    data[newSize++] = data[i];
                }
            }
            return newSize;
        }
    }
}
