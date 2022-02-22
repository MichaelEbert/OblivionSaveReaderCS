
public class QuickKey {
    public byte flag = 0;
    public int iref = 0;

    public QuickKey(SaveBuffer buf) {
        this.flag = buf.readByte();
        if ((this.flag & 1) != 0) {
            this.iref = buf.readInt();
        }
    }
}