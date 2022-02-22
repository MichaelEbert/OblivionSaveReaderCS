
public class DeathCount {
    public dynamic actor = 0;
    public dynamic deathCount = 0;

    public DeathCount(SaveBuffer buf) {
        this.actor = buf.readInt();
        this.deathCount = buf.readShort();
    }
}