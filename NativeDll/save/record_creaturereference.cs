
using System.Diagnostics;
using System.Dynamic;

public struct PlayerStatistics
{
    public int skillAdvances;
    public int unknown1;
    public int largestBounty;
    public int killedCreatures;
    public int killedPersons;
    public int exploredPlaces;
    public int lockPicked;
    public int picksBroken;
    public int capturedSouls;
    public int usedIngredients;
    public int mixedPotions;
    public int oblivionGatesClosed;
    public int horsesOwned;
    public int housesOwned;
    public int investments;
    public int booksRead;
    public int teachingBooksRead;
    public int artifactsFound;
    public int hoursSlept;
    public int hoursWaited;
    public int unknown2;
    public int unknown3;
    public int unknown4;
    public int jokesTold;
    public int disease;
    public int nirnrootFound;
    public int burglary;
    public int pickpocketing;
    public int unknown5;
    public int attacks;
    public int murder;
    public int stolenHorses;
    public int unknown6;
    public int unknown7;
}

public class PlayerObject {
    public PlayerStatistics statistics;

    public int? unknown1;
    public byte[]? unknown2;
    public byte[]? unknown3;
    public int? pcBirthsign;
    public List<int> unknownArray = new List<int>();
    public int? num2;
    public byte[]? unknown4;
    public List<byte[]> unknown5 = new List<byte[]>();
    public byte[]? unknown6;
    public int? randODoorsNum;
    public List<ExpandoObject> randODoors = new List<ExpandoObject>();
        //int door;
        //int flag;
    byte[]? unknown7;
    int? activeEffectsNum;
    List<ExpandoObject> activeEffects = new List<ExpandoObject>();
    //int size;
    //int reference;
    //int index;
    //int effectDetails[];
    dynamic? expPoints;
        //int armorer;
        //int athletics;
        //int blade;
        //int block;
        //int blunt;
        //int handToHand;
        //int heavyArmor;
        //int alchemy;
        //int alteration;
        //int conjuration;
        //int destruction;
        //int illusion;
        //int mysticism;
        //int restoration;
        //int acrobatics;
        //int lightArmor;
        //int marksman;
        //int mercantile;
        //int security;
        //int sneak;
        //int speechcraft;
    int? advancement;
    dynamic? attrSkillCounts;
    //int strength;
    //int intelligence;
    //int willpower;
    //int agility;
    //int speed;
    //int endurance;
    //int personality;
    //int luck;
    dynamic? specCounts;
    //int combat;
    //int magic;
    //int stealth;
    dynamic? skillUsage;
        //int armorer;
        //int athletics;
        //int blade;
        //int block;
        //int blunt;
        //int handToHand;
        //int heavyArmor;
        //int alchemy;
        //int alteration;
        //int conjuration;
        //int destruction;
        //int illusion;
        //int mysticism;
        //int restoration;
        //int acrobatics;
        //int lightArmor;
        //int marksman;
        //int mercantile;
        //int security;
        //int sneak;
        //int speechcraft;

    int? majorSkillAdv;
    int? unknown8;
    int? activeQuest;
    int? knownTopicsNum;
    List<int> knownTopics = new List<int>();
    int? openQuestsNum;
    List<ExpandoObject> openQuests = new List<ExpandoObject>();
        //int quest;
        //int questStage;
        //int logEntry;
    int? magEffectNum;
    List<ExpandoObject> magEffects = new List<ExpandoObject>();
        //string edid;

    byte[]? fgGeoSym;
    byte[]? fgGeoAsym;
    byte[]? fgTexSym;
    int? race;
    int? hair;
    int? eyes;
    float? hairLength;
    byte[]? hairColor;
    int? unknown9;
    int? gender;
    string? pcName;
    int? pcClass;
    int? customClass_favoredAttribute1;
    int? customClass_favoredAttribute2;
    int? customClass_specialization;
    int? customClass_majorSkill1;
    int? customClass_majorSkill2;
    int? customClass_majorSkill3;
    int? customClass_majorSkill4;
    int? customClass_majorSkill5;
    int? customClass_majorSkill6;
    int? customClass_majorSkill7;
    int? customClass_flags;
    int? customClass_services;
    int? customClass_skillTrained;
    int? customClass_maxTrainingLevel;
    byte[]? customClass_unused;
    string? customClass_name;
    string? customClass_icon;
    int? unknown10;

