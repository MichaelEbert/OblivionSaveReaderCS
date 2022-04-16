public class SaveFile {
    // File header
    public string fileId = "TES4SAVEGAME";
    public int majorVersion;
    public int minorVersion;
    public DateTime exeTime;

    // Save header
    public int headerVersion;
    public int saveHeaderSize;
    public int saveNum;
    public string pcName;
    public int pcLevel;
    public string pcLocation;
    public float gameDays;

    public int gameTicks;
    public DateTime gameTime;
    public int screenshotSize;
    public int screenshotWidth;
    public int screenshotHeight;
    public byte[] screenshotData;

    // Plugins
    public int pluginsNum;
    string[] plugins;

    // Global
    public int formIdsOffset;

    public int recordsNum;
    public int nextObjectid;
    public int worldId;
    public int worldX;
    public int worldY;

    public int pcLocationCell;
    public float pcLocationX;
    public float pcLocationY;
    public float pcLocationZ;
    
    public int globalsNum;
    public List<Global> globals;
    
    public int tesClassSize;
    public int numDeathCounts;
    public List<DeathCount> deathCounts;
    
    public float gameModeSeconds;

    public int processesSize;
    public byte[] processesData;

    public int specEventSize;
    public byte[] specEventData;

    public int weatherSize;
    public byte[] weatherData;

    public int playerCombatCount;

    public int createdNum;
    List<CreatedData> createdData;

    public int quickKeysSize;
    List<QuickKey> quickKeysData;

    public int reticuleSize;
    public byte[] reticuleData;

    public int interfaceSize;
    public byte[] interfaceData;

    public int regionsSize;
    public int regionsNum;
    public List<Region> regions;

    // Change Records
    public List<Record> records;

    // Temporary Effects
    public int tempEffectsSize;
    public byte[] tempEffectsData;

    // Form IDs
    public int formIdsNum;
    public int[] formIds;

    // World Spaces
    public int worldSpacesNum;
    public int[] worldSpaces;

    // Constants used for reading
    /*static constants = {
        quests quests,
        locs locs,
        ignoreLocs ignoreLocs,
        skills skills,
        gates gates,
        horses horses,
        investments investments,
        books books,
        houses houses,
        artifacts artifacts,
        nirnroots nirnroots,
        arena arena,
        factions factions,
        greaterPowers greaterPowers,
        wayshrines wayshrines,
        incompleteQuests incompleteQuests,
    };*/

    public SaveFile(byte[] arrayBuf) {
        var buf = new SaveBuffer(arrayBuf, 0);
        // File header
        this.fileId = buf.readString(12);
        this.majorVersion = buf.readByte();
        this.minorVersion = buf.readByte();
        this.exeTime = buf.readDate();

        // Save header
        this.headerVersion = buf.readInt();
        this.saveHeaderSize = buf.readInt();
        this.saveNum = buf.readInt();
        this.pcName = buf.readbzString();
        this.pcLevel = buf.readShort();
        this.pcLocation = buf.readbzString();
        this.gameDays = buf.readFloat();

        this.gameTicks = buf.readInt();
        this.gameTime = buf.readDate();
        this.screenshotSize = buf.readInt();
        this.screenshotWidth = buf.readInt();
        this.screenshotHeight = buf.readInt();
        this.screenshotData = buf.readByteArray(this.screenshotSize - 8);

        // Plugins
        this.pluginsNum = buf.readByte();
        this.plugins = buf.readbStringArray(this.pluginsNum);

        // Global
        this.formIdsOffset = buf.readInt();

        this.recordsNum = buf.readInt();
        this.nextObjectid = buf.readInt();
        this.worldId = buf.readInt();
        this.worldX = buf.readInt();
        this.worldY = buf.readInt();

        this.pcLocationCell = buf.readInt();
        this.pcLocationX = buf.readFloat();
        this.pcLocationY = buf.readFloat();
        this.pcLocationZ = buf.readFloat();
        
        this.globalsNum = buf.readShort();
        this.globals = new List<Global>();
        for (var i = 0; i < this.globalsNum; ++i) {
            this.globals.Add(new Global(buf));
        }
        
        this.tesClassSize = buf.readShort();
        this.numDeathCounts = buf.readInt();
        this.deathCounts = new List<DeathCount>();
        for (var i = 0; i < this.numDeathCounts; ++i) {
            this.deathCounts.Add(new DeathCount(buf));
        }
        this.gameModeSeconds = buf.readFloat();

        this.processesSize = buf.readShort();
        this.processesData = buf.readByteArray(this.processesSize);

        this.specEventSize = buf.readShort();
        this.specEventData = buf.readByteArray(this.specEventSize);

        this.weatherSize = buf.readShort();
        this.weatherData = buf.readByteArray(this.weatherSize);
        this.playerCombatCount = buf.readInt();
        this.createdNum = buf.readInt();
        this.createdData = new List<CreatedData>();
        for (var i = 0; i < this.createdNum; ++i) {
            this.createdData.Add(new CreatedData(buf));
        }
        this.quickKeysSize = buf.readShort();
        var quickKeysEnd = buf.offset + this.quickKeysSize;
        this.quickKeysData = new List<QuickKey>();
        while (buf.offset < quickKeysEnd) {
            this.quickKeysData.Add(new QuickKey(buf));
        }

        this.reticuleSize = buf.readShort();
        this.reticuleData = buf.readByteArray(this.reticuleSize);
        this.interfaceSize = buf.readShort();
        this.interfaceData = buf.readByteArray(this.interfaceSize);
        this.regionsSize = buf.readShort();
        this.regionsNum = buf.readShort();
        this.regions = new List<Region>();
        for (var i = 0; i < this.regionsNum; ++i) {
            this.regions.Add(new Region(buf));
        }

        // Change Records
        // For performance, this works differently
        this.records = new List<Record>();
        for (var i = 0; i < this.recordsNum; ++i) {
            // Don't pass original SaveBuffer object due to bugs/unknowns in record parsing
            var record = new Record(new SaveBuffer(buf.buffer, buf.offset));
            this.records.Add(record);
            buf.advance(12 + record.dataSize);
        }

        // Temporary Effects
        this.tempEffectsSize = buf.readInt();
        this.tempEffectsData = buf.readByteArray(this.tempEffectsSize);

        // Form IDs
        this.formIdsNum = buf.readInt();
        this.formIds = buf.readIntArray(this.formIdsNum);

        // World Spaces
        this.worldSpacesNum = buf.readInt();
        this.worldSpaces = buf.readIntArray(this.worldSpacesNum);
    }

    public void trim(bool screenshotData = false) {
        /*for (var loc in SaveFile.constants.locs) {
            this.records.find((e) => e.formId == loc.formId)?.subRecord;
        }
        for (var investment in SaveFile.constants.investments) {
            this.records.find((e) => e.formId == investment.formId)?.subRecord;
        }
        for (var book in SaveFile.constants.books) {
            this.records.find((e) => e.formId == book.formId)?.subRecord;
        }
        for (var horse in SaveFile.constants.horses) {
            this.records.find((e) => e.formId == horse.formId)?.subRecord;
        }
        for (var house in SaveFile.constants.houses) {
            this.records.find((e) => e.formId == house.formId)?.subRecord;
        }
        for (var root in SaveFile.constants.nirnroots) {
            this.records.find((e) => e.formId == root.formId)?.subRecord;
        }
        for (var quest in SaveFile.constants.quests) {
            this.records.find((e) => e.formId == quest.formId)?.subRecord;
        }
        for (var gate in SaveFile.constants.gates) {
            this.records.find((e) => e.formId == gate.formId)?.subRecord;
        }
        for (var fight in SaveFile.constants.arena) {
            this.records.find((e) => e.formId == fight.formId)?.subRecord;
        }
        this.records.filter(r=>[0x14,0x7].includes(r.formId)).forEach(r=>r.subRecord);

        if (screenshotData) {
            this.screenshotData = [];
        }*/
        
    }
}
