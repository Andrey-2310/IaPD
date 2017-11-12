package printer;

import model.Hdd;

public class Printer {

    public void print(final Hdd hdd) {
        System.out.println("Model:                      " + hdd.getModel());
        System.out.println("Firmware:                   " + hdd.getFirmware());
        System.out.println("Serial:                     " + hdd.getSerial());
        System.out.println("Supported ATA generations:  " + hdd.getAta());
        System.out.println("Pio:                        " + hdd.getMemoryAccess().getPio());
        System.out.println("Dma:                        " + hdd.getMemoryAccess().getDma());
        System.out.println("Memory info");
        System.out.println("Free:                       " + hdd.getMemoryStatus().getFree());
        System.out.println("Used:                       " + hdd.getMemoryStatus().getUsed());
        System.out.println("Total:                      " + hdd.getMemoryStatus().getTotal());
    }
}