    public PlayerObject(SaveBuffer buf, int maxOffset) {
        this.statistics.skillAdvances = buf.readInt(maxOffset);
        this.statistics.unknown1 = buf.readInt(maxOffset);
        this.statistics.largestBounty = buf.readInt(maxOffset);
        this.statistics.killedCreatures = buf.readInt(maxOffset);
        this.statistics.killedPersons = buf.readInt(maxOffset);
        this.statistics.exploredPlaces = buf.readInt(maxOffset);
        this.statistics.lockPicked = buf.readInt(maxOffset);
        this.statistics.picksBroken = buf.readInt(maxOffset);
        this.statistics.capturedSouls = buf.readInt(maxOffset);
        this.statistics.usedIngredients = buf.readInt(maxOffset);
        this.statistics.mixedPotions = buf.readInt(maxOffset);
        this.statistics.oblivionGatesClosed = buf.readInt(maxOffset);
        this.statistics.horsesOwned = buf.readInt(maxOffset);
        this.statistics.housesOwned = buf.readInt(maxOffset);
        this.statistics.investments = buf.readInt(maxOffset);
        this.statistics.booksRead = buf.readInt(maxOffset);
        this.statistics.teachingBooksRead = buf.readInt(maxOffset);
        this.statistics.artifactsFound = buf.readInt(maxOffset);
        this.statistics.hoursSlept = buf.readInt(maxOffset);
        this.statistics.hoursWaited = buf.readInt(maxOffset);
        this.statistics.unknown2 = buf.readInt(maxOffset);
        this.statistics.unknown3 = buf.readInt(maxOffset);
        this.statistics.unknown4 = buf.readInt(maxOffset);
        this.statistics.jokesTold = buf.readInt(maxOffset);
        this.statistics.disease = buf.readInt(maxOffset);
        this.statistics.nirnrootFound = buf.readInt(maxOffset);
        this.statistics.burglary = buf.readInt(maxOffset);
        this.statistics.pickpocketing = buf.readInt(maxOffset);
        this.statistics.unknown5 = buf.readInt(maxOffset);
        this.statistics.attacks = buf.readInt(maxOffset);
        this.statistics.murder = buf.readInt(maxOffset);
        this.statistics.stolenHorses = buf.readInt(maxOffset);
        this.statistics.unknown6 = buf.readInt(maxOffset);
        this.statistics.unknown7 = buf.readInt(maxOffset);

        if (buf.offset > maxOffset) return;
        this.unknown1 = buf.readByte(maxOffset);
        this.unknown2 = buf.readByteArray(95);
        this.unknown3 = buf.readByteArray(22);
        this.pcBirthsign = buf.readInt(maxOffset);
        this.unknownArray = new List<int>();
        for (var i = 0; i < 13; ++i) {
            this.unknownArray.Add(buf.readInt(maxOffset));
        }
        if (buf.offset > maxOffset) return;
        this.num2 = buf.readShort(maxOffset);
        this.unknown4 = buf.readByteArray(2);
        this.unknown5 = new List<byte[]>();
        for (var i = 0; i < this.num2; ++i) {
            this.unknown5.Add(buf.readByteArray(4));
        }
        if (buf.offset > maxOffset) return;
        this.unknown6 = buf.readByteArray(2);
        this.randODoorsNum = buf.readShort(maxOffset);
        this.randODoors = new List<ExpandoObject>();
        for (var i = 0; i < this.randODoorsNum; ++i) {

            this.randODoors.Add(CSUtil.Expando(
                "door", buf.readInt(maxOffset),
                "flag", buf.readByte(maxOffset)
            ));
        }
        if (buf.offset > maxOffset) return;
        this.unknown7 = buf.readByteArray(2);
        this.activeEffectsNum = buf.readShort(maxOffset);
        this.activeEffects = new List<ExpandoObject>();
        for (var i = 0; i < this.activeEffectsNum; ++i) {
            var size = buf.readShort(maxOffset);
            this.activeEffects.Add(CSUtil.Expando(
                "size" , size,
                "reference" , buf.readInt(maxOffset),
                "index" , buf.readByte(maxOffset),
                "effectDetails" , buf.readByteArray(size)
            ));
        }
        if (buf.offset > maxOffset) return;
        this.expPoints = new ExpandoObject();
        expPoints.armorer = buf.readFloat(maxOffset);
        expPoints.athletics = buf.readFloat(maxOffset);
        expPoints.blade = buf.readFloat(maxOffset);
        expPoints.block = buf.readFloat(maxOffset);
        expPoints.blunt = buf.readFloat(maxOffset);
        expPoints.handToHand = buf.readFloat(maxOffset);
        expPoints.heavyArmor = buf.readFloat(maxOffset);
        expPoints.alchemy = buf.readFloat(maxOffset);
        expPoints.alteration = buf.readFloat(maxOffset);
        expPoints.conjuration = buf.readFloat(maxOffset);
        expPoints.destruction = buf.readFloat(maxOffset);
        expPoints.illusion = buf.readFloat(maxOffset);
        expPoints.mysticism = buf.readFloat(maxOffset);
        expPoints.restoration = buf.readFloat(maxOffset);
        expPoints.acrobatics = buf.readFloat(maxOffset);
        expPoints.lightArmor = buf.readFloat(maxOffset);
        expPoints.marksman = buf.readFloat(maxOffset);
        expPoints.mercantile = buf.readFloat(maxOffset);
        expPoints.security = buf.readFloat(maxOffset);
        expPoints.sneak = buf.readFloat(maxOffset);
        expPoints.speechcraft = buf.readFloat(maxOffset);

        if (buf.offset > maxOffset) return;
        this.advancement = buf.readInt(maxOffset);
        this.attrSkillCounts = new List<ExpandoObject>();
        for (var i = 0; i < this.advancement; ++i) {
            dynamic asc = new ExpandoObject();
            this.attrSkillCounts.Add(asc);
            asc.strength = buf.readByte(maxOffset);
            asc.intelligence = buf.readByte(maxOffset);
            asc.willpower = buf.readByte(maxOffset);
            asc.agility = buf.readByte(maxOffset);
            asc.speed = buf.readByte(maxOffset);
            asc.endurance = buf.readByte(maxOffset);
            asc.personality = buf.readByte(maxOffset);
            asc.luck = buf.readByte(maxOffset);
            if (buf.offset > maxOffset) return;
        }
        this.specCounts = new ExpandoObject();
        specCounts.combat = buf.readByte(maxOffset);
        specCounts.magic = buf.readByte(maxOffset);
        specCounts.stealth = buf.readByte(maxOffset);

        if (buf.offset > maxOffset) return;
        this.skillUsage = new ExpandoObject();
        skillUsage.armorer = buf.readInt(maxOffset);
        skillUsage.athletics = buf.readInt(maxOffset);
        skillUsage.blade = buf.readInt(maxOffset);
        skillUsage.block = buf.readInt(maxOffset);
        skillUsage.blunt = buf.readInt(maxOffset);
        skillUsage.handToHand = buf.readInt(maxOffset);
        skillUsage.heavyArmor = buf.readInt(maxOffset);
        skillUsage.alchemy = buf.readInt(maxOffset);
        skillUsage.alteration = buf.readInt(maxOffset);
        skillUsage.conjuration = buf.readInt(maxOffset);
        skillUsage.destruction = buf.readInt(maxOffset);
        skillUsage.illusion = buf.readInt(maxOffset);
        skillUsage.mysticism = buf.readInt(maxOffset);
        skillUsage.restoration = buf.readInt(maxOffset);
        skillUsage.acrobatics = buf.readInt(maxOffset);
        skillUsage.lightArmor = buf.readInt(maxOffset);
        skillUsage.marksman = buf.readInt(maxOffset);
        skillUsage.mercantile = buf.readInt(maxOffset);
        skillUsage.security = buf.readInt(maxOffset);
        skillUsage.sneak = buf.readInt(maxOffset);
        skillUsage.speechcraft = buf.readInt(maxOffset);

        if (buf.offset > maxOffset) return;
        this.majorSkillAdv = buf.readInt(maxOffset);
        this.unknown8 = buf.readByte(maxOffset);
        this.activeQuest = buf.readInt(maxOffset);
        this.knownTopicsNum = buf.readShort(maxOffset);
        this.knownTopics = new List<int>();
        for (var i = 0; i < this.knownTopicsNum; ++i) {
            this.knownTopics.Add(buf.readInt(maxOffset));
        }
        if (buf.offset > maxOffset) return;
        this.openQuestsNum = buf.readShort(maxOffset);
        this.openQuests = new List<ExpandoObject>();
        for (var i = 0; i < this.openQuestsNum; ++i) {
            this.openQuests.Add(CSUtil.Expando(
                "quest" , buf.readInt(maxOffset),
                "questStage" , buf.readByte(maxOffset),
                "logEntry" , buf.readByte(maxOffset)
           ));
        }
        if (buf.offset > maxOffset) return;
        this.magEffectNum = buf.readInt(maxOffset);
        this.magEffects = new List<ExpandoObject>();
        for (var i = 0; i < this.magEffectNum; ++i) {
            this.magEffects.Add(CSUtil.Expando("edid", buf.readString(4)));
            if (buf.offset > maxOffset) return;
        }
    
        this.fgGeoSym = buf.readByteArray(200);
        this.fgGeoAsym = buf.readByteArray(120);
        this.fgTexSym = buf.readByteArray(200);
        this.race = buf.readInt(maxOffset);
        this.hair = buf.readInt(maxOffset);
        this.eyes = buf.readInt(maxOffset);
        this.hairLength = buf.readFloat(maxOffset);
        this.hairColor = buf.readByteArray(3);
        this.unknown9 = buf.readByte(maxOffset);
        this.gender = buf.readByte(maxOffset);
        this.pcName = buf.readbzString(maxOffset);
        this.pcClass = buf.readInt(maxOffset);
        // It would be more accurate to actually check if `saveFile.formIds[this.pcClass]==0x00022843` but that would require some refactoring
        if (maxOffset > buf.offset) {
            this.customClass_favoredAttribute1 = buf.readInt(maxOffset);
            this.customClass_favoredAttribute2 = buf.readInt(maxOffset);
            this.customClass_specialization = buf.readInt(maxOffset);
            this.customClass_majorSkill1 = buf.readInt(maxOffset);
            this.customClass_majorSkill2 = buf.readInt(maxOffset);
            this.customClass_majorSkill3 = buf.readInt(maxOffset);
            this.customClass_majorSkill4 = buf.readInt(maxOffset);
            this.customClass_majorSkill5 = buf.readInt(maxOffset);
            this.customClass_majorSkill6 = buf.readInt(maxOffset);
            this.customClass_majorSkill7 = buf.readInt(maxOffset);
            this.customClass_flags = buf.readInt(maxOffset);
            this.customClass_services = buf.readInt(maxOffset);
            this.customClass_skillTrained = buf.readByte(maxOffset);
            this.customClass_maxTrainingLevel = buf.readByte(maxOffset);
            this.customClass_unused = buf.readByteArray(2, maxOffset);
            this.customClass_name = buf.readbString(maxOffset);
            this.customClass_icon = buf.readbString(maxOffset);
        }
        // Looks like a formId or iref but doesn't match up?
        this.unknown10 = buf.readInt(maxOffset);
    }
};

