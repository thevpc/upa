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

    internal class StringFormatter : Net.Vpc.Upa.Impl.Util.Formatter {

        public const byte LEFT_ALIGN = ((byte)0);

        public const byte RIGTH_ALIGN = ((byte)1);

        public const byte CENTER_ALIGN = ((byte)2);

        private int width;

        private char white;

        private int position;

        public StringFormatter()  : this(-1, ' ', 0){

        }

        public StringFormatter(int width)  : this(width, ' ', 0){

        }

        public StringFormatter(int width, int position)  : this(width, ' ', position){

        }

        public StringFormatter(int width, char white, int position) {
            this.width = width;
            this.white = white;
            this.position = position;
            if (position != LEFT_ALIGN && position != RIGTH_ALIGN && position != CENTER_ALIGN) {
                throw new System.ArgumentException ("Expected StringFormatter.LEFT_ALIGN | RIGTH_ALIGN | CENTER_ALIGN");
            }
        }

        public virtual string Format(object @object) {
            string @string = @object != null ? @object.ToString() : "";
            if (width < 0) return @string;
            int remaining = width - (@string).Length;
            if (remaining == 0) return @string;
            if (remaining < 0) switch(position) {
                case RIGTH_ALIGN:
                    return Net.Vpc.Upa.Impl.Util.StringUtils.Substring(@string, remaining);
                case CENTER_ALIGN:
                    return @string = Net.Vpc.Upa.Impl.Util.StringUtils.Substring(@string, remaining / 2, width + remaining / 2);
                case LEFT_ALIGN:
                default:
                    return Net.Vpc.Upa.Impl.Util.StringUtils.Substring(@string, 0, remaining);
            }
            char[] left;
            char[] rigth;
            switch(position) {
                case RIGTH_ALIGN:
                    left = new char[remaining];
                    rigth = new char[0];
                    break;
                case CENTER_ALIGN:
                    left = new char[remaining / 2];
                    rigth = new char[remaining - remaining / 2];
                    break;
                case LEFT_ALIGN:
                default:
                    left = new char[0];
                    rigth = new char[remaining];
                    break;
            }
            int len = rigth.Length;
            for (int i = 0; i < len; i++) {
                rigth[i] = white;
            }
            len = left.Length;
            for (int i = 0; i < len; i++) {
                left[i] = white;
            }
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            return sb.Append(left).Append(@string).Append(rigth).ToString();
        }
    }
}
