using System;
namespace Net.TheVpc.Upa.Types{
    //SPECIFIC

    /**
     * User: taha
     * Date: 5 sept. 2003
     * Time: 12:57:26
     */
    public abstract class Temporal : ICloneable {
        protected System.DateTime time;

        public Temporal()  : base(){
            time=new System.DateTime();
        }

        public Temporal(long date)  : base(){

            time=new System.DateTime(date);
        }

        public System.DateTime Value{get{return time;}}

        public virtual long GetTime(){return time.Ticks;}

        public int CompareTo(Temporal other){
            if(other == null){
                return 1;
            }
            return Value.CompareTo(other.Value);
        }

        public virtual Object Clone() {return this.MemberwiseClone();}
    }
}