public class RecordCreatureReference {
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

    public List<float> tempAttributeChanges_activeEffects = new List<float>();
    public List<float> tempAttributeChanges_unknownEffects = new List<float>();
    public List<float> tempAttributeChanges_damageEffects = new List<float>();
    public float? tempAttributeChanges_deltaHealth;
    public float? tempAttributeChanges_deltaMagicka;
    public float? tempAttributeChanges_deltaFatigue;

    public int? actorFlag;

    public int? flags;
    public int? inventory_itemNum;
    public List<InventoryItem> inventory_items = new List<InventoryItem>();
    public int? havokMoved_dataLen;
    public byte[]? havokMoved_data;
    public float? scale;
    public bool? enabled;
    public int? propertiesNum;
    public List<Prop> properties = new List<Prop>();

    public PlayerObject? player;

    public RecordCreatureReference(Record record, SaveBuffer buf) {
        // Just a type assertion for TS
        if (record.data == null) return;
        var startOffset = buf.offset;
        var maxOffset = startOffset + record.dataSize;
        try {
            // Handle player data as a special case before anything else even though it's out-of-order
            if (record.formId == 0x14) {
                int? playerOffset = null;
                for (var i = record.dataSize - 1; i >= 0; --i) {
                    if (
                        record.data[i] == 0x42 && record.data[i-1] == 0x96
                        && record.data[i-21] == 0x42 && record.data[i-22] == 0xec
                    ) {
                        playerOffset = buf.offset + i + 29;
                        break;
                    }
                }
                if (playerOffset == null) {
                    Debugger.Break();
                } else {
                    this.player = new PlayerObject(new SaveBuffer(buf.buffer, playerOffset.Value), startOffset + record.dataSize);
                }
            }
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
            if (record.formId == 0x14) {
                for (var i = 0; i < 71; ++i) {
                    this.tempAttributeChanges_activeEffects.Add(buf.readFloat(maxOffset));
                }
                for (var i = 0; i < 71; ++i) {
                    this.tempAttributeChanges_unknownEffects.Add(buf.readFloat(maxOffset));
                }
                for (var i = 0; i < 71; ++i) {
                    this.tempAttributeChanges_damageEffects.Add(buf.readFloat(maxOffset));
                }
                this.tempAttributeChanges_deltaHealth = buf.readFloat(maxOffset);
                this.tempAttributeChanges_deltaMagicka = buf.readFloat(maxOffset);
                this.tempAttributeChanges_deltaFatigue = buf.readFloat(maxOffset);
            }
            this.actorFlag = buf.readByte(maxOffset);
            if ((record.flags & 0x1) != 0) {
                this.flags = buf.readInt(maxOffset);
            }
            if ((record.flags & 0x8000000) != 0) {
                this.inventory_itemNum = buf.readShort(maxOffset);
                for (var i = 0; i < this.inventory_itemNum; ++i) {
                    var iref = buf.readInt(maxOffset);
                    var stackedItemsNum = buf.readInt(maxOffset);
                    var changedEntriesNum = buf.readInt(maxOffset);
                    List<PropertyCollection> changedEntries = new List<PropertyCollection>();
                    for (var j = 0; j < changedEntriesNum; ++j) {
                        var props = Properties.getProps(buf, startOffset + record.dataSize);
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
            var p = Properties.getProps(buf, startOffset + record.dataSize);
            this.propertiesNum = p.propertiesNum;
            this.properties = p.properties;
            if ((record.flags & 0x8) != 0 && !((record.flags & 0x2) != 0 || (record.flags & 0x4) != 0)) {
                this.havokMoved_dataLen = buf.readShort(maxOffset);
                this.havokMoved_data = buf.readByteArray(this.havokMoved_dataLen.Value);
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
