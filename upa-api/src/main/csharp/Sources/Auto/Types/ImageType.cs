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



namespace Net.Vpc.Upa.Types
{

    /**
     * User: taha Date: 16 juin 2003 Time: 15:47:42
     */
    public class ImageType : Net.Vpc.Upa.Types.FileType {

        private int width;

        private int height;

        public ImageType(string name, bool nullable)  : this(name, -1, -1, -1, nullable){

        }

        public ImageType(string name, int width, int height, int maxSize, bool nullable)  : base(name, maxSize, null, nullable){

            this.width = width;
            this.height = height;
        }


        public override void Check(object @value, string name, string description) /* throws Net.Vpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (@value == null) {
                return;
            }
            if ((GetMaxSize()).Value > 0 && (GetMaxSize()).Value < ((Net.Vpc.Upa.Types.FileData) @value).Size()) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("ImageSizeTooBig", name, description, @value, GetMaxSize());
            }
        }

        public virtual int GetWidth() {
            return width;
        }

        public virtual void SetWidth(int width) {
            this.width = width;
        }

        public virtual int GetHeight() {
            return height;
        }

        public virtual void SetHeight(int height) {
            this.height = height;
        }
    }
}
