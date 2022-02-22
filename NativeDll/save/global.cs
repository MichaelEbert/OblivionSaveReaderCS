public class Global {
    public dynamic iref = 0;
    public dynamic value = 0.0;

    public Global(SaveBuffer buf) {
        this.iref = buf.readInt();
        this.value = buf.readFloat();
    }
}