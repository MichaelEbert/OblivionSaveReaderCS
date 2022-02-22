
public class CreatedData {
    public dynamic type = "";
    public dynamic dataSize = 0;
    public dynamic flags = 0;
    public dynamic formid = 0;
    public dynamic version = 0;
    public byte[] data;

    public CreatedData(SaveBuffer buf) {
        this.type = buf.readString(4);
        this.dataSize = buf.readInt();
        this.flags = buf.readInt();
        this.formid = buf.readInt();
        this.version = buf.readInt();
        this.data = buf.readByteArray(this.dataSize);
    }
}