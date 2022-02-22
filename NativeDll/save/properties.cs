
using System.Dynamic;

public struct Prop
{
    public int flag;
    public object value;

    public Prop(int flag, object value)
    {
        this.flag = flag;
        this.value = value;
    }
}

public struct PropertyCollection
{
    public int propertiesNum;
    public List<Prop> properties;

    public PropertyCollection(int propertiesNum, List<Prop> properties)
    {
        this.propertiesNum = propertiesNum;
        this.properties = properties;
    }
}


public static class Properties
{
    public static PropertyCollection getProps(SaveBuffer buf, int endOffset)
    {
        var propertiesNum = buf.readShort();
        List<Prop> properties = new List<Prop>();
        if (buf.offset > endOffset)
        {
            /* console.log('Invalid object props', propertiesNum, offset, endOffset); */
            return new PropertyCollection(propertiesNum, properties);
        }
        for (var k = 0; k < propertiesNum; ++k)
        {
            var flag = buf.readByte();
            if (buf.offset > endOffset)
            {
                /* console.log('Invalid object props', propertiesNum, offset, endOffset); */
                return new PropertyCollection(propertiesNum, properties);
            }
            dynamic? value = null;
            // This is ugly
            switch (flag)
            {
                case 0x11:
                    value = buf.readInt();
                    break;
                case 0x12:
                    value = new ExpandoObject();
                    value.scriptref = buf.readInt();
                    value.varNum = buf.readShort();
                    value.variables = new List<ExpandoObject>();
                    for (var l = 0; l < value.varNum; ++l)
                    {
                        dynamic _var = new ExpandoObject();
                        _var.varIndex = buf.readShort();
                        _var.varType = buf.readShort();
                        if (_var.varType == 0xF000)
                        {
                            _var.refVar = buf.readInt();
                        }
                        if (_var.varType == 0)
                        {
                            _var.refVar = buf.readDouble();
                        }
                        value.variables.Add(_var);
                        if (buf.offset > endOffset)
                        {
                            /* console.log('Invalid object props', propertiesNum, offset, endOffset); */
                            return new PropertyCollection(propertiesNum, properties);
                        }
                    }
                    value.unknown = buf.readByte();
                    break;
                case 0x1b:
                    value = 1;
                    break;
                case 0x1c:
                    value = 1;
                    break;
                case 0x1e:
                    value = new ExpandoObject();
                    value.cell = buf.readInt();
                    value.x = buf.readFloat();
                    value.y = buf.readFloat();
                    value.z = buf.readFloat();
                    value.flags = buf.readInt();
                    break;
                case 0x1f:
                    value = new ExpandoObject();
                    value.package = buf.readInt();
                    value.flags = buf.readInt();
                    value.package2 = buf.readInt();
                    value.unknown = buf.readShort();
                    break;
                case 0x20:
                    value = new ExpandoObject();
                    value.formId = buf.readInt();
                    value.data = buf.readByteArray(59);
                    break;
                case 0x21:
                    value = new ExpandoObject();
                    value.dataNum = buf.readShort();
                    value.data = new List<object>();
                    for (var l = 0; l < value.dataNum; ++l)
                    {
                        dynamic data = new ExpandoObject();
                        data.iref = buf.readInt();
                        data.unknown = buf.readByte();
                        value.data.Add(data);
                        if (buf.offset > endOffset) {/* console.log('Invalid object props', propertiesNum, offset, endOffset); */ return new PropertyCollection(propertiesNum, properties); }
                    }
                    break;
                case 0x22:
                    value = buf.readInt();
                    break;
                case 0x23:
                    value = new ExpandoObject();
                    value.dataNum = buf.readShort();
                    value.data = new List<object>();
                    for (var l = 0; l < value.dataNum; ++l)
                    {
                        value.data.Add(buf.readInt());
                        if (buf.offset > endOffset) {/* console.log('Invalid object props', propertiesNum, offset, endOffset); */ return new PropertyCollection(propertiesNum, properties); }
                    }
                    break;
                case 0x25:
                    value = 1;
                    break;
                case 0x27:
                    value = buf.readInt();
                    break;
                case 0x28:
                    value = buf.readInt();
                    break;
                case 0x29:
                    value = buf.readInt();
                    break;
                case 0x2a:
                    value = buf.readShort();
                    break;
                case 0x2b:
                    value = buf.readFloat();
                    break;
                case 0x2c:
                    value = buf.readByte();
                    break;
                case 0x2d:
                    value = buf.readFloat();
                    break;
                case 0x2e:
                    value = buf.readFloat();
                    break;
                case 0x2f:
                    value = buf.readByte();
                    break;
                case 0x31:
                    value = new ExpandoObject();
                    value.lockLevel = buf.readByte();
                    value.key = buf.readInt();
                    value.flag = buf.readByte();
                    break;
                case 0x32:
                    value = new ExpandoObject();
                    value.x = buf.readFloat();
                    value.y = buf.readFloat();
                    value.z = buf.readFloat();
                    value.rX = buf.readFloat();
                    value.rY = buf.readFloat();
                    value.rZ = buf.readFloat();
                    value.destDoor = buf.readInt();
                    break;
                case 0x33:
                    value = buf.readByte();
                    break;
                case 0x35:
                    // ?????
                    //Debugger.Break();
                    break;
                case 0x36:
                    value = buf.readByteArray(5);
                    break;
                case 0x37:
                    value = buf.readFloat();
                    break;
                case 0x39:
                    value = buf.readByteArray(12);
                    break;
                case 0x3a:
                    value = new ExpandoObject();
                    value.iref = buf.readInt();
                    value.dataNum = buf.readShort();
                    value.data = new List<object>();
                    for (var i = 0; i < value.dataNum; ++i)
                    {
                        value.data.Add(buf.readByteArray(61));
                        if (buf.offset > endOffset) {/* console.log('Invalid object props', propertiesNum, offset, endOffset); */ return new PropertyCollection(propertiesNum, properties); }
                    }
                    break;
                case 0x3c:
                    value = buf.readInt();
                    break;
                case 0x3d:
                    value = buf.readFloat();
                    break;
                case 0x3e:
                    value = new ExpandoObject();
                    value.door = buf.readInt();
                    value.x = buf.readFloat();
                    value.y = buf.readFloat();
                    value.z = buf.readFloat();
                    break;
                case 0x41:
                    value = buf.readFloat();
                    break;
                case 0x47:
                    value = 1;
                    break;
                case 0x48:
                    value = buf.readInt();
                    break;
                case 0x4a:
                    value = buf.readbString();
                    break;
                case 0x4b:
                    value = new ExpandoObject();
                    value.unknown = buf.readInt();
                    value.dataNum = buf.readShort();
                    value.data = buf.readByteArray(value.dataNum);
                    // uesp states that sometimes there's 2 extra null bytes here. That's actually a 0x0000 havok moved length apparently?
                    break;
                case 0x4e:
                    value = new ExpandoObject();
                    value.dataNum = buf.readShort();
                    value.data = new List<object>();
                    for (var i = 0; i < value.dataNum; ++i)
                    {
                        value.data.Add(buf.readByteArray(10));
                        if (buf.offset > endOffset) {/* console.log('Invalid object props', propertiesNum, offset, endOffset); */ return new PropertyCollection(propertiesNum, properties); }
                    }
                    break;
                case 0x4f:
                    value = buf.readByteArray(4);
                    break;
                case 0x50:
                    value = 1;
                    break;
                case 0x52:
                    value = buf.readInt();
                    break;
                case 0x53:
                    value = buf.readInt();
                    break;
                case 0x55:
                    value = buf.readByte();
                    break;
                case 0x59:
                    value = new ExpandoObject();
                    value.convTopic = buf.readbString();
                    value.unknown = buf.readByte();
                    value.convNum = buf.readByte();
                    value.conv = new List<object>();
                    for (var l = 0; l < value.convNum; ++l)
                    {
                        dynamic conv = new ExpandoObject();
                        conv.index = buf.readByte();
                        conv.convQuest = buf.readInt();
                        conv.convDialog = buf.readInt();
                        conv.convInfo = buf.readInt();
                        value.conv.Add(conv);
                        if (buf.offset > endOffset) {/* console.log('Invalid object props', propertiesNum, offset, endOffset); */ return new PropertyCollection(propertiesNum, properties); }
                    }
                    break;
                case 0x5a:
                    value = buf.readByte();
                    break;
                case 0x5c:
                    value = buf.readFloat();
                    break;
            }
            properties.Add(new Prop(
                flag,
                value)
            );
            if (buf.offset > endOffset) {/* console.log('Invalid object props', propertiesNum, offset, endOffset); */ return new PropertyCollection(propertiesNum, properties); }
        }

        return new PropertyCollection(
            propertiesNum,
            properties
        );
    }
}
