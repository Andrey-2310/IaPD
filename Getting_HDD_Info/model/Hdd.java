package model;

public class Hdd {

    private String model;
    private String serial;
    private String firmware;
    private String ata;
    private MemoryAccess memoryAccess = new MemoryAccess();
    private MemoryStatus memoryStatus;

    public String getModel() {
        return model;
    }

    public void setModel(String model) {
        this.model = model;
    }

    public String getSerial() {
        return serial;
    }

    public void setSerial(String serial) {
        this.serial = serial;
    }

    public String getFirmware() {
        return firmware;
    }

    public void setFirmware(String firmware) {
        this.firmware = firmware;
    }

    public String getAta() {
        return ata;
    }

    public void setAta(String ata) {
        this.ata = ata;
    }

    public MemoryAccess getMemoryAccess() {
        return memoryAccess;
    }

    public void setMemoryAccess(MemoryAccess memoryAccess) {
        this.memoryAccess = memoryAccess;
    }

    public MemoryStatus getMemoryStatus() {
        return memoryStatus;
    }

    public void setMemoryStatus(MemoryStatus memoryStatus) {
        this.memoryStatus = memoryStatus;
    }
}