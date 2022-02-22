
public class Region {
    public dynamic iref = 0;
    public dynamic unknown6 = 0;

    public Region(SaveBuffer buf) {
        this.iref = buf.readInt();
        this.unknown6 = buf.readInt();
    }
}