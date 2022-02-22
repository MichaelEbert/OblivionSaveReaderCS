
using System.Dynamic;

public class InventoryItem
{
    int iref;
    int stackedItemsNum;
    int changedEntriesNum;
    List<PropertyCollection> changedEntries;

    public InventoryItem(int iref, int stackedItemsNum, int changedEntriesNum, List<PropertyCollection> changedEntries)
    {
        this.iref = iref;
        this.stackedItemsNum = stackedItemsNum;
        this.changedEntriesNum = changedEntriesNum;
        this.changedEntries = changedEntries;
    }
}

public class RecordInstanceReference {
    public int? cellChanged_cell;
    public float? cellChanged_x;
    public float? cellChanged_y;
    public float? cellChanged_z;

    public int? created_flags;
    public int? created_baseItem;
    public int? created_cell;
    public float? created_x;
    public float? created_y;
    public float? created_z;
    public float? created_rX;
    public float? created_rY;
    public float? created_rZ;

    public int? moved_cell;
    public float? moved_x;
    public float? moved_y;
    public float? moved_z;
    public float? moved_rX;
    public float? moved_rY;
    public float? moved_rZ;

    public int? havokMoved_cell;
    public float? havokMoved_x;
    public float? havokMoved_y;
    public float? havokMoved_z;
    public float? havokMoved_rX;
    public float? havokMoved_rY;
    public float? havokMoved_rZ;

    public int? oblivionCell;

    public int? actorFlag;

    public int? flags;
    public int? inventory_itemNum;
    public List<InventoryItem> inventory_items = new List<InventoryItem>();
    public int? havokMoved_dataLen;
    byte[]? havokMoved_data;
    public float? scale;
    public bool? enabled;
    public int? propertiesNum;
    public List<Prop> properties = new List<Prop>();

    public RecordInstanceReference(Record record, SaveBuffer buf) {
        var startOffset = buf.offset;
        var maxOffset = startOffset + record.dataSize;
        try {
            startOffset = buf.offset;
            if ((record.flags & 0x80000000) != 0) {
                this.cellChanged_cell = buf.readInt(maxOffset);
                this.cellChanged_x = buf.readFloat(maxOffset);
                this.cellChanged_y = buf.readFloat(maxOffset);
                this.cellChanged_z = buf.readFloat(maxOffset);
            }
            if ((record.flags & 0x2) != 0) {
                this.created_flags = buf.readInt(maxOffset);
                this.created_baseItem = buf.readInt(maxOffset);
                this.created_cell = buf.readInt(maxOffset);
                this.created_x = buf.readFloat(maxOffset);
                this.created_y = buf.readFloat(maxOffset);
                this.created_z = buf.readFloat(maxOffset);
                this.created_rX = buf.readFloat(maxOffset);
                this.created_rY = buf.readFloat(maxOffset);
                this.created_rZ = buf.readFloat(maxOffset);
            }
            if ((record.flags & 0x4) != 0) {
                this.moved_cell = buf.readInt(maxOffset);
                if (this.moved_cell == 0 && record.dataSize <= 5) {
                    this.actorFlag = buf.readByte(maxOffset);
                    return;
                }
                this.moved_x = buf.readFloat(maxOffset);
                this.moved_y = buf.readFloat(maxOffset);
                this.moved_z = buf.readFloat(maxOffset);
                this.moved_rX = buf.readFloat(maxOffset);
                this.moved_rY = buf.readFloat(maxOffset);
                this.moved_rZ = buf.readFloat(maxOffset);
            }
            if ((record.flags & 0x8) != 0 && !((record.flags & 0x2) != 0 || (record.flags & 0x4) != 0)) {
                this.havokMoved_cell = buf.readInt(maxOffset);
                this.havokMoved_x = buf.readFloat(maxOffset);
                this.havokMoved_y = buf.readFloat(maxOffset);
                this.havokMoved_z = buf.readFloat(maxOffset);
                this.havokMoved_rX = buf.readFloat(maxOffset);
                this.havokMoved_rY = buf.readFloat(maxOffset);
                this.havokMoved_rZ = buf.readFloat(maxOffset);
            }
            if ((record.flags & 0x800000) != 0 && !((record.flags & 0x2) != 0 || (record.flags & 0x4) != 0 || (record.flags & 0x8) != 0)) {
                this.oblivionCell = buf.readInt(maxOffset);
            }
            if ((record.flags & 0x1) != 0) {
                this.flags = buf.readInt(maxOffset);
            }
            if ((record.flags & 0x8000000) != 0) {
                this.inventory_itemNum = buf.readShort(maxOffset);
                for (var i = 0; i < this.inventory_itemNum; ++i) {
                    if (buf.offset - startOffset > record.dataSize) {/* console.log('Invalid object', record, this); */ return;}
                    var iref = buf.readInt(maxOffset);
                    var stackedItemsNum = buf.readInt(maxOffset);
                    var changedEntriesNum = buf.readInt(maxOffset);
                    var changedEntries = new List<PropertyCollection>();
                    for (var j = 0; j < changedEntriesNum; ++j) {
                        if (buf.offset - startOffset > record.dataSize) {/* console.log('Invalid object', record, this); */ return;}
                        PropertyCollection props = Properties.getProps(buf, startOffset + record.dataSize);
                        changedEntries.Add(props);
                    }
                    this.inventory_items.Add(new InventoryItem(
                        iref: iref,
                        stackedItemsNum: stackedItemsNum,
                        changedEntriesNum: changedEntriesNum,
                        changedEntries: changedEntries
                    ));
                }
            }
            if ((record.flags & 0x173004e0) != 0) {
                if (buf.offset - startOffset > record.dataSize) {/* console.log('Invalid object', record, this); */ return;}
                var props = Properties.getProps(buf, startOffset + record.dataSize);
                this.propertiesNum = props.propertiesNum;
                this.properties = props.properties;
            }
            if ((record.flags & 0x8) != 0 && !((record.flags & 0x2) != 0 || (record.flags & 0x4) != 0)) {
                this.havokMoved_dataLen = buf.readShort(maxOffset);
                this.havokMoved_data = buf.readByteArray(this.havokMoved_dataLen.Value, maxOffset);
            }
            if ((record.flags & 0x10) != 0) {
                this.scale = buf.readFloat(maxOffset);
            }
            this.enabled = (record.flags & 0x40000000) == 0x40000000;
        } catch (Exception e) {
            Console.Write(e.StackTrace);
        }
        if (buf.buffer.Length != buf.offset) {
            // Too many issues decoding these still
            //Debugger.Break();
        }
    }
}
